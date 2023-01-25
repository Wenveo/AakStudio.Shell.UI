using System.Collections.Generic;

namespace AakStudio.Shell.UI.Showcase
{
    internal static class AakThemeCollection
    {
        private sealed class AakVS2019Blue : AakTheme
        {
            public override string Name => "Visual Studio 2019 Blue";

            public override IEnumerable<string> ThemeResources
            {
                get
                {
                    yield return "/AakStudio.Shell.UI;component/Themes/VisualStudio2019/BlueTheme.xaml";
                    yield return "/AakStudio.Shell.UI.Themes.AvalonDock;component/Themes/VisualStudio2019/BlueTheme.xaml";
                }
            }
        }

        private sealed class AakVS2019Dark : AakTheme
        {
            public override string Name => "Visual Studio 2019 Dark";

            public override IEnumerable<string> ThemeResources
            {
                get
                {
                    yield return "/AakStudio.Shell.UI;component/Themes/VisualStudio2019/DarkTheme.xaml";
                    yield return "/AakStudio.Shell.UI.Themes.AvalonDock;component/Themes/VisualStudio2019/DarkTheme.xaml";
                }
            }
        }

        private sealed class AakVS2019Light : AakTheme
        {
            public override string Name => "Visual Studio 2019 Light";

            public override IEnumerable<string> ThemeResources
            {
                get
                {
                    yield return "/AakStudio.Shell.UI;component/Themes/VisualStudio2019/LightTheme.xaml";
                    yield return "/AakStudio.Shell.UI.Themes.AvalonDock;component/Themes/VisualStudio2019/LightTheme.xaml";
                }
            }
        }

        private sealed class AakVS2022Blue : AakTheme
        {
            public override string Name => "Visual Studio 2022 Blue";

            public override IEnumerable<string> ThemeResources
            {
                get
                {
                    yield return "/AakStudio.Shell.UI;component/Themes/VisualStudio2022/BlueTheme.xaml";
                    yield return "/AakStudio.Shell.UI.Themes.AvalonDock;component/Themes/VisualStudio2022/BlueTheme.xaml";
                }
            }
        }

        private sealed class AakVS2022Dark : AakTheme
        {
            public override string Name => "Visual Studio 2022 Dark";

            public override IEnumerable<string> ThemeResources
            {
                get
                {
                    yield return "/AakStudio.Shell.UI;component/Themes/VisualStudio2022/DarkTheme.xaml";
                    yield return "/AakStudio.Shell.UI.Themes.AvalonDock;component/Themes/VisualStudio2022/DarkTheme.xaml";
                }
            }
        }

        private sealed class AakVS2022Light : AakTheme
        {
            public override string Name => "Visual Studio 2022 Light";

            public override IEnumerable<string> ThemeResources
            {
                get
                {
                    yield return "/AakStudio.Shell.UI;component/Themes/VisualStudio2022/LightTheme.xaml";
                    yield return "/AakStudio.Shell.UI.Themes.AvalonDock;component/Themes/VisualStudio2022/LightTheme.xaml";
                }
            }
        }

        public static List<AakTheme> AllThemes { get; }

        static AakThemeCollection()
        {
            AllThemes = new List<AakTheme>
            {
                new AakVS2019Blue(),
                new AakVS2019Dark(),
                new AakVS2019Light(),
                new AakVS2022Blue(),
                new AakVS2022Dark(),
                new AakVS2022Light()
            };
        }
    }
}