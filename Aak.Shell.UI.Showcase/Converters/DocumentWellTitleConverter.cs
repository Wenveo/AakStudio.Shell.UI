using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Aak.Shell.UI.Showcase.Converters;

internal sealed class DocumentWellTitleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var mainWindowTitle = Application.Current.MainWindow.Title;
        if (value is not null)
        {
            mainWindowTitle += $" - {value}";
        }

        return mainWindowTitle;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
