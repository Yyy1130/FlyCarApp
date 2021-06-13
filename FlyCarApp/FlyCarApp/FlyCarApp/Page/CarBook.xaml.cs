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
    public partial class CarBook : ContentPage
    {
        public CarBook()
        {
            InitializeComponent();
            target.Title = "目的地";
            ResultInfo result = new ResultInfo();
            ClientFun client = new ClientFun("POST");
            result = (ResultInfo)client.PostFun("CarParkGet","{}");
            if (result.code != "0")
            {
                var _show = DependencyService.Get<IMessageShow>();
                _show.ShortAlert("错误代码:" + result.code + result.msg);
                return;
            }
            foreach(DataRow datarow in result.data.Rows)
            {
                target.Items.Add(datarow["cpid"].ToString()+"."+ datarow["cpname"].ToString());
            }
            carno.Title = "飞的号";
            result = (ResultInfo)client.PostFun("CarGet", "{}");
            if (result.code != "0")
            {
                var _show = DependencyService.Get<IMessageShow>();
                _show.ShortAlert("错误代码:" + result.code + result.msg);
                return;
            }
            foreach (DataRow datarow in result.data.Rows)
            {
                carno.Items.Add(datarow["carno"].ToString());
            }
            if (RecentCar.carno != null)
                carno.SelectedItem = RecentCar.carno;
        }

        private async void Book_ClickedAsync(object sender, EventArgs e)
        {
            var _show = DependencyService.Get<IMessageShow>();
            if (RecentUser.username==null)
            {
                _show.ShortAlert("未登录");
                return;
            }
            if (username.Text == "" || carno.SelectedItem == null || target.SelectedItem == null)
            {
                _show.ShortAlert("必填项为空");
                return;
            }
            bool jugdge = await DisplayAlert("提示", "是否要预约飞的", "确认", "取消");
            if (!jugdge)
            {
                return;
            }
            User_CarInfo user_Car = new User_CarInfo();
            UserInfo user = new UserInfo();
            user.username = username.Text;//这里为预约，所以成功后会将status从"空闲"改为"用户名"
            user.useramount = 0;
            user_Car.UserInfo = user;
            CarInfo car = new CarInfo();
            car.carno= carno.SelectedItem.ToString();
            car.targetid = int.Parse(target.SelectedItem.ToString().Substring(0,1));
            user_Car.CarInfo = car;
            ResultInfo result = new ResultInfo();
            ClientFun client = new ClientFun("POST");
            result = (ResultInfo)client.PostFun("CarBook", JsonConvert.SerializeObject(user_Car));
            if (result.code != "0")
            {
                _ = DisplayAlert("错误代码:" + result.code, result.msg, "确认");
                return;
            }
            RecentCar.carno = carno.SelectedItem.ToString();
            _ = DisplayAlert("订单提示", "用户："+RecentUser.username+"\n飞的号："+ carno.SelectedItem.ToString() +"\n目的地："+ target.SelectedItem.ToString() + "\n"+ result.msg, "确认");
        }

        private async void Cancel_ClickedAsync(object sender, EventArgs e)
        {
            var _show = DependencyService.Get<IMessageShow>();
            if (RecentUser.username == null)
            {
                _show.ShortAlert("未登录");
                return;
            }
            bool jugdge = await DisplayAlert("提示", "是否要取消预约", "确认", "取消");
            if (!jugdge)
            {
                return;
            }
            UserInfo user = new UserInfo();
            user.username = RecentUser.username;//这里为取消，所以成功后会将status从"用户名"改为"空闲"
            user.useramount = 0;
            ResultInfo result = new ResultInfo();
            ClientFun client = new ClientFun("POST");
            result = (ResultInfo)client.PostFun("CancelBook", JsonConvert.SerializeObject(user));
            if (result.code != "0")
            {
                _ = DisplayAlert("错误代码:" + result.code, result.msg, "确认");
                return;
            }
            _ = DisplayAlert("提示", result.msg, "确认");
        }

        protected override void OnAppearing()
        {
            username.Text = RecentUser.username;
            if (RecentCar.carno != null)
                carno.SelectedItem = RecentCar.carno;
            base.OnAppearing();
        }
    }
}