using System.Windows;
using System.Windows.Media;

namespace Aak.Shell.UI.Controls
{
    internal static class BooleanBox
    {
        public static readonly object TrueBox = true;
        public static readonly object FalseBox = false;

        public static object Box(bool value)
        {
            if (value)
            {
                return TrueBox;
            }
            return FalseBox;
        }
    }

    internal static class BrushesBox
    {
        public static readonly object TransparentBox = Brushes.Transparent;
    }

    internal static class ObjectBox
    {
        public static readonly object NullBox = null!;
        public static readonly object ThicknessBox = default(Thickness);
    }
}
