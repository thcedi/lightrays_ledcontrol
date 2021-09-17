using System.Collections.Generic;
using System.Collections.ObjectModel;
using LightRays.Core.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace LightRays.Core.ViewModels
{
    public class MyMasterDetailViewModel : BindableBase
    {
        private List<MainMenuItem> _menuItems;
        private bool _isPresented;
        private ObservableCollection<MainMenuItem> _mainMenuItems = new ObservableCollection<MainMenuItem>();

        private INavigationService _navigationService { get; }

        public ObservableCollection<MainMenuItem> MainMenuItems { get => _mainMenuItems; set => SetProperty(ref _mainMenuItems, value); }
        public bool IsPresented { get => _isPresented; set => SetProperty(ref _isPresented, value); }
        public DelegateCommand<MainMenuItem> MainMenuItemTappedCommand { get; }

        public MyMasterDetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            MainMenuItemTappedCommand = new DelegateCommand<MainMenuItem>(OnMainMenuItemTapped);

            if (_menuItems == null)
            {
                _menuItems = new List<MainMenuItem>
                {
                    new MainMenuItem { Id = 0, Title = "Controller", Target = "MyMasterDetail/GradientHeaderNavigationPage/MainPage" },
                    new MainMenuItem { Id = 1, Title = "Presets", Target = "MyMasterDetail/GradientHeaderNavigationPage/PresetPage" },
                    new MainMenuItem { Id = 2, Title = "Settings", Target = "MyMasterDetail/GradientHeaderNavigationPage/SettingsPage" },
                    new MainMenuItem { Id = 3, Title = "Info", Target = "MyMasterDetail/GradientHeaderNavigationPage/InfoPage" }
                    //new MainMenuItem { Id = 4, Title = "Abmelden", Target = "LOGOUT" }
                };
            }

            RefreshMainMenuItems();
            RefreshSelection();
        }

        private void RefreshMainMenuItems()
        {
            ObservableCollection<MainMenuItem> result = new ObservableCollection<MainMenuItem>();
            foreach (var menuItem in _menuItems)
            {
                var parentMenuItem = _menuItems.Find(m => m.Id == menuItem.ParentId);
                if (parentMenuItem == null)
                {
                    result.Add(menuItem);
                }
                else if (parentMenuItem?.ShowChilds == true)
                {
                    result.Add(menuItem);
                }
            }

            MainMenuItems = result;
        }

        private async void OnMainMenuItemTapped(MainMenuItem menuItem)
        {
            if (menuItem.HasChilds)
            {
                var index = _menuItems.IndexOf(menuItem);
                _menuItems[index].ShowChilds = !menuItem.ShowChilds;
                RefreshMainMenuItems();
            }
            else if (menuItem.Target == "LOGOUT")
            {
                await _navigationService.GoBackAsync();
            }
            else if(Settings.CurrentView == menuItem.Target)
            {
                IsPresented = false;
                return;
            }
            else
            {
                Settings.CurrentView = menuItem.Target;
                RefreshSelection();
                await _navigationService.NavigateAsync(menuItem.Target);
            }
        }

        private void RefreshSelection()
        {
            var items = MainMenuItems;
            foreach (MainMenuItem item in items)
            {
                if (item.Target == Settings.CurrentView)
                {
                    item.IsSelected = true;
                }
                else
                {
                    item.IsSelected = false;
                }
            }

            MainMenuItems = new ObservableCollection<MainMenuItem>(items);
        }
    }
}