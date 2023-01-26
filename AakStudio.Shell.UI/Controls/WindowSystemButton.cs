using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace AakStudio.Shell.UI.Controls
{
    /// <summary>
    /// The types of window system button.
    /// </summary>
    public enum WindowSystemButtonType
    {
        /// <summary>
        /// The minimize button.
        /// </summary>
        Minimize,
        /// <summary>
        /// The maximize/restore button.
        /// </summary>
        Maximize,
        /// <summary>
        /// The close button.
        /// </summary>
        Close
    }

    /// <summary>
    /// 
    /// </summary>
    public class WindowSystemButton : ButtonBase
    {
        /// <summary>
        /// Identifies the <see cref="WindowSystemButtonType"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty WindowSystemButtonTypeProperty =
            DependencyProperty.Register(nameof(WindowSystemButtonType), typeof(WindowSystemButtonType),
                typeof(WindowSystemButton), new FrameworkPropertyMetadata(WindowSystemButtonType.Minimize));

        /// <summary>
        /// The button type of <see cref="WindowSystemButton"/>.
        /// </summary>
        public WindowSystemButtonType WindowSystemButtonType
        {
            get => (WindowSystemButtonType)GetValue(WindowSystemButtonTypeProperty);
            set => SetValue(WindowSystemButtonTypeProperty, value);
        }

        /// <summary>
        /// The static class constructor of the <see cref="WindowSystemButton"/>.
        /// </summary>
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
