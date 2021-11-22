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

        public PresetDetailsPageViewModel(IPresetService presetService)
        {
            _presetService = presetService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            var current = parameters.GetValue<Preset>("SelectedPreset");
        }
    }
}
