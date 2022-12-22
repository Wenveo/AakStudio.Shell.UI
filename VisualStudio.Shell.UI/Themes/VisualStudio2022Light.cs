using System;
using System.Windows;

namespace VisualStudio.Shell.UI.Themes
{
    public class VisualStudio2022Light : Theme
    {
        public VisualStudio2022Light()
            : base("Visual Studio 2022 Light", false, true, new ResourceDictionary()
            { Source = new Uri("/VisualStudio.Shell.UI;component/Themes/VisualStudio2022/LightTheme.xaml", UriKind.Relative) })
        { }
    }
}