using System.Windows;
using System.Windows.Media;

namespace VisualStudio.Shell.UI.Helpers
{
    internal static class VisualHelper
    {
        public static T? GetParent<T>(DependencyObject d) where T : DependencyObject
        {
            if (d is null)
                return default;
            if (d is T t)
                return t;
            if (d is Window)
                return null;

            return GetParent<T>(d is Visual ? VisualTreeHelper.GetParent(d) : LogicalTreeHelper.GetParent(d));
        }
    }
}