using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Com.Baidu.Mapapi.Map;
using Android.Locations;
using Location = Android.Locations.Location;
using Com.Baidu.Mapapi;
using Android.Widget;
using Com.Baidu.Mapapi.Model;
using Com.Baidu.Mapapi.Utils;
using FlyCarApp.Class;
using Xamarin.Essentials;
using Xamarin.Forms;
using FlyCarApp.Interface;
using FlyCarApp.Page;
using Com.Baidu.Mapapi.Search.Geocode;
using Com.Baidu.Mapapi.Search.Poi;
using Android.Content;

namespace FlyCarApp.Droid
{
    [Activity(Label = "FlyCarApp", Icon = "@drawable/log", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ILocationListener
    {
        //百度地图
        //这是安卓自带的定位器，以后改成百度的，这个定位器有点偏差，但是偏差不大
        public static Location CurrentLocation = null;
        CompassTest compassTest = new CompassTest();
        LocationManager locMgr;
        bool RunStatus = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            Xamarin.Forms.Forms.SetFlags(new string[] { "RadioButton_Experimental" });//radiobutton使用时必须写在创建前
            
            base.OnCreate(savedInstanceState);
            //百度地图设置
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            SDKInitializer.Initialize(ApplicationContext);

            MapClass.mMapView = new MapView(this);
            MapClass.mBaiduMap = MapClass.mMapView.Map;
            //设置地图类型
            MapClass.mBaiduMap.MapType = BaiduMap.MapTypeNormal;
            //设置初始放大多少，可以不设置
            MapClass.mBaiduMap.SetMapStatus(MapStatusUpdateFactory.NewMapStatus(new MapStatus.Builder()
            .Zoom(17)
            .Build()));

            //启动页
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

        }

        protected override void OnStart()//开始
        {
            base.OnStart();
        }
        protected override void OnStop()//结束
        {
            base.OnStop();
        }
        protected override void OnPause()//程序暂停
        {
            base.OnPause();
            RunStatus = false;
            compassTest.Stop();
            locMgr.RemoveUpdates(this);
            MapClass.mMapView.OnPause();

        }
        protected override void OnDestroy()//销毁生命周期
        {
            base.OnDestroy();
            MapClass.mMapView.OnDestroy();
        }
        protected override void OnResume()
        {
            MapClass.mMapView.OnResume();
            base.OnResume();
            RunStatus = true;
            //设置定位参数
            locMgr = GetSystemService(LocationService) as LocationManager;
            Criteria cri = new Criteria();
            //精确度
            cri.Accuracy = Accuracy.Fine;
            //耗能
            cri.PowerRequirement = Power.Low;
            //海拔精度
            cri.AltitudeRequired = false;
            cri.BearingRequired = false;
            //方向准确度
            cri.BearingAccuracy = Accuracy.Fine;
            //是否花费
            cri.CostAllowed = false;
            //水平方向精度
            cri.HorizontalAccuracy = Accuracy.Low;
            //速度精度
            cri.SpeedAccuracy = Accuracy.Low;
            //是否具备速度能力
            cri.SpeedRequired = false;
            //垂直方向精度
            cri.VerticalAccuracy = Accuracy.Low;
            var locationProvider = locMgr.GetBestProvider(cri, true);

            if (locationProvider != null)
            {
                locMgr.RequestLocationUpdates(locationProvider, 1000, 5, this);
            }
            else
            {
                Toast.MakeText(this, "未开启网络或GPS!", ToastLength.Long).Show();
            }

            compassTest.Start();
        }
        private void ConvertBaiduLatLng(Location location)//坐标转换函数方法
        {
            CurrentLocation = location;
            //这个是安卓定位后换算百度的地图经纬度，否则偏差蛮大的，换算后就差不多了
            CoordinateConverter converter = new CoordinateConverter()
                .From(CoordinateConverter.CoordType.Gps)
       .Coord(new LatLng(location.Latitude, location.Longitude));
            LatLng desLatLng = converter.Convert();
            //LatLng desLatLng=new LatLng(location.Latitude, location.Longitude);
            CurrentLocation.Latitude = desLatLng.Latitude;
            CurrentLocation.Longitude = desLatLng.Longitude;
        }

        public void OnLocationChanged(Location location)
        {
            if (!RunStatus)
                return;
            compassTest.Stop();
            ConvertBaiduLatLng(location);
            MapStatus mMapStatus = MapClass.mBaiduMap.MapStatus;
            //使地图移动到当前位置
            mMapStatus = new MapStatus.Builder()
                .Target(new LatLng(CurrentLocation.Latitude, CurrentLocation.Longitude))
                .Build();
            //定义MapStatusUpdate对象，以便描述地图状态将要发生的变化 
            MapStatusUpdate mMapStatusUpdate = MapStatusUpdateFactory.NewMapStatus(mMapStatus);
            //改变地图状态  
            MapClass.mBaiduMap.SetMapStatus(mMapStatusUpdate);
            //RefreshMap();
            compassTest.Start();
        }
        public static void RefreshMap()
        {
            MapClass.mBaiduMap.MyLocationEnabled = true;
            MyLocationData locData = new MyLocationData.Builder()
            .Accuracy(CurrentLocation.Accuracy)
            .Direction(CurrentLocation.Bearing).Latitude(MainActivity.CurrentLocation.Latitude)
            .Longitude(MainActivity.CurrentLocation.Longitude).Build();
            MapClass.mBaiduMap.SetMyLocationData(locData);
            MyLocationConfiguration confit = new MyLocationConfiguration(MyLocationConfiguration.LocationMode.Normal,
                true, null);
            MapClass.mBaiduMap.SetMyLocationConfiguration(confit);
        }
        private class CompassTest
        {
            public void Start()
            {
                if (Compass.IsMonitoring)
                    return;
                Compass.ReadingChanged += Compass_ReadingChanged;
                Compass.Start(SensorSpeed.UI);
            }

            public void Stop()
            {
                if (!Compass.IsMonitoring)
                    return;
                Compass.ReadingChanged -= Compass_ReadingChanged;
                Compass.Stop();
            }

            void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
            {
                if (CurrentLocation == null)
                    return;
                float bearing = (int)e.Reading.HeadingMagneticNorth;
                if (bearing == CurrentLocation.Bearing)
                    return;
                CurrentLocation.Bearing = bearing;
                RefreshMap();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        public void OnGetPoiIndoorResult(PoiIndoorResult p0)
        {
        }
        public void OnGetPoiResult(PoiResult p0)
        {
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
        }

        void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            if (CurrentLocation == null)
                return;
            float bearing = (int)e.Reading.HeadingMagneticNorth;
            if (bearing == CurrentLocation.Bearing)
                return;
            CurrentLocation.Bearing = bearing;
            RefreshMap();
        }
    }
}