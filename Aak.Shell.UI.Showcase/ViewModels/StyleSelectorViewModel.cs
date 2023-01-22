using System.Collections.ObjectModel;

using Aak.Shell.UI.Showcase.Shell;
using Aak.Shell.UI.Showcase.ViewModels.Collection;
using Aak.Shell.UI.Showcase.Views;

namespace Aak.Shell.UI.Showcase.ViewModels
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