using LightRays.Core.Services;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;
using System.Threading.Tasks;


namespace LightRays.Core.ViewModels
{
    public class ViewModelPageBase : BindableBase, INavigationAware
    {
        protected readonly INavigationService NavigationService;
        protected readonly IDialogService DialogService;
        protected readonly IPlatform Platform;

        private bool _isBusy;
        private string _title;

        public string Title { get => _title; set => SetProperty(ref _title, value); }
        public bool IsBusy { get => _isBusy; set => SetProperty(ref _isBusy, value, () => { RaisePropertyChanged(nameof(IsNotBusy)); ChangeBusyState(value); }); }
        public bool IsNotBusy { get => !IsBusy; }

        protected ViewModelPageBase(INavigationService navigationService)
        {
            var container = ((Prism.PrismApplicationBase)Xamarin.Forms.Application.Current).Container;
            NavigationService = navigationService;
            DialogService = container.Resolve<IDialogService>();
            //Platform = container.Resolve<IPlatform>();
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        public virtual void OnNavigatedTo(INavigationParameters parameters) { }

        public virtual void OnNavigatingTo(INavigationParameters parameters) { }

        public virtual void Destroy() { }

#pragma warning disable CS1998
        public virtual async Task<bool> CanNavigateAsync(INavigationParameters parameters)
        {
            return true;
        }
#pragma warning restore CS1998

        private void ChangeBusyState(bool value)
        {
            if (value) DialogService.ShowLoading("Daten werden geladen...");
            else DialogService.HideLoading();
        }
    }
}