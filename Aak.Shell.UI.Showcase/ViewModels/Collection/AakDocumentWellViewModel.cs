using Aak.Shell.UI.Showcase.Shell;
using System.Windows;

namespace Aak.Shell.UI.Showcase.ViewModels.Collection;

internal sealed class AakDocumentWellViewModel : AakDocumentWell
{
    public AakCollectionViewModel Parent { get; }

    public AakDocumentWellViewModel(UIElement view, string title, AakCollectionViewModel parent)
    {
        this.Parent = parent;
        this.Title = title;
        this.View = view;
    }

    protected override void OnActive()
    {
        this.Parent.ActiveDocument(this);
    }

    protected override void OnClose()
    {
        this.Parent.CloseTab(this);
    }
}
