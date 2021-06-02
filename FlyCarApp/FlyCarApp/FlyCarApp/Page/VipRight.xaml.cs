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
	public partial class VipRight : ContentPage
	{
		public VipRight ()
		{
			InitializeComponent ();
            username.Text = RecentUser.username;
            v1.Text = "等级一权益\n预约费减少10%";
            v2.Text = "等级二权益\n预约费减少25%\n送小礼品一份";
            v3.Text = "等级三权益\n预约费减少50%\n送小礼品一份\n各平台视频会员一个月";
        }

        private async void Vip_Clicked(object sender, EventArgs e)
        {
			if(username.Text=="")
            {
                var _show = DependencyService.Get<IMessageShow>();
                _show.ShortAlert("用户名为空");
				return;
            }
            bool jugdge = await DisplayAlert("提示", "是否要为用户" + username.Text + "开通Vip", "确认", "取消");
            if (!jugdge)
            {
                return;
            }
            ParaClass.UserInfo user = new ParaClass.UserInfo();
            user.username = username.Text;
            user.useramount = float.Parse(one.Text);
            user.userright = 1;
            if(two.IsChecked)
            {
                user.useramount = float.Parse(two.Text);
                user.userright = 2;
            }
            if(three.IsChecked)
            {
                user.useramount = float.Parse(three.Text);
                user.userright = 3;
            }
            ParaClass.ResultInfo result = new ParaClass.ResultInfo();
            ClientFun client = new ClientFun("POST");
            result = (ParaClass.ResultInfo)client.PostFun("UserRight", JsonConvert.SerializeObject(user));
            if (result.code != "0")
            {
                _ = DisplayAlert("错误代码:" + result.code, "错误信息:" + result.msg, "确认");
                return;
            }
            _ = DisplayAlert("提示", result.msg, "确认");
            await Navigation.PopToRootAsync();
        }
    }
}