using FlyCarApp.Class;
using FlyCarApp.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlyCarApp.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Regist : ContentPage
    {
        public Regist()
        {
            InitializeComponent();
        }

        private async void UserRegist_ClickedAsync(object sender, EventArgs e)
        {
            var _show = DependencyService.Get<IMessageShow>();
            ParaClass.ResultInfo result = new ParaClass.ResultInfo();
            if (username.Text == "" || password.Text == ""|| phone.Text == "")
            {
                _show.ShortAlert("必填信息为空");
                return;
            }
            if (phone.Text.Length!=11)
            {
                _show.ShortAlert("请输入正确的手机号");
                return;
            }
            if (!IsNumeric(phone.Text))
            {
                _show.ShortAlert("请输入正确的手机号");
                return;
            }
            if (password.Text != checkpassword.Text)
            {
                checkpassword.Text = "";
                _show.ShortAlert("两次密码输入不同，请重新输入");
                return;
            }
            ParaClass.UserInfo user = new ParaClass.UserInfo();
            user.username = username.Text;
            user.password = password.Text;
            user.cellphone = phone.Text;
            ClientFun client = new ClientFun("POST");
            result = (ParaClass.ResultInfo)client.PostFun("UserRegist", JsonConvert.SerializeObject(user));
            if (result.code != "0")
            {
                _ = DisplayAlert("错误代码:" + result.code, "错误信息:" + result.msg, "确认");
                return;
            }
            await Navigation.PopAsync();
        }

        private static bool IsNumeric(string value)
        {
            for(int i=0;i<value.Length;i++)
            {
                if (value[i] < '0' || value[i] > '9')
                    return false;
            }
            return true;
        }

    }
}