﻿using Aak.Shell.UI.Showcase.Commands;
using Aak.Shell.UI.Showcase.ViewModels.Collection;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Aak.Shell.UI.Showcase.ViewModels;

internal sealed class StyleSelectorViewModel : ViewModelBase
{
    private readonly WorkSpaceViewModel workSpaceViewModel;

    public ObservableCollection<CollectionViewModel> Collections
    {
        get => collections;
        set => OnPropertyChanged(ref collections, value, nameof(Collections));
    }

    public ICommand CloseCommand
    {
        get => closeCommand;
        set => OnPropertyChanged(ref closeCommand, value, nameof(CloseCommand));
    }

    public StyleSelectorViewModel(WorkSpaceViewModel workSpaceViewModel)
    {
        this.workSpaceViewModel = workSpaceViewModel;
        this.collections = new ObservableCollection<CollectionViewModel>
        {
            new AdvancedCollectionViewModel(this),
            new BasicCollectionViewModel(this)
        };

        this.closeCommand = new RelayCommand(OnClose);
    }

    private ObservableCollection<CollectionViewModel> collections;
    private ICommand closeCommand;

    private void OnClose()
    {
        this.workSpaceViewModel.CloseAnchor(this);
    }

    internal void ActiveDocument(ViewModelBase viewModelBase)
    {
        this.workSpaceViewModel.AddOrActiveDocument(viewModelBase);
    }

    internal void CloseTab(ViewModelBase viewModelBase)
    {
        this.workSpaceViewModel.CloseDocument(viewModelBase);
    }
}
