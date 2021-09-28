using System;
using System.Globalization;
using Xamarin.Forms;

namespace LightRays.Core.Converters
{
    public class HexToXFColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Xamarin.Forms.Color.FromHex((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Color)value).ToHex();
        }
    }
}
