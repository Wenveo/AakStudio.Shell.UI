using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace AakStudio.Shell.UI.Showcase.Shell
{
    internal abstract class AakCollection : AakDocumentWell
    {
        public bool IsExpanded
        {
            get => isExpanded;
            set => SetProperty(ref isExpanded, value);
        }

        public string? DisplayName
        {
            get => displayName;
            set => SetProperty(ref displayName, value);
        }

        public virtual IEnumerable<UIElement>? Views
        {
            get
            {
                yield break;
            }
        }

        public ObservableCollection<AakDocumentWell>? Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        private ObservableCollection<AakDocumentWell>? items;
        private string? displayName;
        private bool isExpanded;
    }
}