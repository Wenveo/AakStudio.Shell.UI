using System.Windows;
using System.Windows.Controls;

namespace Aak.Shell.UI.Controls
{
    public class TreeListViewItem : ListViewItem
    {
        static TreeListViewItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListViewItem), new FrameworkPropertyMetadata(typeof(TreeListViewItem)));
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            if (newContent is TreeListViewNode node)
            {
                node.ExpandedChanged += OnExpandedChanged;
            }
            if (oldContent is TreeListViewNode n)
            {
                n.ExpandedChanged -= OnExpandedChanged;
            }
            base.OnContentChanged(oldContent, newContent);
        }

        private void OnExpandedChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            if (ItemsControl.ItemsControlFromItemContainer(this) is TreeListView tree)
            {
                tree.Reload();
            }
        }
    }
}
