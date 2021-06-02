


using Android.Content;
using Com.Baidu.Mapapi.Map;
using FlyCarApp;
using FlyCarApp.Class;
using FlyCarApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ResultMapView), typeof(MapRenderer))]
namespace FlyCarApp.Droid
{
    public class MapRenderer : ViewRenderer<ResultMapView, MapView>
    {
        public MapRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<ResultMapView> e)
        {
            var view = MapClass.mMapView;
            SetNativeControl(view);
        }
        protected override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();
            MapClass.mMapView.RemoveFromParent();

        }
    }
}