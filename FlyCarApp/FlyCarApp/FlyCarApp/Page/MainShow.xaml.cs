using FlyCarApp.Interface;
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
    public partial class MainShow : TabbedPage
    {
        public MainShow()
        {
            InitializeComponent();
        }

        /*protected override bool OnBackButtonPressed()//退出确认
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await DisplayAlert("提示", "是否退出程序", "确认", "取消");
                if (result)
                {
                    var _show = DependencyService.Get<ICloseApp>();
                    _show.Close();
                }
            });
            return true;
        }*/
    }
}