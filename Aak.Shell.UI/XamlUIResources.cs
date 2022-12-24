using Aak.Shell.UI.Themes;
using System;
using System.Windows;

namespace Aak.Shell.UI
{
    public class XamlUIResources : ResourceDictionary
    {
        private static XamlUIResources? instance;
        public static XamlUIResources Instance
        {
            get => instance ??= new XamlUIResources();
        }

        public Theme Theme
        {
            get => this.theme;
            set => this.CoerceSetTheme(this.theme = value);
        }

        public XamlUIResources()
        {
            this.theme = new VisualStudio2022Light();
            this.CoerceInitialize();

            instance ??= this;
        }

        private Theme theme;

        private void CoerceInitialize()
        {
            this.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Aak.Shell.UI;component/Styles/Controls.xaml", UriKind.Relative)
            });
            this.MergedDictionaries.Add(this.theme.Current);
        }
        private void CoerceSetTheme(Theme theme)
        {
            this.MergedDictionaries[1] = theme.Current;
        }
    }
}
