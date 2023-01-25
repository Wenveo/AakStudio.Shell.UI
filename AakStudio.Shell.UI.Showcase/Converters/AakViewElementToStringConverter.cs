using System;
using System.Globalization;
using System.Windows.Data;

using AakStudio.Shell.UI.Showcase.Shell;

namespace AakStudio.Shell.UI.Showcase.Converters
{
    internal sealed class AakViewElementToStringConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is AakCollection aakCollection)
            {
                return aakCollection.DisplayName;
            }
            else if (value is AakDocumentWell aakDocumentWell)
            {
                return aakDocumentWell.Title;
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
}