namespace Aak.Shell.UI.Showcase.Models
{
    internal sealed class SimpleData
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
