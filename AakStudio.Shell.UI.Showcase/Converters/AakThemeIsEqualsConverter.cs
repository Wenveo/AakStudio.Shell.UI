using System;
using System.Globalization;
using System.Windows.Data;

namespace AakStudio.Shell.UI.Showcase.Converters
{
    [ValueConversion(typeof(AakTheme), typeof(bool))]
    internal sealed class AakThemeIsEqualsConverter : IMultiValueConverter
    {
        public object? Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null || value.Length != 2)
            {
                return false;
            }

            if (value[0] is not AakTheme source || value[1] is not AakTheme target)
            {
                return false;
            }

            return StringComparer.Ordinal.Equals(source.Name, target.Name);
        }

        public object[] ConvertBack(object? value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}