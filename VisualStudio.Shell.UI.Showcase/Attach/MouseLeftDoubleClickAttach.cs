using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace VisualStudio.Shell.UI.Showcase.Attach;

internal sealed class MouseLeftDoubleClickAttach
{
    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.RegisterAttached(
            "Command", typeof(ICommand), typeof(MouseLeftDoubleClickAttach), new PropertyMetadata(OnCommandChanged));

    private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is FrameworkElement element)
        {
            element.Loaded += Element_Loaded;
        }
    }

    private static void Element_Loaded(object sender, RoutedEventArgs e)
    {
        if (sender is TreeViewItem element)
        {
            element.MouseDoubleClick += Element_MouseDoubleClick;
        }
    }

    private static void Element_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (sender is DependencyObject d)
        {
            e.Handled = true;
            var command = GetCommand(d);
            command?.Execute(null);
        }
    }

    public static ICommand GetCommand(DependencyObject element)
    {
        return (ICommand)element.GetValue(CommandProperty);
    }

    public static void SetCommand(DependencyObject element, bool value)
    {
        element.SetValue(CommandProperty, value);
    }
}
