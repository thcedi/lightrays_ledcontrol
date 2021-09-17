using System;
using System.Globalization;
using Xamarin.Forms;

namespace LightRays.Core.Converters
{
    public class BooleanToBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isSelected = (bool)value;
            return isSelected ? Color.FromHex("#1d1d1d") : Color.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
