using Aak.Shell.UI.Showcase.Commands;
using Aak.Shell.UI.Showcase.Interfaces;
using Aak.Shell.UI.Showcase.Shell;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Aak.Shell.UI.Showcase.ViewModels.Collection
{
    internal abstract class AakCollectionViewModel : AakCollection
    {
        public StyleSelectorViewModel Parent { get; }

        public override IEnumerable<UIElement>? Views
        {
            get
            {
                if (Items is null)
                {
                    yield break;
                }

                foreach (var item in Items)
                {
                    Label linkLabel = new();
                    Hyperlink hyperlink = new(new Run(item.Title))
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

        public AakCollectionViewModel(StyleSelectorViewModel parent, string title, string displayName, bool isExpanded = false)
        {
            Parent = parent;

            Title = title;
            IsExpanded = isExpanded;
            DisplayName = displayName;
        }

        private bool isSubItemActive;

        protected override void OnActive()
        {
            if (isSubItemActive)
            {
                isSubItemActive = false;
                return;
            }
            this.Parent.ActiveDocument(this);
        }

        protected override void OnClose()
        {
            this.Parent.CloseTab(this);
        }

        internal void ActiveDocument(IAakDocumentWell view)
        {
            isSubItemActive = true;
            this.Parent.ActiveDocument(view);
        }

        internal void CloseTab(IAakDocumentWell view)
        {
            this.Parent.CloseTab(view);
        }
    }
}