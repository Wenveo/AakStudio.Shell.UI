using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Aak.Shell.UI.Showcase.Attach
{
    internal sealed class MouseLeftDoubleClickAttach
    {
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand),
                typeof(MouseLeftDoubleClickAttach), new FrameworkPropertyMetadata(OnCommandChanged));

        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not Control ctrl)
            {
                return;
            }

            ctrl.MouseDoubleClick -= OnMouseDoubleClick;
            ctrl.MouseDoubleClick += OnMouseDoubleClick;

            ctrl.Unloaded -= OnUnloaded;
            ctrl.Unloaded += OnUnloaded;
        }

        private static void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && sender is Control ctrl)
            {
                var command = GetCommand(ctrl);
                command?.Execute(null);

                e.Handled = true;
            }
        }

        private static void OnUnloaded(object sender, RoutedEventArgs e)
        {
            if (sender is Control ctrl)
            {
                ctrl.MouseDoubleClick -= OnMouseDoubleClick;
                ctrl.Unloaded -= OnUnloaded;
            }
        }

        public static ICommand GetCommand(DependencyObject element)
        => (ICommand)element.GetValue(CommandProperty);

        public static void SetCommand(DependencyObject element, bool value)
        => element.SetValue(CommandProperty, value);
    }
}