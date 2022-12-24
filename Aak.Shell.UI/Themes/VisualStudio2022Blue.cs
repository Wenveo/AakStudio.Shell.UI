using System;
using System.Windows;

namespace Aak.Shell.UI.Themes
{
    public class VisualStudio2022Blue : Theme
    {
        public VisualStudio2022Blue()
            : base("Visual Studio 2022 Blue", false, true, new ResourceDictionary()
            { Source = new Uri("/Aak.Shell.UI;component/Themes/VisualStudio2022/BlueTheme.xaml", UriKind.Relative) })
        { }
    }
}