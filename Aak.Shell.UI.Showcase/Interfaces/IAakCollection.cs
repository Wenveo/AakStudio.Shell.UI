using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Aak.Shell.UI.Showcase.Interfaces
{
    internal interface IAakCollection : IAakDocumentWell
    {
        bool IsExpanded { get; }

        string? DisplayName { get; }

        IEnumerable<UIElement>? Views { get; }

        ObservableCollection<IAakDocumentWell>? Items { get; }
    }
}