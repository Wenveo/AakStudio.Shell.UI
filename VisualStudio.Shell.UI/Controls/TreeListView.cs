using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace VisualStudio.Shell.UI.Controls
{
    public class TreeListView : ListView
    {
        public static readonly DependencyProperty RootProperty =
            DependencyProperty.Register(nameof(Root), typeof(TreeListViewNode), typeof(TreeListView), new PropertyMetadata(null, OnRootChanged));

        public TreeListViewNode Root
        {
            get { return (TreeListViewNode)GetValue(RootProperty); }
            set { SetValue(RootProperty, value); }
        }

        static TreeListView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListView), new FrameworkPropertyMetadata(typeof(TreeListView)));
            SelectionModeProperty.OverrideMetadata(typeof(TreeListView), new FrameworkPropertyMetadata(SelectionMode.Extended));
            VirtualizingStackPanel.VirtualizationModeProperty.OverrideMetadata(typeof(TreeListView), new FrameworkPropertyMetadata(VirtualizationMode.Recycling));
        }

        public TreeListView()
        {
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TreeListViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is TreeListViewItem;
        }

        private static void OnRootChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TreeListView tree)
            {
                tree.ItemsSource = tree.Root.ToList();
            }

            if (e.NewValue is TreeListViewNode newNode)
                newNode.IsRoot = true;
            if (e.OldValue is TreeListViewNode oldNode)
                oldNode.IsRoot = false;
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            if (element is TreeListViewItem treeItem && item is TreeListViewNode node)
            {
                treeItem.Content = node;
                node.Container = treeItem;
                node.IsLoaded = true;
            }
            base.PrepareContainerForItemOverride(element, item);
        }

        protected override void ClearContainerForItemOverride(DependencyObject element, object item)
        {
            if (element is TreeListViewItem treeItem && item is TreeListViewNode node)
            {
                treeItem.Content = null;
                node.Container = null;
                node.IsLoaded = false;

            }
            base.ClearContainerForItemOverride(element, item);
        }

        public void Reload()
        {
            if (this.Root is null)
                return;

            var list = this.Root.ToList();
            if (list.Any())
            {
                list.RemoveAt(0);
                this.Root.IsExpanded = true;
            }
            this.ItemsSource = list;
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == RootProperty)
            {
                this.Reload();
            }
        }
    }
}
