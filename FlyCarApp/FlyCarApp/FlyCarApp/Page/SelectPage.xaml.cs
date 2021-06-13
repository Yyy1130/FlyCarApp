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
    public partial class SelectPage : ContentPage
    {
        public SelectPage()
        {
            InitializeComponent();
        }

        private void amount_Clicked(object sender, EventArgs e)
        {
            var _show = DependencyService.Get<IMessageShow>();
            if (RecentUser.username==null)
            {
                _show.ShortAlert("未登录");
                return;
            }
            UserInfo user = new UserInfo();
            user.username = RecentUser.username;
            ResultInfo result = new ResultInfo();
            ClientFun client = new ClientFun("POST");
            result = (ResultInfo)client.PostFun("UserAmount", JsonConvert.SerializeObject(user));
            if (result.code != "0")
            {
                _show.ShortAlert(result.msg);
                return;
            }
            DisplayAlert("用户余额", "剩余："+ result.data.Rows[0]["useramount"].ToString()+"元", "确认");
            RecentUser.useramount = float.Parse(result.data.Rows[0]["useramount"].ToString());
        }

        private async void car_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CarList());
        }

        private async void check_ClickedAsync(object sender, EventArgs e)
        {
            var _show = DependencyService.Get<IMessageShow>();
            if (RecentUser.username == null)
            {
                _show.ShortAlert("未登录");
                return;
            }
            bool jugdge = await DisplayAlert("提示", "是否已到达目的地，确认付款", "确认", "取消");
            if (!jugdge)
            {
                return;
            }
            UserInfo user = new UserInfo();
            user.username = RecentUser.username;
            user.useramount = 50;//之后改为对应的计费公式
            ResultInfo result = new ResultInfo();
            ClientFun client = new ClientFun("POST");
            result = (ResultInfo)client.PostFun("Cararrive", JsonConvert.SerializeObject(user));
            if (result.code != "0")
            {
                _ = DisplayAlert("错误代码:" + result.code, result.msg, "确认");
                return;
            }
            _ = DisplayAlert("结算提示", "本次乘坐一共花费：" + user.useramount.ToString() + "元\n"+result.msg, "确认");
        }
    }
}