using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace AakStudio.Shell.UI.Controls
{
    public enum WindowSystemButtonType
    {
        Minimize,
        Maximize,
        Close
    }

    public class WindowSystemButton : ButtonBase
    {
        public static readonly DependencyProperty WindowSystemButtonTypeProperty =
            DependencyProperty.Register(nameof(WindowSystemButtonType), typeof(WindowSystemButtonType),
                typeof(WindowSystemButton), new FrameworkPropertyMetadata(WindowSystemButtonType.Minimize));

        public WindowSystemButtonType WindowSystemButtonType
        {
            get => (WindowSystemButtonType)GetValue(WindowSystemButtonTypeProperty);
            set => SetValue(WindowSystemButtonTypeProperty, value);
        }

        static WindowSystemButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowSystemButton), new FrameworkPropertyMetadata(typeof(WindowSystemButton)));
        }

        public WindowSystemButton()
        {
        }

        protected override void OnClick()
        {
            var window = Window.GetWindow(this);
            if (window == null) return;

            switch (WindowSystemButtonType)
            {
                case WindowSystemButtonType.Minimize:
                    SystemCommands.MinimizeWindow(window);
                    break;

                case WindowSystemButtonType.Maximize:
                    {
                        if (window.WindowState == WindowState.Maximized)
                            SystemCommands.RestoreWindow(window);
                        else
                            SystemCommands.MaximizeWindow(window);
                    }
                    break;

                case WindowSystemButtonType.Close:
                    window.Close();
                    break;

                default:
                    throw new ArgumentException("Invalid WindowSystemButtonType!");
            }
        }
    }
}
