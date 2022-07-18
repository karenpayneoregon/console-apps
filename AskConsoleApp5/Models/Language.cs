namespace AskConsoleApp5.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public override string ToString() => Title;
    }
}
