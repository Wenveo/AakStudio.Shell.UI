namespace Aak.Shell.UI.Showcase.Interfaces
{
    internal interface IAakToolWell : IAakViewElement
    {
        bool CanHide { get; set; }

        bool IsVisible { get; set; }
    }
}