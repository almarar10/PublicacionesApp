using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace PublicacionesApp.Converters
{
    public class StringNotNullOrEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string s)
                return !string.IsNullOrWhiteSpace(s);
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
