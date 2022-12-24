using Aak.Shell.UI.Showcase.ViewModels.Collection;
using System;
using System.Windows.Data;

namespace Aak.Shell.UI.Showcase.Converters;

internal sealed class ActiveDocumentConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is PageViewModel || value is CollectionViewModel)
            return value;

        return Binding.DoNothing;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is PageViewModel || value is CollectionViewModel)
            return value;

        return Binding.DoNothing;
    }
}
