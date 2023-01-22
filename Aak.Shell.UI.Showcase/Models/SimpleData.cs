namespace Aak.Shell.UI.Showcase.Models
{
    internal sealed class SimpleData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public SimpleData(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
