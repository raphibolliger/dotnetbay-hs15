using System;
using System.Globalization;
using System.Windows.Data;

namespace DotNetBay.WPF.Converter
{
    public class BooleanToStatusTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool) value) return "Offen";
            return "Geschlossen";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}