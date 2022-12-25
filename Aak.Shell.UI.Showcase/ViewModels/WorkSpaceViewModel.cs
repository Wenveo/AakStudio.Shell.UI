using Aak.Shell.UI.Showcase.Commands;
using Aak.Shell.UI.Showcase.Interfaces;
using Aak.Shell.UI.Themes;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Aak.Shell.UI.Showcase.ViewModels;

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

    public IAakViewElement? ActiveDocument
    {
        get => activeDocument;
        set => OnPropertyChanged(ref activeDocument, value, nameof(ActiveDocument));
    }

    public ICommand ThemeSwitchCommand
    {
        get => themeSwitchCommand ??= new RelayCommand<string>(OnThemeSwitch);
    }

    public WorkSpaceViewModel()
    {
        StyleSelector = new StyleSelectorViewModel(this);

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

        anchorables = new ObservableCollection<IAakToolWell>() { StyleSelector };
        documentViews = new ObservableCollection<IAakDocumentWell>();
    }

    public StyleSelectorViewModel StyleSelector { get; }

    private ObservableCollection<IAakToolWell> anchorables;
    private ObservableCollection<IAakDocumentWell> documentViews;
    private ObservableCollection<Theme> themes;
    private Theme currentTheme;

    private IAakViewElement? activeDocument;
    private ICommand? themeSwitchCommand;



    private void OnThemeSwitch(string? themeIndexStr)
    {
        if (!int.TryParse(themeIndexStr, out var index) ||
            index < 0 || index > themes.Count - 1)
        {
            return;
        }

        CurrentTheme = themes[index];
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
