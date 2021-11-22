using LightRays.Core.Services;
using LightRays.Core.Services.PresetService;
using LightRays.Core.ViewModels;
using LightRays.Core.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LightRays.Core
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("MyMasterDetail/GradientHeaderNavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDialogService, DialogService>();
            containerRegistry.RegisterSingleton<IRequestService, RequestServiceWeb>();
            containerRegistry.RegisterSingleton<IDatabaseService, DatabaseServiceSQLite>();
            containerRegistry.RegisterSingleton<IPresetService, PresetService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MyMasterDetail>();
            containerRegistry.RegisterForNavigation<GradientHeaderNavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<InfoPage, InfoPageViewModel>();
            containerRegistry.RegisterForNavigation<PresetPage, PresetPageViewModel>();
            containerRegistry.RegisterForNavigation<PresetDetailsPage, PresetDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
        }
    }
}
