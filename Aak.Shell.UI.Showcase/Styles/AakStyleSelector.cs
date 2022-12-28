using Aak.Shell.UI.Showcase.Shell;
using System.Windows;
using System.Windows.Controls;

namespace Aak.Shell.UI.Showcase.Styles
{
    internal sealed class AakStyleSelector : StyleSelector
    {
        public Style? AakDocumentWellStyle
        {
            get;
            set;
        }

        public Style? AakToolWellStyle
        {
            get;
            set;
        }

        public override Style? SelectStyle(object item, DependencyObject container)
        {
            if (item is AakDocumentWell)
                return AakDocumentWellStyle;

            if (item is AakToolWell)
                return AakToolWellStyle;

            return base.SelectStyle(item, container);
        }
    }
}