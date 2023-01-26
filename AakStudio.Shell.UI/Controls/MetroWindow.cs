using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

using Microsoft.Xaml.Behaviors;

namespace AakStudio.Shell.UI.Controls
{
    public class MetroWindow : Window
    {
        public static readonly DependencyProperty ActiveGlowBrushProperty =
            DependencyProperty.Register(nameof(ActiveGlowBrush), typeof(SolidColorBrush),
                typeof(MetroWindow), new FrameworkPropertyMetadata(ObjectBoxes.TransparentBox));

        public static readonly DependencyProperty InactiveGlowBrushProperty =
            DependencyProperty.Register(nameof(InactiveGlowBrush), typeof(SolidColorBrush),
                typeof(MetroWindow), new FrameworkPropertyMetadata(ObjectBoxes.TransparentBox));

        /// <summary>
        ///     Left side of title bar
        /// </summary>
        public static readonly DependencyProperty LeftWindowCommandsProperty =
            DependencyProperty.Register(nameof(LeftWindowCommands), typeof(FrameworkElement),
                typeof(MetroWindow), new FrameworkPropertyMetadata(ObjectBoxes.NullBox));

        /// <summary>
        ///     Right side of title bar
        /// </summary>
        public static readonly DependencyProperty RightWindowCommandsProperty =
            DependencyProperty.Register(nameof(RightWindowCommands), typeof(FrameworkElement),
                typeof(MetroWindow), new FrameworkPropertyMetadata(ObjectBoxes.NullBox));

        /// <summary>
        ///     Sets whether Icon is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowIconProperty =
            DependencyProperty.Register(nameof(IsShowIcon), typeof(bool),
                typeof(MetroWindow), new FrameworkPropertyMetadata(BooleanBoxes.TrueBox));

        /// <summary>
        ///     Sets whether Title is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowTitleProperty =
            DependencyProperty.Register(nameof(IsShowTitle), typeof(bool),
                typeof(MetroWindow), new FrameworkPropertyMetadata(BooleanBoxes.TrueBox));

        /// <summary>
        ///     Sets whether TitleBar is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowTitleBarProperty =
            DependencyProperty.Register(nameof(IsShowTitleBar), typeof(bool),
                typeof(MetroWindow), new FrameworkPropertyMetadata(BooleanBoxes.TrueBox));

        /// <summary>
        ///     Sets whether MinimizeButton is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowMinimizeButtonProperty =
            DependencyProperty.Register(nameof(IsShowMinimizeButton), typeof(bool),
                typeof(MetroWindow), new FrameworkPropertyMetadata(BooleanBoxes.TrueBox));

        /// <summary>
        ///     Sets whether MaximizeButton is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowMaximizeButtonProperty =
            DependencyProperty.Register(nameof(IsShowMaximizeButton), typeof(bool),
                typeof(MetroWindow), new FrameworkPropertyMetadata(BooleanBoxes.TrueBox));

        /// <summary>
        ///     Sets whether CloseButton is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowCloseButtonProperty =
            DependencyProperty.Register(nameof(IsShowCloseButton), typeof(bool),
                typeof(MetroWindow), new FrameworkPropertyMetadata(BooleanBoxes.TrueBox));

        /// <summary>
        ///     Sets whether CloseButton is displayed
        /// </summary>
        public static readonly DependencyProperty OnMaximizedPaddingProperty =
            DependencyProperty.Register(nameof(OnMaximizedPadding), typeof(Thickness),
                typeof(MetroWindow), new FrameworkPropertyMetadata(ObjectBoxes.ThicknessBox));

        public SolidColorBrush ActiveGlowBrush
        {
            get => (SolidColorBrush)GetValue(ActiveGlowBrushProperty);
            set => SetValue(ActiveGlowBrushProperty, value);
        }

        public SolidColorBrush InactiveGlowBrush
        {
            get => (SolidColorBrush)GetValue(InactiveGlowBrushProperty);
            set => SetValue(InactiveGlowBrushProperty, value);
        }

        public FrameworkElement LeftWindowCommands
        {
            get => (FrameworkElement)GetValue(LeftWindowCommandsProperty);
            set => SetValue(LeftWindowCommandsProperty, value);
        }

        public FrameworkElement RightWindowCommands
        {
            get => (FrameworkElement)GetValue(RightWindowCommandsProperty);
            set => SetValue(RightWindowCommandsProperty, value);
        }

        public bool IsShowIcon
        {
            get => (bool)GetValue(IsShowIconProperty);
            set => SetValue(IsShowIconProperty, BooleanBoxes.Box(value));
        }

        public bool IsShowTitle
        {
            get => (bool)GetValue(IsShowTitleProperty);
            set => SetValue(IsShowTitleProperty, BooleanBoxes.Box(value));
        }

        public bool IsShowTitleBar
        {
            get => (bool)GetValue(IsShowTitleBarProperty);
            set => SetValue(IsShowTitleBarProperty, BooleanBoxes.Box(value));
        }

        public bool IsShowMinimizeButton
        {
            get => (bool)GetValue(IsShowMinimizeButtonProperty);
            set => SetValue(IsShowMinimizeButtonProperty, BooleanBoxes.Box(value));
        }

        public bool IsShowMaximizeButton
        {
            get => (bool)GetValue(IsShowMaximizeButtonProperty);
            set => SetValue(IsShowMaximizeButtonProperty, BooleanBoxes.Box(value));
        }

        public bool IsShowCloseButton
        {
            get => (bool)GetValue(IsShowCloseButtonProperty);
            set => SetValue(IsShowCloseButtonProperty, BooleanBoxes.Box(value));
        }

        public Thickness OnMaximizedPadding
        {
            get => (Thickness)GetValue(OnMaximizedPaddingProperty);
            set => SetValue(OnMaximizedPaddingProperty, value);
        }

        static MetroWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroWindow), new FrameworkPropertyMetadata(typeof(MetroWindow)));
        }

        public MetroWindow()
        {
            Loaded += OnLoaded;
        }

        private void InitializeGlowWindowBehaviorEx()
        {
            var behavior = new ControlzEx.Behaviors.GlowWindowBehavior();

            BindingOperations.SetBinding(behavior, ControlzEx.Behaviors.GlowWindowBehavior.GlowColorProperty,
                new Binding { Path = new PropertyPath("ActiveGlowBrush.Color"), Source = this });
            BindingOperations.SetBinding(behavior, ControlzEx.Behaviors.GlowWindowBehavior.NonActiveGlowColorProperty,
                new Binding { Path = new PropertyPath("InactiveGlowBrush.Color"), Source = this });

            Interaction.GetBehaviors(this).Add(behavior);
        }

        private void InitializeWindowChromeEx()
        {
            var behavior = new ControlzEx.Behaviors.WindowChromeBehavior();

            BindingOperations.SetBinding(behavior, ControlzEx.Behaviors.WindowChromeBehavior.EnableMinimizeProperty,
                new Binding { Path = new PropertyPath(IsShowMinimizeButtonProperty), Source = this });
            BindingOperations.SetBinding(behavior, ControlzEx.Behaviors.WindowChromeBehavior.EnableMaxRestoreProperty,
                new Binding { Path = new PropertyPath(IsShowMaximizeButtonProperty), Source = this });

            Interaction.GetBehaviors(this).Add(behavior);
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Loaded -= OnLoaded;

            InitializeGlowWindowBehaviorEx();
            InitializeWindowChromeEx();
        }
    }
}
