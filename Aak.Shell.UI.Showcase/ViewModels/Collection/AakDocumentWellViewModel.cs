using System.Windows;

using Aak.Shell.UI.Showcase.Shell;

namespace Aak.Shell.UI.Showcase.ViewModels.Collection
{
    internal sealed class AakDocumentWellViewModel : AakDocumentWell
    {
        public AakCollectionViewModel Parent { get; }

        public AakDocumentWellViewModel(UIElement view, string title, AakCollectionViewModel parent)
        {
            Parent = parent;
            Title = title;
            View = view;
        }

        protected override void OnActive()
        {
            Parent.ActiveDocument(this);
        }

        protected override void OnClose()
        {
            Parent.CloseTab(this);
        }
    }
}