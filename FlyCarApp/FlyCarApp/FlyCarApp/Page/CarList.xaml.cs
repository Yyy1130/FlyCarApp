using FlyCarApp.Class;
using FlyCarApp.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FlyCarApp.Class.ParaClass;

namespace FlyCarApp.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarList : ContentPage
    {
        public CarList()
        {
            InitializeComponent();
            ClientFun client = new ClientFun("POST");
            ResultInfo result = (ResultInfo)client.PostFun("CarGet", "{}");
            if (result.code != "0")
            {
                DisplayAlert("错误代码:"+result.code, result.msg, "确认");
                return;
            }
            List<CarInfo> carInfos = new List<CarInfo>();
            foreach (DataRow dataRow in result.data.Rows)
            {
                CarInfo carInfo = new CarInfo();
                carInfo.carno = dataRow["carno"].ToString();
                if (dataRow["status"].ToString() != "空闲")
                    carInfo.status = "接送中";
                else
                    carInfo.status = dataRow["status"].ToString();
                carInfo.cpid = int.Parse(dataRow["cpid"].ToString());
                carInfos.Add(carInfo);
            }
            ListView.ItemsSource = carInfos;
        }

        private async void book_ClickedAsync(object sender, EventArgs e)
        {
            var _show = DependencyService.Get<IMessageShow>();
            CarInfo test = (CarInfo)ListView.SelectedItem;
            if (RecentUser.username == null)
            {
                _show.ShortAlert("未登录");
                return;
            }
            if (test == null)
            {
                _show.ShortAlert("未选择飞的");
                return;
            }
            if (test.status !="空闲")
            {
                _show.ShortAlert("预约的飞的已被下单");
                return;
            }
            RecentCar.carno = test.carno;
            await Navigation.PushAsync(new CarBook());
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            ClientFun client = new ClientFun("POST");
            ResultInfo result = (ResultInfo)client.PostFun("CarGet", "{}");
            if (result.code != "0")
            {
                DisplayAlert("错误代码:" + result.code, result.msg, "确认");
                return;
            }
            List<CarInfo> carInfos = new List<CarInfo>();
            foreach (DataRow dataRow in result.data.Rows)
            {
                CarInfo carInfo = new CarInfo();
                carInfo.carno = dataRow["carno"].ToString();
                if (dataRow["status"].ToString() != "空闲")
                    carInfo.status = "接送中";
                else
                    carInfo.status = dataRow["status"].ToString();
                carInfo.cpid = int.Parse(dataRow["cpid"].ToString());
                carInfos.Add(carInfo);
            }
            ListView.ItemsSource = carInfos;
            ListView.IsRefreshing = false;
        }
    }
}