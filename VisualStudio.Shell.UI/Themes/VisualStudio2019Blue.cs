using System;
using System.Windows;

namespace VisualStudio.Shell.UI.Themes
{
    public class VisualStudio2019Blue : Theme
    {
        public VisualStudio2019Blue()
            : base("Visual Studio 2019 Blue", false, true, new ResourceDictionary
            { Source = new Uri("/VisualStudio.Shell.UI;component/Themes/VisualStudio2019/BlueTheme.xaml", UriKind.Relative) })
        { }
    }
}