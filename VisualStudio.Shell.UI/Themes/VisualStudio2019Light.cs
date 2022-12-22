using System;
using System.Windows;

namespace VisualStudio.Shell.UI.Themes
{
    public class VisualStudio2019Light : Theme
    {
        public VisualStudio2019Light()
            : base("Visual Studio 2019 Light", false, true, new ResourceDictionary
            { Source = new Uri("/VisualStudio.Shell.UI;component/Themes/VisualStudio2019/LightTheme.xaml", UriKind.Relative) })
        { }
    }
}