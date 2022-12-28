using System.Windows.Input;

namespace Aak.Shell.UI.Showcase.Interfaces
{
    internal interface IAakDocumentWell : IAakViewElement
    {
        ICommand ActiveCommand { get; }

        ICommand CloseCommand { get; }

        string? ToolTip { get; }
    }
}