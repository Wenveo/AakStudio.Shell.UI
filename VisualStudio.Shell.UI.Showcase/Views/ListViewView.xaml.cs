using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace VisualStudio.Shell.UI.Showcase.Views
{
    /// <summary>
    /// ListViewView.xaml 的交互逻辑
    /// </summary>
    public partial class ListViewView : UserControl
    {
        public ObservableCollection<SimpleData> Datas { get; set; }
        public ListViewView()
        {
            Datas = new ObservableCollection<SimpleData>();

            for (int i = 0; i < 30; i++)
            {
                Datas.Add(new SimpleData(i, "ListViewItem", $"SimpleData {i}"));
            }

            InitializeComponent();
        }
    }

    public record SimpleData(int ID, string Name, string Description);
}
