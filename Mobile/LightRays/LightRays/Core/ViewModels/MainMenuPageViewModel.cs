using LightRays.Core.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LightRays.Core.ViewModels
{
    public class MainMenuPageViewModel : ViewModelPageBase
    {
        private Color _selectedColor;

        public Color SelectedColor { get => _selectedColor;  set => _selectedColor = value;  }
        public ICommand SendRequestCommand => new Command(SendRequest);

        public MainMenuPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        private void SendRequest()
        {
            var test = SelectedColor;
        }
    }
}
