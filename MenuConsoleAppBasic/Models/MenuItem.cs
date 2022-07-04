namespace MenuConsoleAppBasic.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public override string ToString() => Text;

    }
}
