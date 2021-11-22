using LightRays.Core.Models;
using LightRays.Core.Services;
using LightRays.Core.Services.PresetService;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Xamarin.Forms;

namespace LightRays.Core.ViewModels
{
    public class PresetPageViewModel : ViewModelPageBase
    {
        private ObservableCollection<Preset> _presets;
        private Preset _selectedPreset;

        private readonly IPresetService _presetService;
        private readonly IRequestService _requestService;

        public Preset SelectedPreset { get => _selectedPreset; set => SetProperty(ref _selectedPreset, value); }

        public ObservableCollection<Preset> Presets { get => _presets; set => SetProperty(ref _presets, value); }

        public DelegateCommand DeletePresetCommand { get; set; }
        public DelegateCommand AddPresetCommand { get; set; }
        public DelegateCommand EditPresetCommand { get; set; }
        public DelegateCommand ApplyPresetCommand { get; set; }

        public PresetPageViewModel(IPresetService presetService, IRequestService requestService)
        {
            _presetService = presetService;
            _requestService = requestService;

            DeletePresetCommand = new DelegateCommand(DeletePreset);
            AddPresetCommand = new DelegateCommand(AddPreset);
            EditPresetCommand = new DelegateCommand(EditPreset);
            ApplyPresetCommand = new DelegateCommand(ApplyPreset);
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            var data = await _presetService.Read();
            Presets = new ObservableCollection<Preset>(data);
        }

        private async void ApplyPreset()
        {
            if (SelectedPreset == null) return;

            var colors = new List<string>() { SelectedPreset.Color1, SelectedPreset.Color2, SelectedPreset.Color3 };

            for(int i = 0; i < colors.Count; i++)
            {
                var colorHex = colors[i];
                var colorTuple = HexToColor(colorHex);
                var requestString = string.Format("{0}{1}{2}{3}", i + 1, colorTuple.Item1.ToString().PadLeft(3, '0'), colorTuple.Item2.ToString().PadLeft(3, '0'), colorTuple.Item3.ToString().PadLeft(3, '0'));
                await _requestService.GetRequest(Settings.Uri, requestString);
                await System.Threading.Tasks.Task.Delay(1000);
            }
        }

        private async void AddPreset()
        {
            await NavigationService.NavigateAsync("PresetDetailsPage");
        }

        private async void EditPreset()
        {
            if (SelectedPreset == null) return;

            await NavigationService.NavigateAsync("PresetDetailsPage", new NavigationParameters() { { "SelectedPreset", SelectedPreset } });
        }

        private async void DeletePreset()
        {
            if (SelectedPreset == null) return;

            await _presetService.Delete(SelectedPreset);
            Presets = new ObservableCollection<Preset>(Presets);
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
