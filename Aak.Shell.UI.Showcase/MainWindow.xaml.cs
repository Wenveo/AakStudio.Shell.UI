using Aak.Shell.UI.Controls;
using Aak.Shell.UI.Showcase.ViewModels.Collection;
using AvalonDock.Layout;
using System.Linq;

namespace Aak.Shell.UI.Showcase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public sealed partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool isCleanValue;

        private void dockingManager_ActiveContentChanged(object sender, System.EventArgs e)
        {
            if (!isCleanValue && (
                dockingManager.ActiveContent is AakCollectionViewModel ||
                dockingManager.ActiveContent is AakDocumentWellViewModel))
            {
                mainStatusBar.ClearValue(BackgroundProperty);
                mainStatusBar.ClearValue(ForegroundProperty);

                isCleanValue = true;
            }
        }

        private void MetroWindow_Activated(object sender, System.EventArgs e)
        {
            // if the window is activated, then active the last actived item in docking manager
            var hasFloatingWindow = false;

            var items = dockingManager.Layout.Descendents().OfType<LayoutContent>().ToList();
            for (var i = 0; i < items.Count; i++)
            {
                var item = items[i];
                if (item.IsFloating)
                {
                    if (!hasFloatingWindow)
                        hasFloatingWindow = true;
                    items.RemoveAt(i--);
                }
            }

            if (hasFloatingWindow && items.Count > 0)
            {
                var index = 0;

                var tmpTimeStamp = items[0].LastActivationTimeStamp;
                for (var j = 1; j < items.Count; j++)
                {
                    var item2 = items[j];
                    if (item2.LastActivationTimeStamp > tmpTimeStamp)
                    {
                        tmpTimeStamp = item2.LastActivationTimeStamp;
                        index = j;
                    }
                }

                items[index].IsActive = true;
            }
        }
    }
}