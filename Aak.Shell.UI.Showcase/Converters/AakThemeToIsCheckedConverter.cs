using Aak.Shell.UI.Themes;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Aak.Shell.UI.Showcase.Converters;

[ValueConversion(typeof(Theme), typeof(bool))]
internal sealed class AakThemeToIsCheckedConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not Theme theme || parameter is not string str)
        {
            return false;
        }

        return theme.Name == str;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
