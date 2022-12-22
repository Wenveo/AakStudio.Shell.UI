using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using VisualStudio.Shell.UI.Showcase.ViewModels.Collection;

namespace VisualStudio.Shell.UI.Showcase.Converters;

internal sealed class ViewModelBaseToDisplayConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is CollectionViewModel isCollectionViewModel)
        {
            return isCollectionViewModel.DisplayName;
        }
        else if (value is PageViewModel isPageViewModel)
        {
            return isPageViewModel.DisplayName;
        }
        else
        {
            return Binding.DoNothing;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
