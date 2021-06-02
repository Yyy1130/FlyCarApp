using FlyCarApp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlyCarApp.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Connect : ContentPage
    {
        public Connect()
        {
            InitializeComponent();
        }

        private void SetUrl_Clicked(object sender, EventArgs e)
        {
            ClientFun client = new ClientFun("GET");
            string message = client.TestConnect(urladdress.Text);
            if (message == "success")
                Application.Current.MainPage = new NavigationPage(new Login());
            else
                DisplayAlert("提示", "错误信息:"+message, "确认");
        }
    }
}