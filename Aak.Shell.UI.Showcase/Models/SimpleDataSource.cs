using System.Collections.ObjectModel;

namespace Aak.Shell.UI.Showcase.Models
{
    internal sealed class SimpleDataSource
    {
        private static SimpleDataSource? instance;

        public static SimpleDataSource Instance => instance ??= new();

        public ObservableCollection<SimpleData> DataSource { get; }

        public SimpleDataSource()
        {
            DataSource = new ObservableCollection<SimpleData>();

            for (var i = 0; i < 30; i++)
            {
                DataSource.Add(new SimpleData(i, "SubItem", $"SimpleData {i}"));
            }
        }
    }
}
