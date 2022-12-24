using Aak.Shell.UI.Controls;
using Aak.Shell.UI.Showcase.ViewModels.Collection;

namespace Aak.Shell.UI.Showcase;

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
            dockingManager.ActiveContent is CollectionViewModel ||
            dockingManager.ActiveContent is PageViewModel))
        {
            mainStatusBar.ClearValue(BackgroundProperty);
            mainStatusBar.ClearValue(ForegroundProperty);

            isCleanValue = true;
        }
    }
}
