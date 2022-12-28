using Aak.Shell.UI.Showcase.ControlViews;
using Aak.Shell.UI.Showcase.Interfaces;
using System.Collections.ObjectModel;

namespace Aak.Shell.UI.Showcase.ViewModels.Collection
{
    internal sealed class AdvancedCollectionViewModel : AakCollectionViewModel
    {
        public AdvancedCollectionViewModel(StyleSelectorViewModel parent) : base(parent, "Advanced Controls", "Advanced", true)
        {
            Items = new ObservableCollection<IAakDocumentWell>()
        {
            new AakDocumentWellViewModel(new TreeListViewView(), "TreeListView", this),
        };
        }
    }
}