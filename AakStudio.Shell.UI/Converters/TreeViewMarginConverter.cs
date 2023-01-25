using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AakStudio.Shell.UI.Converters
{
    [ValueConversion(typeof(TreeViewItem), typeof(Thickness))]
    public sealed class TreeViewMarginConverter : IValueConverter
    {
        public double Length { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TreeViewItem item) return new Thickness(Length * GetDepth(item), 0, 0, 0);

            return new Thickness(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }

        public static int GetDepth(TreeViewItem item)
        {
            var count = 0;
            for (var parent = ItemsControl.ItemsControlFromItemContainer(item); parent != null; parent = ItemsControl.ItemsControlFromItemContainer(parent), count++)
            {
                if (parent is null or TreeView)
                {
                    break;
                }
            }

            return count;
        }
    }
}
