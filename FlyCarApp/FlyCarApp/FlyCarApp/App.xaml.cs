using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FlyCarApp.Page;
using FlyCarApp.Class;
using FlyCarApp.Interface;

namespace FlyCarApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ClientFun client = new ClientFun("GET");
            if (client.TestConnect("http://47.96.26.86:20003/") == "success")
                Current.MainPage = new MainShow();
            else
                Current.MainPage = new Connect();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }
}
