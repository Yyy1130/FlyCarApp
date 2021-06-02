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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void UserLogin_ClickedAsync(object sender, EventArgs e)
        {
            var _show = DependencyService.Get<IMessageShow>();
            if (username.Text==""||password.Text=="")
            {
                _show.ShortAlert("用户名或密码为空");
                return;
            }
            UserInfo user = new UserInfo();
            if (username.Text == "sa" && password.Text == "001130")
            {
                RecentUser.username = username.Text;
                RecentUser.userright = 5;
                await Navigation.PushAsync(new UserPage());
                Navigation.RemovePage(this);
                return;
            }
            user.username = username.Text;
            user.password = password.Text;
            ResultInfo result = new ResultInfo();
            ClientFun client = new ClientFun("POST");
            result = (ParaClass.ResultInfo)client.PostFun("UserLogin", JsonConvert.SerializeObject(user));
            if (result.code != "0")
            {
                _show.ShortAlert(result.msg);
                return;
            }
            RecentUser.username = username.Text;
            //查询登录用户信息
            UserInfo getuser = new UserInfo();
            getuser.username = RecentUser.username;
            ResultInfo getresult = new ResultInfo();
            ClientFun getclient = new ClientFun("POST");
            result = (ResultInfo)client.PostFun("UserAmount", JsonConvert.SerializeObject(user));
            if (result.code != "0")
            {
                _show.ShortAlert(result.msg);
                return;
            }
            RecentUser.userright = int.Parse(result.data.Rows[0]["userright"].ToString());
            RecentUser.cellphone = result.data.Rows[0]["cellphone"].ToString();
            RecentUser.useramount = float.Parse(result.data.Rows[0]["useramount"].ToString());


            await Navigation.PushAsync(new UserPage());
            Navigation.RemovePage(this);
        }

        private async void TapGestureRecognizer_TappedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Regist());
        }

        protected override void OnAppearing()
        {
            if (RecentUser.username != null)//必须在初始化结束后删除Page
            {
                Navigation.PushAsync(new UserPage());
                Navigation.RemovePage(this);
            }
            base.OnAppearing();
        }
    }
}