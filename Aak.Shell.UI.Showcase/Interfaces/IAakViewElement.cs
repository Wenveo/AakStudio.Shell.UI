using System.Windows;

namespace Aak.Shell.UI.Showcase.Interfaces
{
    internal interface IAakViewElement
    {
        UIElement? View { get; }

        string? Title { get; }

        bool IsActive { get; set; }

        bool IsSelected { get; set; }
    }
}