using System.Windows;
using System.Windows.Media;

namespace VisualStudio.Shell.UI.Helpers
{
    internal static class VisualHelper
    {
        public static T? GetChild<T>(DependencyObject d) where T : DependencyObject
        {
            if (d is null) return default;

            if (d is T t) return t;

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(d); i++)
            {
                var child = VisualTreeHelper.GetChild(d, i);

                var result = GetChild<T>(child);
                if (result != null) return result;
            }

            return default;
        }

        public static T? GetParent<T>(DependencyObject d) where T : DependencyObject
        {
            if (d is null)
                return default;
            if (d is T t)
                return t;
            if (d is Window)
                return null;
            return GetParent<T>(VisualTreeHelper.GetParent(d));
        }
    }
}