using Aak.Shell.UI.Showcase.Interfaces;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Aak.Shell.UI.Showcase.Converters;

internal sealed class AakViewElementToStringConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is IAakCollection aakCollection)
        {
            return aakCollection.DisplayName;
        }
        else if (value is IAakDocumentWell aakDocumentWell)
        {
            return aakDocumentWell.Title;
        }
        else
        {
            return string.Empty;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
