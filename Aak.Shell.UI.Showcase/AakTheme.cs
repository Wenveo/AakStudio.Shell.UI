using System;
using System.Collections.Generic;
using System.Windows;

namespace Aak.Shell.UI.Showcase
{
    internal abstract class AakTheme : ResourceDictionary
    {
        public abstract string Name { get; }

        public abstract IEnumerable<string> ThemeResources { get; }

        protected AakTheme()
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
}