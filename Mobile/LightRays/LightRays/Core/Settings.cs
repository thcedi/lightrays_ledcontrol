using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace LightRays.Core
{
    public static class Settings
    {
        // Keys
        public static string UriKey = "URI";
        public static string CurrentViewKey = "CurrentView";

        // Defaults
        public static string UriDefaultValue = "192.168.0.72";
        public static string CurrentViewDefaultValue = "MyMasterDetail/GradientHeaderNavigationPage/MainPage";

        public static string Uri
        {
            get { return Preferences.Get(UriKey, UriDefaultValue); }
            set { Preferences.Set(UriKey, value); }
        }

        public static string CurrentView
        {
            get { return Preferences.Get(CurrentViewKey, CurrentViewDefaultValue); }
            set { Preferences.Set(CurrentViewKey, value); }
        }
    }
}
