using LightRays.Core.Helper;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.ComponentModel;
using Xamarin.Forms;

namespace LightRays.Core.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Device.BeginInvokeOnMainThread(async () => 
            {
                containerColorPicker.Opacity = 0;
                await containerColorPicker.FadeTo(1, 500);
            });
        }
    }
}
