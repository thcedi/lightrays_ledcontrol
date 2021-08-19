using ColorPicker;
using LightRays.Core.Models;
using LightRays.Core.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LightRays.Core.ViewModels
{
    public class MainPageViewModel : ViewModelPageBase
    {
        private List<string> _zones;
        private string _zone;
        private List<string> _effects;
        private string _effect;

        private string _uri = "192.168.0.72";

        private IRequestService _requestService;

        public List<string> Zones { get => _zones; set => SetProperty(ref _zones, value); }
        public string Zone { get => _zone; set => SetProperty(ref _zone, value); }
        public List<string> Effects { get => _effects; set => SetProperty(ref _effects, value); }
        public string Effect { get => _effect; set => SetProperty(ref _effect, value); }

        public ICommand SendRequestCommand => new Command<object>(SendRequest);

        public MainPageViewModel(INavigationService navigationService, IRequestService requestService) : base(navigationService)
        {
            Zones = new List<string>() { "0", "1", "2", "3" };
            Effects = new List<string>() {  "Single color", "1", "2" };

            _requestService = requestService;
        }

        private async void SendRequest(object e)
        {
            if (string.IsNullOrEmpty(Zone) || string.IsNullOrEmpty(Effect)) return;

            if(Effect == "Single color")
            {
                var colorHex = ((ColorWheel)e).SelectedColor.ToHex();
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
