using System.Collections.ObjectModel;
using System.Linq;
using Aak.Shell.UI.Themes;

namespace Aak.Shell.UI.Showcase.ViewModels;

internal sealed class WorkSpaceViewModel : ViewModelBase
{
    public ObservableCollection<ViewModelBase> Anchorables
    {
        get => anchorables;
        set => OnPropertyChanged(ref anchorables, value, nameof(Anchorables));
    }

    public ObservableCollection<ViewModelBase> DocumentViews
    {
        get => documentViews;
        set => OnPropertyChanged(ref documentViews, value, nameof(DocumentViews));
    }

    public ObservableCollection<Theme> Themes
    {
        get => themes;
        set => OnPropertyChanged(ref themes, value, nameof(Themes));
    }

    public Theme CurrentTheme
    {
        get => currentTheme;
        set
        {
            XamlUIResources.Instance.Theme = value;
            OnPropertyChanged(ref currentTheme, value, nameof(CurrentTheme));
        }
    }

    public ViewModelBase? ActiveDocument
    {
        get => activeDocument;
        set => OnPropertyChanged(ref activeDocument, value, nameof(ActiveDocument));
    }
    public WorkSpaceViewModel()
    {
        stylesViewModel = new StyleSelectorViewModel(this);

        themes = new ObservableCollection<Theme>()
        {
            new VisualStudio2019Blue    (),
            new VisualStudio2019Dark    (),
            new VisualStudio2019Light   (),
            new VisualStudio2022Blue    (),
            new VisualStudio2022Dark    (),
            new VisualStudio2022Light   (),
        };
        currentTheme = themes.Last();

        anchorables = new ObservableCollection<ViewModelBase>() { stylesViewModel };
        documentViews = new ObservableCollection<ViewModelBase>();
    }

    private readonly StyleSelectorViewModel stylesViewModel;

    private ObservableCollection<ViewModelBase> anchorables;
    private ObservableCollection<ViewModelBase> documentViews;
    private ObservableCollection<Theme> themes;
    private Theme currentTheme;
    private ViewModelBase? activeDocument;

    public void AddOrActiveDocument(ViewModelBase view)
    {
        var item = DocumentViews.FirstOrDefault(x => x == view);
        if (item == null)
        {
            item = view;
            DocumentViews.Add(item);
        }
        ActiveDocument = item;
    }

    public void CloseDocument(ViewModelBase view)
    {

        if (DocumentViews.Contains(view))
        {
            DocumentViews.Remove(view);
            ActiveDocument = DocumentViews.FirstOrDefault();
        }
    }

    public void CloseAnchor(ViewModelBase view)
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
