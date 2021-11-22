using Acr.UserDialogs;
using LightRays.Core.Helper;
using LightRays.Core.Models;
using LightRays.Core.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LightRays.Core.ViewModels
{
    public class MainPageViewModel : ViewModelPageBase
    {
        private string _zone;
        private string _effect;
        private Color _selectedColor = Color.FromHex("#1d1d1d");
        private Color _selectedKelvin = Color.FromHex("#1d1d1d");
        private bool _useKelvinScale = false;
        private string _uri = Settings.Uri;

        private IRequestService _requestService;
        private IDatabaseService _databaseService;

        public string Zone { get => _zone; set => SetProperty(ref _zone, value); }
        public string Effect { get => _effect; set => SetProperty(ref _effect, value); }
        public Color SelectedColor { get => _selectedColor; set => SetProperty(ref _selectedColor, value); }
        public Color SelectedKelvin { get => _selectedKelvin; set => SetProperty(ref _selectedKelvin, value); }
        public bool UseKelvinScale { get => _useKelvinScale; set => SetProperty(ref _useKelvinScale, value); }

        public DelegateCommand SendRequestCommand { get; set; }
        public DelegateCommand ChangeZoneCommand { get; set; }
        public DelegateCommand ChangeEffectCommand { get; set; }
        public DelegateCommand UseKelvinScaleCommand { get; set; }
        public DelegateCommand<object> PickedColorChangedCommand { get; set; }
        public DelegateCommand TurnOffCommand { get; set; }

        public MainPageViewModel(IRequestService requestService, IDatabaseService databaseService)
        {
            _requestService = requestService;
            _databaseService = databaseService;
            SendRequestCommand = new DelegateCommand(SendRequest);
            ChangeZoneCommand = new DelegateCommand(ChangeZone);
            ChangeEffectCommand = new DelegateCommand(ChangeEffect);
            UseKelvinScaleCommand = new DelegateCommand(ChangeUseKelvinScale);
            PickedColorChangedCommand = new DelegateCommand<object>(PickedColorChanged);
            TurnOffCommand = new DelegateCommand(TurnOff);
        }

        private async void TurnOff()
        {
            await _requestService.GetRequest(_uri, "0000000000");
        }

        private void PickedColorChanged(object e)
        {
            var color = ((Udara.Plugin.XFColorPickerControl.ColorPicker)e).PickedColor;

            if (!UseKelvinScale) SelectedColor = color;
            else SelectedKelvin = color;

            ChangeToolbar();
        }

        private async void ChangeEffect()
        {
            var searchCrit = new List<ActionSheetOption>
            {
                new ActionSheetOption("Single Color", () => Effect = "Single color"),
                new ActionSheetOption("Rainbow", () => Effect = "1"),
                new ActionSheetOption("Fade", () => Effect = "2")
            };

            await Task.Run(() => DialogService.ShowActionSheet(new ActionSheetConfig() { Title = "Effekt wählen", Options = searchCrit }));
        }

        private void ChangeUseKelvinScale()
        {
            UseKelvinScale = !UseKelvinScale;
        }

        private async void ChangeZone()
        {
            var searchCrit = new List<ActionSheetOption>
            {
                new ActionSheetOption("Sync", () => Zone = "0"),
                new ActionSheetOption("1", () => Zone = "1"),
                new ActionSheetOption("2", () => Zone = "2"),
                new ActionSheetOption("3", () => Zone = "3")
            };

            await Task.Run(() => DialogService.ShowActionSheet(new ActionSheetConfig() { Title = "Zone wählen", Options = searchCrit }));
        }

        private void ChangeToolbar()
        {
            if (!string.IsNullOrEmpty(SelectedKelvin.ToHex()) && !string.IsNullOrEmpty(SelectedColor.ToHex()))
            {
                var colorModel = new ToolbarColorManager { LeftColor = SelectedColor, RightColor = SelectedKelvin };
                MessagingCenter.Send<object, object>(this, "ChangeToolbar", colorModel);
            }
        }

        private async void SendRequest()
        {
            if (string.IsNullOrEmpty(Zone) || string.IsNullOrEmpty(Effect)) return;

            if(Effect == "Single color")
            {
                var colorHex = UseKelvinScale ? SelectedKelvin.ToHex() : SelectedColor.ToHex();
                var colorTuple = HexToColor(colorHex);
                var requestString = string.Format("{0}{1}{2}{3}", Zone, colorTuple.Item1.ToString().PadLeft(3, '0'), colorTuple.Item2.ToString().PadLeft(3, '0'), colorTuple.Item3.ToString().PadLeft(3, '0'));
                await _requestService.GetRequest(_uri, requestString);
            }
            else
            {
                await _requestService.GetRequest(_uri, string.Format("{0}{1}", Zone, Effect));
            }
        }

        public Tuple<int, int, int> HexToColor(string hexColor)
        {
            //Remove # if present
            if (hexColor.IndexOf('#') != -1)
                hexColor = hexColor.Replace("#", "");

            if (hexColor.Length == 8)
                hexColor = hexColor.Remove(0, 2);

            int red = 0;
            int green = 0;
            int blue = 0;

            //#RRGGBB
            red = int.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            green = int.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            blue = int.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier);

            return new Tuple<int, int, int>(red, green, blue);
        }
    }
}
