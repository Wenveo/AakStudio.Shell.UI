using Aak.Shell.UI.Showcase.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Aak.Shell.UI.Showcase.Shell;

internal abstract class AakCollection : AakDocumentWell, IAakCollection
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

    public ObservableCollection<IAakDocumentWell>? Items
    {
        get => items;
        set => SetProperty(ref items, value);
    }

    private ObservableCollection<IAakDocumentWell>? items;
    private string? displayName;
    private bool isExpanded;
}
