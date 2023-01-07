using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;

using AakThemes = Aak.Shell.UI.Themes;
using AvalonDockThemes = Aak.Shell.UI.Themes.AvalonDock;

namespace Aak.Shell.UI.Showcase.Converters
{
    internal sealed class AakThemeToAvalonDockThemeConverter : IValueConverter
    {
        private readonly Dictionary<Type, AvalonDock.Themes.Theme> TypeToTheme = new()
        {
            { typeof(AakThemes.VisualStudio2019Blue), new AvalonDockThemes.VisualStudio2019Blue()},
            { typeof(AakThemes.VisualStudio2019Dark), new AvalonDockThemes.VisualStudio2019Dark()},
            { typeof(AakThemes.VisualStudio2019Light), new AvalonDockThemes.VisualStudio2019Light()},
            { typeof(AakThemes.VisualStudio2022Blue), new AvalonDockThemes.VisualStudio2022Blue()},
            { typeof(AakThemes.VisualStudio2022Dark), new AvalonDockThemes.VisualStudio2022Dark()},
            { typeof(AakThemes.VisualStudio2022Light), new AvalonDockThemes.VisualStudio2022Light()}
        };

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (Application.Current.MainWindow.IsLoaded &&
                value is AakThemes.Theme aakTheme)
            {
                return TypeToTheme[aakTheme.GetType()];
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
