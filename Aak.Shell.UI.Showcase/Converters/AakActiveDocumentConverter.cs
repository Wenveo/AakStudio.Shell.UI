using Aak.Shell.UI.Showcase.ViewModels.Collection;
using System;
using System.Windows.Data;

namespace Aak.Shell.UI.Showcase.Converters
{
    internal sealed class AakActiveDocumentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is AakDocumentWellViewModel || value is AakCollectionViewModel)
                return value;

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is AakDocumentWellViewModel || value is AakCollectionViewModel)
                return value;

            return Binding.DoNothing;
        }
    }
}