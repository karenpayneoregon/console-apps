namespace TraverseFolder.Models
{
    public class Item
    {
        public string Folder { get; }
        public string Name { get; }

        public Item(string folder, string name)
        {
            Folder = folder;
            Name = name;
        }
    }
}