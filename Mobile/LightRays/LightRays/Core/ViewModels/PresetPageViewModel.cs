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
    public class PresetPageViewModel : ViewModelPageBase
    {
        private ObservableCollection<Preset> _presets;

        private readonly IPresetService _presetService;

        public ObservableCollection<Preset> Presets { get => _presets; set => SetProperty(ref _presets, value); }

        public PresetPageViewModel(INavigationService navigationService, IPresetService presetService) : base(navigationService)
        {
            _presetService = presetService;

            var mockData = new List<Preset>()
            {
                new Preset() { Id = 1, Name = "Test", Color1 = Color.Purple.ToHex(), Color2 = Color.Blue.ToHex(), Color3 = Color.Aquamarine.ToHex() },
                new Preset() { Id = 2, Name = "Test1", Color1 = Color.Yellow.ToHex(), Color2 = Color.Orange.ToHex(), Color3 = Color.Red.ToHex() }
            };

            Presets = new ObservableCollection<Preset>(mockData);
        }
    }
}
