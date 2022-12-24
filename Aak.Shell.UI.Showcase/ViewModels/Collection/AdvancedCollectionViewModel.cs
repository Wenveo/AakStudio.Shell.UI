using Aak.Shell.UI.Showcase.Commands;
using Aak.Shell.UI.Showcase.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Aak.Shell.UI.Showcase.ViewModels.Collection;

internal sealed class AdvancedCollectionViewModel : CollectionViewModel
{
    public IEnumerable<Label> Views
    {
        get
        {
            foreach (var item in Items)
            {
                Label linkLabel = new();
                Hyperlink hyperlink = new(new Run(item.DisplayName))
                {
                    Command = new RelayCommand(() =>
                    {
                        item.IsSelected = true;
                        ActiveDocument(item);
                    })
                };
                linkLabel.Content = hyperlink;
                yield return linkLabel;
            }
        }
    }

    public AdvancedCollectionViewModel(StyleSelectorViewModel parent) : base(parent, "Advanced Controls", "Advanced", true)
    {
        Items = new ObservableCollection<PageViewModel>()
        {
            new PageViewModel(new TreeListViewView(), "TreeListView", this),
        };
    }
}
