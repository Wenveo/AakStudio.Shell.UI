using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Aak.Shell.UI.Controls
{
    public enum WinSysType
    {
        Minimize,
        Maximize,
        Close
    }

    internal enum CurrentWinSysType
    {
        Minimize,
        Maximize,
        Restore,
        Close
    }

    public sealed class WindowSystemButton : ButtonBase
    {
        public static readonly DependencyProperty WinSysTypeProperty =
            DependencyProperty.Register(nameof(WinSysType), typeof(WinSysType), typeof(WindowSystemButton),
                new FrameworkPropertyMetadata(WinSysType.Minimize, OnWinSysTypeChanged));

        internal static readonly DependencyProperty CurrentWinSysTypeProperty =
            DependencyProperty.Register(nameof(CurrentWinSysType), typeof(CurrentWinSysType), typeof(WindowSystemButton),
                new FrameworkPropertyMetadata(CurrentWinSysType.Minimize));

        private Window? _window;

        static WindowSystemButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowSystemButton),
                new FrameworkPropertyMetadata(typeof(WindowSystemButton)));
        }

        public WindowSystemButton()
        {
            Loaded += WinSysButton_Loaded;
        }

        public WinSysType WinSysType
        {
            get => (WinSysType)GetValue(WinSysTypeProperty);
            set => SetValue(WinSysTypeProperty, value);
        }

        internal CurrentWinSysType CurrentWinSysType
        {
            get => (CurrentWinSysType)GetValue(CurrentWinSysTypeProperty);
            set => SetValue(CurrentWinSysTypeProperty, value);
        }

        private void WinSysButton_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= WinSysButton_Loaded;
            _window = Window.GetWindow(this);
            if (_window is not null) // null if in design mode
                _window.StateChanged += Window_StateChanged;
        }

        private void Window_StateChanged(object? sender, EventArgs e)
        {
            OnWinSysTypeChanged(WinSysType);
        }

        private static void OnWinSysTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((WindowSystemButton)d).OnWinSysTypeChanged((WinSysType)e.NewValue);
        }

        private void OnWinSysTypeChanged(WinSysType newValue)
        {
            if (_window is null) _window = Window.GetWindow(this);

            //if (_window is null || DesignerProperties.GetIsInDesignMode(this)) return;

            CurrentWinSysType = newValue switch
            {
                WinSysType.Minimize => CurrentWinSysType.Minimize,
                WinSysType.Maximize => _window.WindowState == WindowState.Maximized
                    ? CurrentWinSysType.Restore
                    : CurrentWinSysType.Maximize,
                WinSysType.Close => CurrentWinSysType.Close,
                _ => throw new ArgumentException("Invalid WinSysType")
            };
        }

        protected override void OnClick()
        {
            if (_window == null) return;

            switch (CurrentWinSysType)
            {
                case CurrentWinSysType.Minimize:
                    SystemCommands.MinimizeWindow(_window);
                    break;

                case CurrentWinSysType.Maximize:
                    SystemCommands.MaximizeWindow(_window);
                    break;

                case CurrentWinSysType.Restore:
                    SystemCommands.RestoreWindow(_window);
                    break;

                case CurrentWinSysType.Close:
                    _window.Close();
                    break;

                default:
                    throw new ArgumentException("Invalid CurrentWinSysType");
            }
        }
    }
}
