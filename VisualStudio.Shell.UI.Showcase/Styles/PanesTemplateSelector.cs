using System.Windows;
using System.Windows.Controls;
using VisualStudio.Shell.UI.Showcase.ViewModels;
using VisualStudio.Shell.UI.Showcase.ViewModels.Collection;

namespace VisualStudio.Shell.UI.Showcase.Styles;

internal sealed class PanesTemplateSelector : DataTemplateSelector
{
    public PanesTemplateSelector()
    {
    }

    public DataTemplate? PageViewTemplate
    {
        get;
        set;
    }

    public DataTemplate? StyleSelectorTemplate
    {
        get;
        set;
    }

    public DataTemplate? CollectionViewTemplate
    {
        get;
        set;
    }


    public override DataTemplate? SelectTemplate(object item, DependencyObject container)
    {
        if (item is PageViewModel)
            return PageViewTemplate;

        if (item is StyleSelectorViewModel)
            return StyleSelectorTemplate;

        if (item is CollectionViewModel)
            return CollectionViewTemplate;

        return base.SelectTemplate(item, container);
    }
}
