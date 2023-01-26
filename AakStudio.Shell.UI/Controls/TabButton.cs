using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace AakStudio.Shell.UI.Controls
{
    /// <summary>
    /// A tab button.
    /// </summary>
    public class TabButton : ButtonBase
    {
        /// <summary>
        /// Identifies the <see cref="HoverBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.Register(nameof(HoverBackground), typeof(Brush),
                typeof(TabButton), new FrameworkPropertyMetadata(ObjectBoxes.TransparentBox));

        /// <summary>
        /// Identifies the <see cref="HoverBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HoverBorderBrushProperty =
            DependencyProperty.Register(nameof(HoverBorderBrush), typeof(Brush),
                typeof(TabButton), new FrameworkPropertyMetadata(ObjectBoxes.TransparentBox));

        /// <summary>
        /// Identifies the <see cref="HoverForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HoverForegroundProperty =
            DependencyProperty.Register(nameof(HoverForeground), typeof(Brush),
                typeof(TabButton), new FrameworkPropertyMetadata(ObjectBoxes.TransparentBox));

        /// <summary>
        /// Identifies the <see cref="PressedBackground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PressedBackgroundProperty =
            DependencyProperty.Register(nameof(PressedBackground), typeof(Brush),
                typeof(TabButton), new FrameworkPropertyMetadata(ObjectBoxes.TransparentBox));

        /// <summary>
        /// Identifies the <see cref="PressedBorderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PressedBorderBrushProperty =
            DependencyProperty.Register(nameof(PressedBorderBrush), typeof(Brush),
                typeof(TabButton), new FrameworkPropertyMetadata(ObjectBoxes.TransparentBox));

        /// <summary>
        /// Identifies the <see cref="PressedForeground"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PressedForegroundProperty =
            DependencyProperty.Register(nameof(PressedForeground), typeof(Brush),
                typeof(TabButton), new FrameworkPropertyMetadata(ObjectBoxes.TransparentBox));

        /// <summary>
        /// Identifies the <see cref="HoverBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HoverBorderThicknessProperty =
            DependencyProperty.Register(nameof(HoverBorderThickness), typeof(Thickness),
                typeof(TabButton), new FrameworkPropertyMetadata(ObjectBoxes.ThicknessBox));

        /// <summary>
        /// Identifies the <see cref="PressedBorderThickness"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PressedBorderThicknessProperty =
            DependencyProperty.Register(nameof(PressedBorderThickness), typeof(Thickness),
                typeof(TabButton), new FrameworkPropertyMetadata(ObjectBoxes.ThicknessBox));

        /// <summary>
        /// The background of the button when the mouse is over them.
        /// </summary>
        [Bindable(true)]
        public Brush HoverBackground
        {
            get => (Brush)GetValue(HoverBackgroundProperty);
            set => SetValue(HoverBackgroundProperty, value);
        }

        /// <summary>
        /// The border brush of the button when the mouse is over them.
        /// </summary>
        [Bindable(true)]
        public Brush HoverBorderBrush
        {
            get => (Brush)GetValue(HoverBorderBrushProperty);
            set => SetValue(HoverBorderBrushProperty, value);
        }

        /// <summary>
        /// The foreground of the button when the mouse is over them.
        /// </summary>
        [Bindable(true)]
        public Brush HoverForeground
        {
            get => (Brush)GetValue(HoverForegroundProperty);
            set => SetValue(HoverForegroundProperty, value);
        }

        /// <summary>
        /// The background of the button when the mouse is pressed.
        /// </summary>
        [Bindable(true)]
        public Brush PressedBackground
        {
            get => (Brush)GetValue(PressedBackgroundProperty);
            set => SetValue(PressedBackgroundProperty, value);
        }

        /// <summary>
        /// The border brush of the button when the mouse is pressed.
        /// </summary>
        [Bindable(true)]
        public Brush PressedBorderBrush
        {
            get => (Brush)GetValue(PressedBorderBrushProperty);
            set => SetValue(PressedBorderBrushProperty, value);
        }

        /// <summary>
        /// The foreground of the button when the mouse is pressed.
        /// </summary>
        [Bindable(true)]
        public Brush PressedForeground
        {
            get => (Brush)GetValue(PressedForegroundProperty);
            set => SetValue(PressedForegroundProperty, value);
        }

        /// <summary>
        /// The border thickness of the button when the mouse is over them.
        /// </summary>
        [Bindable(true)]
        [Category("Layout")]
        public Thickness HoverBorderThickness
        {
            get => (Thickness)GetValue(HoverBorderThicknessProperty);
            set => SetValue(HoverBorderThicknessProperty, value);
        }

        /// <summary>
        /// The border thickness of the button when the mouse is pressed.
        /// </summary>
        [Bindable(true)]
        [Category("Layout")]
        public Thickness PressedBorderThickness
        {
            get => (Thickness)GetValue(PressedBorderThicknessProperty);
            set => SetValue(PressedBorderThicknessProperty, value);
        }

        /// <summary>
        /// The static class constructor of the <see cref="TabButton"/>.
        /// </summary>
        static TabButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TabButton), new FrameworkPropertyMetadata(typeof(TabButton)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TabButton"/> class.
        /// </summary>
        public TabButton()
        {
        }
    }
}
