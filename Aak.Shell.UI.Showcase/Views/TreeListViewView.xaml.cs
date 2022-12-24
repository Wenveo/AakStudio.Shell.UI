using System.Windows.Controls;
using Aak.Shell.UI.Controls;

namespace Aak.Shell.UI.Showcase.Views
{
    /// <summary>
    /// TreeListViewView.xaml 的交互逻辑
    /// </summary>
    public partial class TreeListViewView : UserControl
    {
        public TreeListViewView()
        {
            InitializeComponent();

            this.DefaultTreeListView.Root = CreateTreeListViewRoot();
            this.DefaultTreeGridView.Root = CreateTreeGridViewRoot();

            this.DisabledTreeListView.Root = CreateTreeListViewRoot();
            this.DisabledTreeGridView.Root = CreateTreeGridViewRoot();
        }

        private TreeListViewNode CreateTreeListViewRoot()
        {
            var root = new TreeListViewNode() { IsExpanded = true };

            for (int i = 0; i < 8; i++)
            {
                root.Children.Add(new TreeListViewNode() { Content = $"Children - {i}" });
            }

            root.Children[2].IsExpanded = true;
            for (int i = 0; i < 3; i++)
            {
                root.Children[0].Children.Add(new TreeListViewNode() { Content = $"Children - 0 - {i}" });
                root.Children[2].Children.Add(new TreeListViewNode() { Content = $"Children - 2 - {i}" });
                root.Children[4].Children.Add(new TreeListViewNode() { Content = $"Children - 4 - {i}" });
            }

            return root;
        }

        private TreeListViewNode CreateTreeGridViewRoot()
        {
            var order = 0;
            var root = new TreeListViewNode() { IsExpanded = true };

            var book2 = new Book("BookName 1", order++);
            for (int i = 0; i < 20; i++)
            {
                book2.Children.Add(new Book($"BookName {i}", order++));
            }

            root.Children.Add(book2);

            for (int i = 0; i < 5; i++)
            {
                root.Children.Add(new Book($"BookName {order}", order++));
            }

            return root;
        }
    }

    public class Book : TreeListViewNode
    {
        public int Order { get; set; }

        public Book(string text, int order) : base()
        {
            this.Order = order;
            this.Content = text;
        }
    }
}
