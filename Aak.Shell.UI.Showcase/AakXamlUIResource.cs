using System;
using System.Collections.Generic;
using System.Windows;

namespace Aak.Shell.UI.Showcase
{
    internal abstract class AakTheme : ResourceDictionary
    {
        public abstract string Name { get; }

        public abstract IEnumerable<string> ThemeResources { get; }

        internal AakTheme()
        {
            foreach (var item in ThemeResources)
            {
                MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri(item, UriKind.Relative)
                });
            }
        }
    }

    internal sealed class AakVS2019Blue : AakTheme
    {
        public static AakVS2019Blue Default = new();

        public override string Name => "Visual Studio 2019 Blue";

        public override IEnumerable<string> ThemeResources
        {
            get
            {
                yield return "/Aak.Shell.UI;component/Themes/VisualStudio2019/BlueTheme.xaml";
                yield return "/Aak.Shell.UI.Themes.AvalonDock;component/Themes/VisualStudio2019/BlueTheme.xaml";
            }
        }
    }

    internal sealed class AakVS2019Dark : AakTheme
    {
        public static AakVS2019Dark Default = new();

        public override string Name => "Visual Studio 2019 Dark";

        public override IEnumerable<string> ThemeResources
        {
            get
            {
                yield return "/Aak.Shell.UI;component/Themes/VisualStudio2019/DarkTheme.xaml";
                yield return "/Aak.Shell.UI.Themes.AvalonDock;component/Themes/VisualStudio2019/DarkTheme.xaml";
            }
        }
    }

    internal sealed class AakVS2019Light : AakTheme
    {
        public static AakVS2019Light Default = new();

        public override string Name => "Visual Studio 2019 Light";

        public override IEnumerable<string> ThemeResources
        {
            get
            {
                yield return "/Aak.Shell.UI;component/Themes/VisualStudio2019/LightTheme.xaml";
                yield return "/Aak.Shell.UI.Themes.AvalonDock;component/Themes/VisualStudio2019/LightTheme.xaml";
            }
        }
    }


    internal sealed class AakVS2022Blue : AakTheme
    {
        public static AakVS2022Blue Default = new();

        public override string Name => "Visual Studio 2022 Blue";

        public override IEnumerable<string> ThemeResources
        {
            get
            {
                yield return "/Aak.Shell.UI;component/Themes/VisualStudio2022/BlueTheme.xaml";
                yield return "/Aak.Shell.UI.Themes.AvalonDock;component/Themes/VisualStudio2022/BlueTheme.xaml";
            }
        }
    }

    internal sealed class AakVS2022Dark : AakTheme
    {
        public static AakVS2022Dark Default = new();

        public override string Name => "Visual Studio 2022 Dark";

        public override IEnumerable<string> ThemeResources
        {
            get
            {
                yield return "/Aak.Shell.UI;component/Themes/VisualStudio2022/DarkTheme.xaml";
                yield return "/Aak.Shell.UI.Themes.AvalonDock;component/Themes/VisualStudio2022/DarkTheme.xaml";
            }
        }
    }

    internal sealed class AakVS2022Light : AakTheme
    {
        public static AakVS2022Light Default = new();

        public override string Name => "Visual Studio 2022 Light";

        public override IEnumerable<string> ThemeResources
        {
            get
            {
                yield return "/Aak.Shell.UI;component/Themes/VisualStudio2022/LightTheme.xaml";
                yield return "/Aak.Shell.UI.Themes.AvalonDock;component/Themes/VisualStudio2022/LightTheme.xaml";
            }
        }
    }

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
            theme = AakVS2022Light.Default;

            InitializeThemes();
        }

        private AakTheme theme;

        private void InitializeThemes()
        {
            MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Aak.Shell.UI;component/Themes/Generic.xaml", UriKind.Relative)
            });

            MergedDictionaries.Add(theme);
        }

        private void UpdateAakTheme(AakTheme theme)
        {
            MergedDictionaries[1] = theme;
        }
    }

}
