using FlyCarApp.Class;
using FlyCarApp.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FlyCarApp.Class.ParaClass;

namespace FlyCarApp.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Recharge : ContentPage
    {
        public Recharge()
        {
            InitializeComponent();
            username.Text = RecentUser.username;
        }

        private async void UserRecharge_ClickedAsync(object sender, EventArgs e)
        {
            var _show = DependencyService.Get<IMessageShow>();
            if (username.Text == "" || money.Text == "")
            {
                _show.ShortAlert("必填项为空");
                return;
            }
            if(money.Text.Length>=10)
            {
                _show.ShortAlert("充值金额过大，请重新输入");
                money.Text = "0";
                return;
            }
            if(float.Parse(money.Text)<=0.00)
            {
                _show.ShortAlert("充值金额错误");
                money.Text = "0";
                return;
            }
            bool jugdge = await DisplayAlert("提示", "是否要对用户"+ username.Text + "进行充值", "确认", "取消");
            if (!jugdge)
            {
                return;
            }
            UserInfo user = new UserInfo();
            user.username = username.Text;
            user.useramount = float.Parse(money.Text);
            ResultInfo result = new ResultInfo();
            ClientFun client = new ClientFun("POST");
            result = (ResultInfo)client.PostFun("UserRecharge", JsonConvert.SerializeObject(user));
            if (result.code != "0")
            {
                _ = DisplayAlert("错误代码:" + result.code, "错误信息:" + result.msg, "确认");
                return;
            }
            _ = DisplayAlert("提示", result.msg, "确认");
            await Navigation.PopToRootAsync();
        }

        private async void Right_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VipRight());
        }
    }
}