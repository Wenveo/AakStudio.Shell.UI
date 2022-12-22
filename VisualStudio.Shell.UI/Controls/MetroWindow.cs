using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace VisualStudio.Shell.UI.Controls
{
    public class MetroWindow : Window
    {
        public static bool IsWin11_Or_Latest => Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= 22000;

        public static readonly DependencyProperty ActiveGlowBrushProperty = DependencyProperty.Register(
            "ActiveGlowBrush", typeof(SolidColorBrush), typeof(MetroWindow),
            new PropertyMetadata(Brushes.Transparent));

        public static readonly DependencyProperty InactiveGlowBrushProperty = DependencyProperty.Register(
            "InactiveGlowBrush", typeof(SolidColorBrush), typeof(MetroWindow),
            new PropertyMetadata(Brushes.Transparent));

        /// <summary>
        ///     Left side of title bar
        /// </summary>
        public static readonly DependencyProperty LeftWindowCommandsProperty = DependencyProperty.Register(
            nameof(LeftWindowCommands),
            typeof(FrameworkElement), typeof(MetroWindow));

        /// <summary>
        ///     Right side of title bar
        /// </summary>
        public static readonly DependencyProperty RightWindowCommandsProperty = DependencyProperty.Register(
            nameof(RightWindowCommands),
            typeof(FrameworkElement), typeof(MetroWindow));

        /// <summary>
        ///     Sets whether Icon is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowIconProperty = DependencyProperty.Register(nameof(IsShowIcon),
            typeof(bool), typeof(MetroWindow), new PropertyMetadata(true));

        /// <summary>
        ///     Sets whether Title is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowTitleProperty = DependencyProperty.Register(nameof(IsShowTitle),
            typeof(bool), typeof(MetroWindow), new PropertyMetadata(true));

        /// <summary>
        ///     Sets whether TitleBar is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowTitleBarProperty = DependencyProperty.Register(nameof(IsShowTitleBar),
            typeof(bool), typeof(MetroWindow), new PropertyMetadata(true));

        /// <summary>
        ///     Sets whether MinimizeButton is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowMinimizeButtonProperty = DependencyProperty.Register(nameof(IsShowMinimizeButton),
            typeof(bool), typeof(MetroWindow), new PropertyMetadata(true));

        /// <summary>
        ///     Sets whether MaximizeButton is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowMaximizeButtonProperty = DependencyProperty.Register(nameof(IsShowMaximizeButton),
            typeof(bool), typeof(MetroWindow), new PropertyMetadata(true));

        /// <summary>
        ///     Sets whether CloseButton is displayed
        /// </summary>
        public static readonly DependencyProperty IsShowCloseButtonProperty = DependencyProperty.Register(nameof(IsShowCloseButton),
            typeof(bool), typeof(MetroWindow), new PropertyMetadata(true));

        /// <summary>
        ///     Sets whether CloseButton is displayed
        /// </summary>
        public static readonly DependencyProperty OnMaximizedPaddingProperty = DependencyProperty.Register(nameof(OnMaximizedPadding),
            typeof(Thickness), typeof(MetroWindow));


        public SolidColorBrush ActiveGlowBrush
        {
            get => (SolidColorBrush)this.GetValue(ActiveGlowBrushProperty);
            set => this.SetValue(ActiveGlowBrushProperty, value);
        }

        public SolidColorBrush InactiveGlowBrush
        {
            get => (SolidColorBrush)this.GetValue(InactiveGlowBrushProperty);
            set => this.SetValue(InactiveGlowBrushProperty, value);
        }

        public FrameworkElement LeftWindowCommands
        {
            get => (FrameworkElement)this.GetValue(LeftWindowCommandsProperty);
            set => this.SetValue(LeftWindowCommandsProperty, value);
        }

        public FrameworkElement RightWindowCommands
        {
            get => (FrameworkElement)this.GetValue(RightWindowCommandsProperty);
            set => this.SetValue(RightWindowCommandsProperty, value);
        }

        public bool IsShowIcon
        {
            get => (bool)this.GetValue(IsShowIconProperty);
            set => this.SetValue(IsShowIconProperty, value);
        }

        public bool IsShowTitle
        {
            get => (bool)this.GetValue(IsShowTitleProperty);
            set => this.SetValue(IsShowTitleProperty, value);
        }

        public bool IsShowTitleBar
        {
            get => (bool)this.GetValue(IsShowTitleBarProperty);
            set => this.SetValue(IsShowTitleBarProperty, value);
        }

        public bool IsShowMinimizeButton
        {
            get => (bool)this.GetValue(IsShowMinimizeButtonProperty);
            set => this.SetValue(IsShowMinimizeButtonProperty, value);
        }

        public bool IsShowMaximizeButton
        {
            get => (bool)this.GetValue(IsShowMaximizeButtonProperty);
            set => this.SetValue(IsShowMaximizeButtonProperty, value);
        }

        public bool IsShowCloseButton
        {
            get => (bool)this.GetValue(IsShowCloseButtonProperty);
            set => this.SetValue(IsShowCloseButtonProperty, value);
        }

        public Thickness OnMaximizedPadding
        {
            get => (Thickness)this.GetValue(OnMaximizedPaddingProperty);
            set => this.SetValue(OnMaximizedPaddingProperty, value);
        }

        static MetroWindow()
        {
            OnMaximizedPaddingProperty.OverrideMetadata(typeof(MetroWindow), new FrameworkPropertyMetadata(IsWin11_Or_Latest ? new Thickness(0) : new Thickness(8)));
            StyleProperty.OverrideMetadata(typeof(MetroWindow), new FrameworkPropertyMetadata(Application.Current.TryFindResource("MetroWindowBaseStyle")));
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

            this.InitializeGlowWindowBehaviorEx();
            this.InitializeWindowChromeEx();
        }
    }
}
