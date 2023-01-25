using System.Collections.ObjectModel;

using AakStudio.Shell.UI.Showcase.Shell;
using AakStudio.Shell.UI.Showcase.ViewModels.Collection;
using AakStudio.Shell.UI.Showcase.Views;

namespace AakStudio.Shell.UI.Showcase.ViewModels
{
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
            collections = new ObservableCollection<AakCollectionViewModel>
            {
                new BasicCollectionViewModel(this)
            };

            Title = "Wpf Base Styles";
            View = new StyleSelectorView { DataContext = this };
        }

        private readonly WorkSpaceViewModel workSpaceViewModel;
        private ObservableCollection<AakCollectionViewModel> collections;


        internal void ActiveDocument(AakDocumentWell view)
        {
            workSpaceViewModel.AddOrActiveDocument(view);
        }

        internal void CloseTab(AakDocumentWell view)
        {
            workSpaceViewModel.CloseDocument(view);
        }
    }
}