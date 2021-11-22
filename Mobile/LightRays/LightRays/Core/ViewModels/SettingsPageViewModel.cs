using Prism.Commands;
using Prism.Navigation;
using System;

namespace LightRays.Core.ViewModels
{
    public class SettingsPageViewModel : ViewModelPageBase
    {
        private string _uri;

        public string URI { get => _uri; set => SetProperty(ref _uri, value); }

        public DelegateCommand ApiUriChangedCommand { get; set; }

        public SettingsPageViewModel()
        {
            URI = Settings.Uri;
            ApiUriChangedCommand = new DelegateCommand(ApiUriChanged);
        }

        private void ApiUriChanged()
        {
            Settings.Uri = URI;
        }
    }
}
