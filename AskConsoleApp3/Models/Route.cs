namespace AskConsoleApp3.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public override string ToString() => Title;
    }
}
