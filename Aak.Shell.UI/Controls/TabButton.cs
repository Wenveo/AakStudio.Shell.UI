using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Aak.Shell.UI.Controls
{
    public class TabButton : ButtonBase
    {
        public static readonly DependencyProperty GlyphForegroundProperty =
            DependencyProperty.Register(nameof(GlyphForeground), typeof(Brush),
                typeof(TabButton), new FrameworkPropertyMetadata(ObjectBoxes.NullBox));

        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.Register(nameof(HoverBackground), typeof(Brush),
                typeof(TabButton), new FrameworkPropertyMetadata(ObjectBoxes.NullBox));

        public static readonly DependencyProperty HoverBorderBrushProperty =
            DependencyProperty.Register(nameof(HoverBorderBrush), typeof(Brush),
                typeof(TabButton), new FrameworkPropertyMetadata(ObjectBoxes.NullBox));

        public static readonly DependencyProperty HoverForegroundProperty =
            DependencyProperty.Register(nameof(HoverForeground), typeof(Brush),
                typeof(TabButton), new FrameworkPropertyMetadata(ObjectBoxes.NullBox));

        public static readonly DependencyProperty PressedBackgroundProperty =
            DependencyProperty.Register(nameof(PressedBackground), typeof(Brush),
                typeof(TabButton), new FrameworkPropertyMetadata(ObjectBoxes.NullBox));

        public static readonly DependencyProperty PressedBorderBrushProperty =
            DependencyProperty.Register(nameof(PressedBorderBrush), typeof(Brush),
                typeof(TabButton), new FrameworkPropertyMetadata(ObjectBoxes.NullBox));

        public static readonly DependencyProperty PressedForegroundProperty =
            DependencyProperty.Register(nameof(PressedForeground), typeof(Brush),
                typeof(TabButton), new FrameworkPropertyMetadata(ObjectBoxes.NullBox));

        public static readonly DependencyProperty HoverBorderThicknessProperty =
            DependencyProperty.Register(nameof(HoverBorderThickness), typeof(Thickness),
                typeof(TabButton), new FrameworkPropertyMetadata(ObjectBoxes.ThicknessBox));

        public static readonly DependencyProperty PressedBorderThicknessProperty =
            DependencyProperty.Register(nameof(PressedBorderThickness), typeof(Thickness),
                typeof(TabButton), new FrameworkPropertyMetadata(ObjectBoxes.ThicknessBox));

        public Brush GlyphForeground
        {
            get => (Brush)GetValue(GlyphForegroundProperty);
            set => SetValue(GlyphForegroundProperty, value);
        }

        public Brush HoverBackground
        {
            get => (Brush)GetValue(HoverBackgroundProperty);
            set => SetValue(HoverBackgroundProperty, value);
        }

        public Brush HoverBorderBrush
        {
            get => (Brush)GetValue(HoverBorderBrushProperty);
            set => SetValue(HoverBorderBrushProperty, value);
        }

        public Brush HoverForeground
        {
            get => (Brush)GetValue(HoverForegroundProperty);
            set => SetValue(HoverForegroundProperty, value);
        }

        public Brush PressedBackground
        {
            get => (Brush)GetValue(PressedBackgroundProperty);
            set => SetValue(PressedBackgroundProperty, value);
        }

        public Brush PressedBorderBrush
        {
            get => (Brush)GetValue(PressedBorderBrushProperty);
            set => SetValue(PressedBorderBrushProperty, value);
        }

        public Brush PressedForeground
        {
            get => (Brush)GetValue(PressedForegroundProperty);
            set => SetValue(PressedForegroundProperty, value);
        }

        public Thickness HoverBorderThickness
        {
            get => (Thickness)GetValue(HoverBorderThicknessProperty);
            set => SetValue(HoverBorderThicknessProperty, value);
        }

        public Thickness PressedBorderThickness
        {
            get => (Thickness)GetValue(PressedBorderThicknessProperty);
            set => SetValue(PressedBorderThicknessProperty, value);
        }

        static TabButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TabButton), new FrameworkPropertyMetadata(typeof(TabButton)));
        }

        public TabButton()
        {
        }
    }
}
