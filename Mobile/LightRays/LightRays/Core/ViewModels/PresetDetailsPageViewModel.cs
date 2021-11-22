using LightRays.Core.Models;
using LightRays.Core.Services.PresetService;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace LightRays.Core.ViewModels
{
    public class PresetDetailsPageViewModel : ViewModelPageBase
    {
        private readonly IPresetService _presetService;
        
        private Preset _preset;
        private string _colorToChange;
        private bool _edit = true;

        public Preset Preset { get => _preset; set => SetProperty(ref _preset, value); }

        public DelegateCommand<object> PickedColorChangedCommand { get; set; }
        public DelegateCommand<object> ColorFrameTappedCommand { get; set; }
        public DelegateCommand<object> SaveChangesCommand { get; set; }

        public PresetDetailsPageViewModel(IPresetService presetService)
        {
            _presetService = presetService;

            PickedColorChangedCommand = new DelegateCommand<object>(PickedColorChanged);
            ColorFrameTappedCommand = new DelegateCommand<object>(SelectColorToEdit);
            SaveChangesCommand = new DelegateCommand<object>(SaveChanges);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            Preset = parameters.GetValue<Preset>("SelectedPreset");
            Title = "Edit";

            // Create new preset
            if (Preset == null)
            {
                Preset = new Preset();
                Title = "Add";
                _edit = false;
            }
        }

        private void PickedColorChanged(object e)
        {
            var color = ((Udara.Plugin.XFColorPickerControl.ColorPicker)e).PickedColor;

            switch(_colorToChange)
            {
                case "1":
                    Preset.Color1 = color.ToHex();
                    break;
                case "2":
                    Preset.Color2 = color.ToHex();
                    break;
                case "3":
                    Preset.Color3 = color.ToHex();
                    break;
            }
        }

        private void SelectColorToEdit(object colorID)
        {
            _colorToChange = (string)colorID;
        }

        private async void SaveChanges(object obj)
        {
            if (_edit) await _presetService.Update(Preset);
            else await _presetService.Create(Preset);

            await NavigationService.GoBackAsync();
        }
    }
}
