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
        private string _leftColor = "#1d1d1d";
        private string _rightColor = "#1d1d1d";

        public MainPage()
        {
            InitializeComponent();
        }

        private void ColorPicker_PickedColorChanged(object sender, Color e)
        {
            string colorHex = e.ToHex();


        }

        private void ColorPickerKelvin_PickedColorChanged(object sender, Color e)
        {
            string colorHex = e.ToHex();

            if (!string.IsNullOrEmpty(colorHex))
            {
                _rightColor = colorHex;
                var colorModel = new ToolbarColorManager { LeftColor = Color.FromHex(_leftColor), RightColor = Color.FromHex(colorHex) };
                MessagingCenter.Send<object, object>(this, "ChangeToolbar", colorModel);
            }
        }
    }
}
