namespace MenuSimpleApp.Classes
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public override string ToString() => Name;
    }
}