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
            get
            {
                if (instance == null)
                {
                    throw new InvalidOperationException("The XamlUIResources is not loaded!");
                }
                return instance;
            }
        }

        public Theme Theme
        {
            get => theme;
            set => CoerceSetTheme(theme = value);
        }

        public XamlUIResources()
        {
            instance = this;
            theme = new VisualStudio2022Light();
            CoerceInitialize();
        }

        private Theme theme;

        private void CoerceInitialize()
        {
            MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Aak.Shell.UI;component/Styles/Controls.xaml", UriKind.Relative)
            });
            MergedDictionaries.Add(theme.Current);
        }

        private void CoerceSetTheme(Theme theme)
        {
            MergedDictionaries[1] = theme.Current;
        }
    }
}
