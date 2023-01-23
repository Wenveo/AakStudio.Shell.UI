using System.Collections.ObjectModel;

using Aak.Shell.UI.Showcase.ControlViews;
using Aak.Shell.UI.Showcase.Shell;

namespace Aak.Shell.UI.Showcase.ViewModels.Collection
{
    internal sealed class BasicCollectionViewModel : AakCollectionViewModel
    {
        public BasicCollectionViewModel(StyleSelectorViewModel parent) : base(parent, "WPF Basic Control Styles", "Basic", true)
        {
            Items = new ObservableCollection<AakDocumentWell>()
            {
                new AakDocumentWellViewModel(new ButtonView(), "Button", this),
                new AakDocumentWellViewModel(new CheckBoxView(), "CheckBox", this),
                new AakDocumentWellViewModel(new ComboBoxView(), "ComboBox", this),
                new AakDocumentWellViewModel(new ContextMenuView(), "ContextMenu", this),
                new AakDocumentWellViewModel(new ExpanderView(), "Expander", this),
                new AakDocumentWellViewModel(new GridSplitterView(), "GridSplitter", this),
                new AakDocumentWellViewModel(new GroupBoxView(), "GroupBox", this),
                new AakDocumentWellViewModel(new HyperlinkView(), "Hyperlink", this),
                new AakDocumentWellViewModel(new LabelView(), "Label", this),
                new AakDocumentWellViewModel(new ListBoxView(), "ListBox", this),
                new AakDocumentWellViewModel(new ListViewView(), "ListView", this),
                new AakDocumentWellViewModel(new MenuView(), "Menu", this),
                new AakDocumentWellViewModel(new PasswordBoxView(), "PasswordBox", this),
                new AakDocumentWellViewModel(new ProgressBarView(), "ProgressBar", this),
                new AakDocumentWellViewModel(new ScrollViewView(), "ScrollView", this),
                new AakDocumentWellViewModel(new StatusBarView(), "StatusBar", this),
                new AakDocumentWellViewModel(new TabControlView(), "TabControl", this),
                new AakDocumentWellViewModel(new TextBoxView(), "TextBox", this),
                new AakDocumentWellViewModel(new ToolBarView(), "ToolBar", this),
                new AakDocumentWellViewModel(new ToolTipView(), "ToolTip", this),
                new AakDocumentWellViewModel(new TreeViewView(), "TreeView", this)
            };
        }
    }
}