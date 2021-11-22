using Prism.Commands;
using Prism.Navigation;
using System;
using Xamarin.Essentials;

namespace LightRays.Core.ViewModels
{
    public class InfoPageViewModel : ViewModelPageBase
    {
        public DelegateCommand<string> TapCommand => new DelegateCommand<string>(async (url) => await Launcher.OpenAsync(url));
    }
}
