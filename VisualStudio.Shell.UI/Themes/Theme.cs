using System.Windows;

namespace VisualStudio.Shell.UI.Themes
{
    public abstract class Theme
    {
        public virtual string Name { get; set; }
        public virtual bool IsDark { get; set; }
        public virtual bool IsLight { get; set; }

        public virtual ResourceDictionary Current { get; set; }

        public Theme(string name, bool isDark, bool isLight, ResourceDictionary resourceDictionary)
        {
            this.Name = name;
            this.IsDark = isDark;
            this.IsLight = isLight;
            this.Current = resourceDictionary;
        }
    }
}