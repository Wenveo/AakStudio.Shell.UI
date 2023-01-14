using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using Aak.Shell.UI.Showcase.Commands;
using Aak.Shell.UI.Showcase.Interfaces;

namespace Aak.Shell.UI.Showcase.ViewModels
{
    internal sealed class WorkSpaceViewModel : ViewModelBase
    {
        public ObservableCollection<IAakToolWell> Anchorables
        {
            get => anchorables;
            set => OnPropertyChanged(ref anchorables, value, nameof(Anchorables));
        }

        public ObservableCollection<IAakDocumentWell> DocumentViews
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

        public IAakViewElement? ActiveDocument
        {
            get => activeDocument;
            set => OnPropertyChanged(ref activeDocument, value, nameof(ActiveDocument));
        }

        public ICommand ThemeSwitchCommand
        {
            get => themeSwitchCommand ??= new RelayCommand<AakTheme>(OnThemeSwitch);
        }

        public WorkSpaceViewModel()
        {
            StyleSelector = new StyleSelectorViewModel(this);
            currentTheme = AakXamlUIResource.Instance.Theme;

            anchorables = new ObservableCollection<IAakToolWell>() { StyleSelector };
            documentViews = new ObservableCollection<IAakDocumentWell>();
        }

        public StyleSelectorViewModel StyleSelector { get; }

        private ObservableCollection<IAakToolWell> anchorables;
        private ObservableCollection<IAakDocumentWell> documentViews;
        private AakTheme currentTheme;

        private IAakViewElement? activeDocument;
        private ICommand? themeSwitchCommand;



        private void OnThemeSwitch(AakTheme? newTheme)
        {
            if (newTheme is not null)
            {
                CurrentTheme = newTheme;
            }
        }

        public void AddOrActiveDocument(IAakDocumentWell view)
        {
            var item = DocumentViews.FirstOrDefault(x => x == view);
            if (item == null)
            {
                item = view;
                DocumentViews.Add(item);
            }
            ActiveDocument = item;
        }

        public void CloseDocument(IAakDocumentWell view)
        {
            if (DocumentViews.Contains(view))
            {
                DocumentViews.Remove(view);
                ActiveDocument = DocumentViews.FirstOrDefault();
            }
        }

        public void AddOrActiveAnchor(IAakToolWell view)
        {
            var item = Anchorables.FirstOrDefault(x => x == view);
            if (item == null)
            {
                item = view;
                Anchorables.Add(item);
            }
            ActiveDocument = item;
        }

        public void CloseAnchor(IAakToolWell view)
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