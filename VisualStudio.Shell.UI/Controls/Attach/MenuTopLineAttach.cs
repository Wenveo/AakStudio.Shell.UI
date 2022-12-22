using VisualStudio.Shell.UI.Helpers;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace VisualStudio.Shell.UI.Controls.Attach
{
    public class MenuTopLineAttach
    {
        private const double SystemPopupRightPadding = 6.0d;

        public static readonly DependencyProperty PopupProperty = DependencyProperty.RegisterAttached(
            "Popup", typeof(Popup), typeof(MenuTopLineAttach), new PropertyMetadata(default(Popup), OnPopupChanged));

        public static readonly DependencyProperty TopLineProperty = DependencyProperty.RegisterAttached(
            "TopLine", typeof(FrameworkElement), typeof(MenuTopLineAttach),
            new PropertyMetadata(default(FrameworkElement)));

        private static void OnPopupChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var topLine = (FrameworkElement)d;

            if (e.NewValue is Popup popup && popup.TemplatedParent is MenuItem menuItem)
            {
                SetTopLine(menuItem, topLine);
                menuItem.Loaded += MenuItem_Loaded;
            }
        }

        private static void MenuItem_Loaded(object sender, RoutedEventArgs e)
        {
            var menuItem = (FrameworkElement)sender;
            menuItem.Unloaded += MenuItem_Unloaded;
            var topLine = GetTopLine(menuItem);
            if (topLine is null)
                return;

            var popup = GetPopup(topLine);
            if (popup is not null) popup.Opened += Popup_Opened;
        }

        private static void MenuItem_Unloaded(object sender, RoutedEventArgs e)
        {
            var menuItem = (FrameworkElement)sender;
            menuItem.Unloaded -= MenuItem_Unloaded;
            var topLine = GetTopLine(menuItem);
            if (topLine is null)
                return;

            var popup = GetPopup(topLine);
            if (popup is not null) popup.Opened -= Popup_Opened;
        }

        private static void Popup_Opened(object? sender, EventArgs e)
        {
            if (sender is null)
                return;

            var popup = (Popup)sender;
            if (popup.TemplatedParent is MenuItem menuItem)
            {
                var topLine = GetTopLine(menuItem);
                if (topLine is null) return;

                topLine.HorizontalAlignment = HorizontalAlignment.Left;

                var menuItemLeftTop = menuItem.PointToScreen(new Point());
                var menuItemRightBottom = menuItem.PointToScreen(new Point(menuItem.ActualWidth, menuItem.ActualHeight));
                ScreenHelper.FindMonitorRectsFromPoint(MouseHelper.GetMousePosition(), out _, out var workAreaRect);
                var panel = VisualHelper.GetParent<Panel>(topLine);

                if (panel is null) return;
                var point = panel.TranslatePoint(menuItemLeftTop, topLine);

                if (menuItemRightBottom.Y > workAreaRect.Bottom ||
                    menuItemRightBottom.Y + panel.ActualHeight > workAreaRect.Bottom)
                {
                    // Bottom
                    topLine.Width = 0;
                    topLine.Margin = new Thickness();

                    /* Offset Form Visual Studio 2022 */
                    popup.VerticalOffset = -4;
                }
                else
                {
                    // Restore Offset
                    popup.VerticalOffset = 0;

                    double leftPadding = menuItem.BorderThickness.Left;
                    double rightPadding = menuItem.BorderThickness.Right;
                    double leftRightPadding = leftPadding + rightPadding;

                    double left, top, width;
                    top = -menuItem.BorderThickness.Top;

                    if (menuItemLeftTop.X < 0)
                    {
                        // Left
                        left = menuItemLeftTop.X - panel.Margin.Left;
                        width = menuItem.ActualWidth - leftRightPadding;
                    }
                    else if (menuItemLeftTop.X + panel.ActualWidth + SystemPopupRightPadding >= workAreaRect.Right)
                    {
                        // Right
                        var overflowWidth = menuItemRightBottom.X + SystemPopupRightPadding - workAreaRect.Right;
                        if (overflowWidth >= 0)
                        {
                            width = workAreaRect.Right - SystemPopupRightPadding - menuItemLeftTop.X - leftPadding;
                            if (width < 0)
                                width = 0;
                        }
                        else
                        {
                            width = menuItem.ActualWidth - leftRightPadding;
                        }
                        left = menuItemLeftTop.X - (workAreaRect.Right - SystemPopupRightPadding - panel.ActualWidth) + leftPadding;
                    }
                    else
                    {
                        // Normal
                        left = 0;
                        width = menuItem.ActualWidth - leftRightPadding;
                    }

                    topLine.Width = width;
                    topLine.Margin = new Thickness(left, top, 0, 0);
                }
            }
        }

        public static void SetPopup(DependencyObject element, Popup value)
        {
            element.SetValue(PopupProperty, value);
        }

        public static Popup GetPopup(DependencyObject element)
        {
            return (Popup)element.GetValue(PopupProperty);
        }

        public static void SetTopLine(DependencyObject element, FrameworkElement value)
        {
            element.SetValue(TopLineProperty, value);
        }

        public static FrameworkElement GetTopLine(DependencyObject element)
        {
            return (FrameworkElement)element.GetValue(TopLineProperty);
        }
    }
}
