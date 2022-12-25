using Aak.Shell.UI.Showcase.Interfaces;
using Aak.Shell.UI.Showcase.Shell;
using Aak.Shell.UI.Showcase.ViewModels.Collection;
using Aak.Shell.UI.Showcase.Views;
using System.Collections.ObjectModel;

namespace Aak.Shell.UI.Showcase.ViewModels;

internal sealed class StyleSelectorViewModel : AakToolWell
{
    public ObservableCollection<AakCollectionViewModel> Collections
    {
        get => collections;
        set => SetProperty(ref collections, value);
    }

    public StyleSelectorViewModel(WorkSpaceViewModel workSpaceViewModel)
    {
        this.workSpaceViewModel = workSpaceViewModel;
        this.collections = new ObservableCollection<AakCollectionViewModel>
        {
            new AdvancedCollectionViewModel(this),
            new BasicCollectionViewModel(this)
        };

        Title = "Wpf Base Styles";
        View = new StyleSelectorView { DataContext = this };
    }

    private readonly WorkSpaceViewModel workSpaceViewModel;
    private ObservableCollection<AakCollectionViewModel> collections;


    internal void ActiveDocument(IAakDocumentWell view)
    {
        this.workSpaceViewModel.AddOrActiveDocument(view);
    }

    internal void CloseTab(IAakDocumentWell view)
    {
        this.workSpaceViewModel.CloseDocument(view);
    }
}
