using System.Collections.ObjectModel;
using System.Windows.Input;
using VisualStudio.Shell.UI.Showcase.Commands;

namespace VisualStudio.Shell.UI.Showcase.ViewModels.Collection;

internal class CollectionViewModel : ViewModelBase
{
    public StyleSelectorViewModel Parent { get; }

    public bool IsExpanded
    {
        get => isExpanded;
        set => OnPropertyChanged(ref isExpanded, value, nameof(IsExpanded));
    }

    public bool IsSelected
    {
        get => isSelected;
        set => OnPropertyChanged(ref isSelected, value, nameof(IsSelected));
    }

    public string DisplayName
    {
        get => displayName;
        set => OnPropertyChanged(ref displayName, value, nameof(DisplayName));
    }

    public string Title
    {
        get => title;
        set => OnPropertyChanged(ref title, value, nameof(Title));
    }

    public ObservableCollection<PageViewModel> Items
    {
        get => items;
        set => OnPropertyChanged(ref items, value, nameof(Items));
    }

    public ICommand ActiveCommand
    {
        get => activeCommand;
        set => OnPropertyChanged(ref activeCommand, value, nameof(ActiveCommand));
    }

    public ICommand CloseCommand
    {
        get => closeCommand;
        set => OnPropertyChanged(ref closeCommand, value, nameof(CloseCommand));
    }

    public CollectionViewModel(StyleSelectorViewModel parent, string title, string displayName, bool isExpanded = false)
    {
        this.Parent = parent;

        this.title = title;
        this.isExpanded = isExpanded;
        this.displayName = displayName;
        this.items = new ObservableCollection<PageViewModel>();

        this.activeCommand = new RelayCommand(OnActive);
        this.closeCommand = new RelayCommand(OnClose);
    }

    private bool isExpanded;
    private bool isSelected;
    private string displayName;
    private string title;
    private ObservableCollection<PageViewModel> items;
    private ICommand activeCommand;
    private ICommand closeCommand;

    private void OnActive()
    {
        if (isSubItemActive)
        {
            isSubItemActive = false;
            return;
        }
        this.Parent.ActiveDocument(this);
    }

    private void OnClose()
    {
        this.Parent.CloseTab(this);
    }

    private bool isSubItemActive;
    internal void ActiveDocument(ViewModelBase viewModelBase)
    {
        isSubItemActive = true;
        this.Parent.ActiveDocument(viewModelBase);
    }
    internal void CloseTab(ViewModelBase viewModelBase)
    {
        this.Parent.CloseTab(viewModelBase);
    }
}
