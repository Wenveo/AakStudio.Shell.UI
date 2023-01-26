using System;
using System.Windows;

namespace AakStudio.Shell.UI.Showcase
{
    internal class AakXamlUIResource : ResourceDictionary
    {
        private static AakXamlUIResource? instance;
        public static AakXamlUIResource Instance
        {
            get
            {
                if (instance == null)
                {
                    throw new InvalidOperationException("The AakXamlUIResource is not loaded!");
                }
                return instance;
            }
        }

        public AakTheme Theme
        {
            get => theme;
            set => UpdateAakTheme(theme = value);
        }

        public AakXamlUIResource()
        {
            instance = this;
            theme = AakThemeCollection.AllThemes[AakThemeCollection.AllThemes.Count - 2];

            InitializeThemes();
        }

        private AakTheme theme;

        private void InitializeThemes()
        {
            MergedDictionaries.Add(theme);
        }

        private void UpdateAakTheme(AakTheme theme)
        {
            MergedDictionaries[0] = theme;
        }
    }
}
