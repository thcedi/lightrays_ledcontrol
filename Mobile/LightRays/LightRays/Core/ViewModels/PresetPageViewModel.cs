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
        private Preset _selectedPreset;

        private readonly IPresetService _presetService;

        public Preset SelectedPreset { get => _selectedPreset; set => SetProperty(ref _selectedPreset, value); }

        public ObservableCollection<Preset> Presets { get => _presets; set => SetProperty(ref _presets, value); }

        public DelegateCommand NavigateToDetailsCommand { get; set; }

        public PresetPageViewModel(IPresetService presetService)
        {
            _presetService = presetService;

            NavigateToDetailsCommand = new DelegateCommand(NavigateToDetails);

            var mockData = new List<Preset>()
            {
                new Preset() { Id = 1, Name = "Test", Color1 = Color.Purple.ToHex(), Color2 = Color.Blue.ToHex(), Color3 = Color.Aquamarine.ToHex() },
                new Preset() { Id = 2, Name = "Test1", Color1 = Color.Yellow.ToHex(), Color2 = Color.Orange.ToHex(), Color3 = Color.Red.ToHex() }
            };

            Presets = new ObservableCollection<Preset>(mockData);
        }

        private async void NavigateToDetails()
        {
            await NavigationService.NavigateAsync("PresetDetailsPage", new NavigationParameters() { { "SelectedPreset", SelectedPreset } });
        }
    }
}
