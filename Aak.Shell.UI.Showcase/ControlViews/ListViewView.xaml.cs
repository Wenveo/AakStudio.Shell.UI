using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Aak.Shell.UI.Showcase.ControlViews
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

    public class SimpleData
    {
        public int Id { get; }

        public string Name { get; }

        public string Description { get; }

        public SimpleData(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
