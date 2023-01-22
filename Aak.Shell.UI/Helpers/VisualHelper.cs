using System.Windows;
using System.Windows.Media;

namespace Aak.Shell.UI.Helpers
{
    internal static class VisualHelper
    {
        public static T? GetParent<T>(DependencyObject elem) where T : DependencyObject
        {
            for (var parent = VisualTreeHelper.GetParent(elem); parent != null; parent = VisualTreeHelper.GetParent(parent))
            {
                if (parent is T tmp)
                {
                    return tmp;
                }
            }

            return null;
        }
    }
}