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
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
            name.Text = RecentUser.username;
            vip.Text = RecentUser.userright.ToString();
            phone.Text = RecentUser.cellphone;
        }

        private async void change_ClickedAsync(object sender, EventArgs e)
        {
            rebuild();
            await Navigation.PushAsync(new Login());
            Navigation.RemovePage(this);
        }

        private async void recharge_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Recharge());
        }
    }
}