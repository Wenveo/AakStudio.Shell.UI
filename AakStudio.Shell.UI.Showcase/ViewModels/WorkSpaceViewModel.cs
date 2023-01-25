using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using AakStudio.Shell.UI.Showcase.Commands;
using AakStudio.Shell.UI.Showcase.Shell;

namespace AakStudio.Shell.UI.Showcase.ViewModels
{
    internal sealed class WorkSpaceViewModel : ViewModelBase
    {
        public static WorkSpaceViewModel Default { get; } = new WorkSpaceViewModel();

        public ObservableCollection<AakToolWell> Anchorables
        {
            get => anchorables;
            set => OnPropertyChanged(ref anchorables, value, nameof(Anchorables));
        }

        public ObservableCollection<AakDocumentWell> DocumentViews
        {
            get => documentViews;
            set => OnPropertyChanged(ref documentViews, value, nameof(DocumentViews));
        }

        public AakTheme CurrentTheme
        {
            get => currentTheme;
            set
            {
                AakXamlUIResource.Instance.Theme = value;
                OnPropertyChanged(ref currentTheme, value, nameof(CurrentTheme));
            }
        }

        public AakViewElement? ActiveDocument
        {
            get => activeDocument;
            set => OnPropertyChanged(ref activeDocument, value, nameof(ActiveDocument));
        }

        public ICommand ThemeSwitchCommand
        {
            get => themeSwitchCommand ??= new RelayCommand<AakTheme>(OnThemeSwitch);
        }

        private WorkSpaceViewModel()
        {
            StyleSelector = new StyleSelectorViewModel(this);
            currentTheme = AakXamlUIResource.Instance.Theme;

            anchorables = new ObservableCollection<AakToolWell>() { StyleSelector };
            documentViews = new ObservableCollection<AakDocumentWell>();
        }

        public StyleSelectorViewModel StyleSelector { get; }

        private ObservableCollection<AakToolWell> anchorables;
        private ObservableCollection<AakDocumentWell> documentViews;
        private AakTheme currentTheme;

        private AakViewElement? activeDocument;
        private ICommand? themeSwitchCommand;

        private void OnThemeSwitch(AakTheme? newTheme)
        {
            if (newTheme is not null)
            {
                CurrentTheme = newTheme;
            }
        }

        public void AddOrActiveDocument(AakDocumentWell view)
        {
            var item = DocumentViews.FirstOrDefault(x => x == view);
            if (item == null)
            {
                item = view;
                DocumentViews.Add(item);
            }
            ActiveDocument = item;
        }

        public void CloseDocument(AakDocumentWell view)
        {
            if (DocumentViews.Contains(view))
            {
                DocumentViews.Remove(view);
                ActiveDocument = DocumentViews.FirstOrDefault();
            }
        }

        public void AddOrActiveAnchor(AakToolWell view)
        {
            var item = Anchorables.FirstOrDefault(x => x == view);
            if (item == null)
            {
                item = view;
                Anchorables.Add(item);
            }
            ActiveDocument = item;
        }

        public void CloseAnchor(AakToolWell view)
        {
            if (Anchorables.Contains(view))
            {
                Anchorables.Remove(view);
                if (Anchorables.Count == 0)
                {
                    ActiveDocument = DocumentViews.FirstOrDefault();
                }
                else
                {
                    ActiveDocument = Anchorables.FirstOrDefault();
                }
            }
        }
    }
}