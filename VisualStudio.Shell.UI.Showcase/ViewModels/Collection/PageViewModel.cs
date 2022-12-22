using System.Windows;
using System.Windows.Input;
using VisualStudio.Shell.UI.Showcase.Commands;

namespace VisualStudio.Shell.UI.Showcase.ViewModels.Collection;

internal sealed class PageViewModel : ViewModelBase
{
    public CollectionViewModel Parent { get; }

    public UIElement View
    {
        get => view;
        set => OnPropertyChanged(ref view, value, nameof(View));
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

    public PageViewModel(UIElement view, string displayName, CollectionViewModel parent)
    {
        this.Parent = parent;

        this.activeCommand = new RelayCommand(OnActive);
        this.closeCommand = new RelayCommand(OnClose);
        this.displayName = displayName;
        this.view = view;
    }

    private UIElement view;
    private bool isSelected;
    private string displayName;
    private ICommand activeCommand;
    private ICommand closeCommand;

    private void OnActive()
    {
        this.Parent.ActiveDocument(this);
    }

    private void OnClose()
    {
        this.Parent.CloseTab(this);
    }
}
