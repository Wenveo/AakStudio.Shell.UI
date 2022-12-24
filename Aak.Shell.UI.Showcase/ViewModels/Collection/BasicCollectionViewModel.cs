using Aak.Shell.UI.Showcase.Commands;
using Aak.Shell.UI.Showcase.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Aak.Shell.UI.Showcase.ViewModels.Collection;

internal sealed class BasicCollectionViewModel : CollectionViewModel
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

    public BasicCollectionViewModel(StyleSelectorViewModel parent) : base(parent, "WPF Basic Control Styles", "Basic", true)
    {
        Items = new ObservableCollection<PageViewModel>()
        {
            new PageViewModel(new ButtonView(), "Button", this),
            new PageViewModel(new CheckBoxView(), "CheckBox", this),
            new PageViewModel(new ComboBoxView(), "ComboBox", this),
            new PageViewModel(new ContextMenuView(), "ContextMenu", this),
            new PageViewModel(new ExpanderView(), "Expander", this),
            new PageViewModel(new GridSplitterView(), "GridSplitter", this),
            new PageViewModel(new GroupBoxView(), "GroupBox", this),
            new PageViewModel(new HyperlinkView(), "Hyperlink", this),
            new PageViewModel(new LabelView(), "Label", this),
            new PageViewModel(new ListBoxView(), "ListBox", this),
            new PageViewModel(new ListViewView(), "ListView", this),
            new PageViewModel(new MenuView(), "Menu", this),
            new PageViewModel(new PasswordBoxView(), "PasswordBox", this),
            new PageViewModel(new ProgressBarView(), "ProgressBar", this),
            new PageViewModel(new ScrollViewView(), "ScrollView", this),
            new PageViewModel(new StatusBarView(), "StatusBar", this),
            new PageViewModel(new TabControlView(), "TabControl", this),
            new PageViewModel(new TextBoxView(), "TextBox", this),
            new PageViewModel(new ToolBarView(), "ToolBar", this),
            new PageViewModel(new ToolTipView(), "ToolTip", this),
            new PageViewModel(new TreeViewView(), "TreeView", this)
        };
    }
}
