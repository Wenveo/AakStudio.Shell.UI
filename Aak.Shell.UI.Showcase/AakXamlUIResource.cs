using System;
using System.Collections.Generic;
using System.Windows;

namespace Aak.Shell.UI.Showcase
{
    public abstract class AakTheme : ResourceDictionary
    {
        public abstract string Name { get; }

        public abstract IEnumerable<string> ThemeResources { get; }

        public AakTheme()
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

    public sealed class AakVS2019Blue : AakTheme
    {
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

    public sealed class AakVS2019Dark : AakTheme
    {
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

    public sealed class AakVS2019Light : AakTheme
    {
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


    public sealed class AakVS2022Blue : AakTheme
    {
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

    public sealed class AakVS2022Dark : AakTheme
    {
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

    public sealed class AakVS2022Light : AakTheme
    {
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

    public class AakXamlUIResource : ResourceDictionary
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
            theme = new AakVS2022Light();

            InitializeThemes();
        }

        private AakTheme theme;

        private void InitializeThemes()
        {
            MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Aak.Shell.UI;component/Styles/Controls.xaml", UriKind.Relative)
            });

            MergedDictionaries.Add(theme);
        }

        private void UpdateAakTheme(AakTheme theme)
        {
            MergedDictionaries[1] = theme;
        }
    }
}
