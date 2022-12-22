using System;
using System.Windows;

namespace VisualStudio.Shell.UI.Themes
{
    public class VisualStudio2019Dark : Theme
    {
        public VisualStudio2019Dark()
            : base("Visual Studio 2019 Dark", true, false, new ResourceDictionary
            { Source = new Uri("/VisualStudio.Shell.UI;component/Themes/VisualStudio2019/DarkTheme.xaml", UriKind.Relative) })
        { }
    }
}