using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace LightRays.Core
{
    public static class Settings
    {
        // Keys
        public static string DesignationKey = "DESIGNATION";

        // Defaults
        public static string DesignationDefaultValue = string.Empty;

        public static string Designation
        {
            get { return Preferences.Get(DesignationKey, DesignationDefaultValue); }
            set { Preferences.Set(DesignationKey, value); }
        }
    }
}
