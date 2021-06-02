using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FlyCarApp.Droid;
using FlyCarApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[assembly: Xamarin.Forms.Dependency(typeof(CloseApp))]
[assembly: Xamarin.Forms.Dependency(typeof(FlyCarApp.Droid.Message))]
namespace FlyCarApp.Droid
{
    class CloseApp : ICloseApp
    {
        public void Close()
        {
            Process.KillProcess(Process.MyPid());
        }
    }

    class Message : IMessageShow
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }
        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}