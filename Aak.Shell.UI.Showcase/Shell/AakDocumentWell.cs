using System.Windows.Input;

using Aak.Shell.UI.Showcase.Commands;
using Aak.Shell.UI.Showcase.Interfaces;

namespace Aak.Shell.UI.Showcase.Shell
{
    internal abstract class AakDocumentWell : AakViewElement, IAakDocumentWell
    {
        public ICommand ActiveCommand
        {
            get => activeCommand ??= new RelayCommand(OnActive);
        }

        public ICommand CloseCommand
        {
            get => closeCommand ??= new RelayCommand(OnClose);
        }

        public string? ToolTip
        {
            get => toolTip;
            set => SetProperty(ref toolTip, value);
        }

        protected abstract void OnActive();

        protected abstract void OnClose();

        public ICommand? activeCommand;
        public ICommand? closeCommand;
        private string? toolTip;
    }
}