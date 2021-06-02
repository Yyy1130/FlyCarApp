using FlyCarApp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using static FlyCarApp.Class.ParaClass;

namespace FlyCarApp.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarParkMap : ContentPage
    {
        public CarParkMap()
        {
            InitializeComponent();
        }


        protected override void OnDisappearing()
        {
        }
    }
}