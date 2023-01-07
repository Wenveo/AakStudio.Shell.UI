using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Aak.Shell.UI.Controls
{
    public class MetroWindow : Window
    {
        public static readonly DependencyProperty ActiveGlowBrushProperty =
            DependencyProperty.Register(nameof(ActiveGlowBrush), typeof(SolidColorBrush),
                typeof(MetroWindow), new FrameworkPropertyMetadata(BrushesBox.TransparentBox));

        public static readonly DependencyProperty InactiveGlowBrushProperty =
            DependencyProperty.Register(nameof(InactiveGlowBrush), typeof(SolidColorBrush),
                typeof(MetroWindow), new FrameworkPropertyMetadata(BrushesBox.TransparentBox));

        /// <summary>
        ///     Left side of title bar
        /// </summary>
        public static readonly DependencyProperty LeftWindowCommandsProperty =
            DependencyProperty.Register(nameof(LeftWindowCommands), typeof(FrameworkElement),
                typeof(MetroWindow), new FrameworkPropertyMetadata(ObjectBox.NullBox));

        /// <summary>
        ///     Right side of title bar
        /// </summary>
        public static readonly DependencyProperty RightWindowCommandsProperty =
            DependencyProperty.Register(nameof(RightWindowCommands), typeof(FrameworkElement),
                typeof(MetroWindow), new FrameworkPropertyMetadata(ObjectBox.NullBox));

        /// <summary>
        ///     Sets whether Icon is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowIconProperty =
            DependencyProperty.Register(nameof(IsShowIcon), typeof(bool),
                typeof(MetroWindow), new FrameworkPropertyMetadata(BooleanBox.TrueBox));

        /// <summary>
        ///     Sets whether Title is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowTitleProperty =
            DependencyProperty.Register(nameof(IsShowTitle), typeof(bool),
                typeof(MetroWindow), new FrameworkPropertyMetadata(BooleanBox.TrueBox));

        /// <summary>
        ///     Sets whether TitleBar is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowTitleBarProperty =
            DependencyProperty.Register(nameof(IsShowTitleBar), typeof(bool),
                typeof(MetroWindow), new FrameworkPropertyMetadata(BooleanBox.TrueBox));

        /// <summary>
        ///     Sets whether MinimizeButton is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowMinimizeButtonProperty =
            DependencyProperty.Register(nameof(IsShowMinimizeButton), typeof(bool),
                typeof(MetroWindow), new FrameworkPropertyMetadata(BooleanBox.TrueBox));

        /// <summary>
        ///     Sets whether MaximizeButton is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowMaximizeButtonProperty =
            DependencyProperty.Register(nameof(IsShowMaximizeButton), typeof(bool),
                typeof(MetroWindow), new FrameworkPropertyMetadata(BooleanBox.TrueBox));

        /// <summary>
        ///     Sets whether CloseButton is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowCloseButtonProperty =
            DependencyProperty.Register(nameof(IsShowCloseButton), typeof(bool),
                typeof(MetroWindow), new FrameworkPropertyMetadata(BooleanBox.TrueBox));

        /// <summary>
        ///     Sets whether CloseButton is displayed
        /// </summary>
        public static readonly DependencyProperty OnMaximizedPaddingProperty =
            DependencyProperty.Register(nameof(OnMaximizedPadding), typeof(Thickness),
                typeof(MetroWindow), new FrameworkPropertyMetadata(ObjectBox.ThicknessBox));

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
            set => SetValue(IsShowIconProperty, value);
        }

        public bool IsShowTitle
        {
            get => (bool)GetValue(IsShowTitleProperty);
            set => SetValue(IsShowTitleProperty, value);
        }

        public bool IsShowTitleBar
        {
            get => (bool)GetValue(IsShowTitleBarProperty);
            set => SetValue(IsShowTitleBarProperty, value);
        }

        public bool IsShowMinimizeButton
        {
            get => (bool)GetValue(IsShowMinimizeButtonProperty);
            set => SetValue(IsShowMinimizeButtonProperty, value);
        }

        public bool IsShowMaximizeButton
        {
            get => (bool)GetValue(IsShowMaximizeButtonProperty);
            set => SetValue(IsShowMaximizeButtonProperty, value);
        }

        public bool IsShowCloseButton
        {
            get => (bool)GetValue(IsShowCloseButtonProperty);
            set => SetValue(IsShowCloseButtonProperty, value);
        }

        public Thickness OnMaximizedPadding
        {
            get => (Thickness)GetValue(OnMaximizedPaddingProperty);
            set => SetValue(OnMaximizedPaddingProperty, value);
        }

        static MetroWindow()
        {
            var resourceKey = "MetroWindowBaseStyle";
            var windowStyle = Application.Current.TryFindResource(resourceKey);
            if (windowStyle == null)
            {
                var resourceDictionary = (ResourceDictionary)Application.LoadComponent(
                    new Uri("/Aak.Shell.UI;Component/Styles/MetroWindow.xaml", UriKind.Relative));

                windowStyle = resourceDictionary[resourceKey];
            }
            StyleProperty.OverrideMetadata(typeof(MetroWindow), new FrameworkPropertyMetadata(windowStyle));
        }

        public MetroWindow()
        {
        }

        private void InitializeGlowWindowBehaviorEx()
        {
            var behavior = new ControlzEx.Behaviors.GlowWindowBehavior();
            _ = BindingOperations.SetBinding(behavior, ControlzEx.Behaviors.GlowWindowBehavior.GlowColorProperty,
                new Binding { Path = new PropertyPath("ActiveGlowBrush.Color"), Source = this });
            _ = BindingOperations.SetBinding(behavior, ControlzEx.Behaviors.GlowWindowBehavior.NonActiveGlowColorProperty,
                new Binding { Path = new PropertyPath("InactiveGlowBrush.Color"), Source = this });

            Interaction.GetBehaviors(this).Add(behavior);
        }

        private void InitializeWindowChromeEx()
        => Interaction.GetBehaviors(this).Add(new ControlzEx.Behaviors.WindowChromeBehavior());

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            InitializeGlowWindowBehaviorEx();
            InitializeWindowChromeEx();
        }
    }
}
