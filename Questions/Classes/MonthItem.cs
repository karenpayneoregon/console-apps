namespace Questions.Classes
{
    public class MonthItem
    {
        public int Index { get; }
        public string Name { get; }

        public MonthItem(int index, string name)
        {
            Index = index;
            Name = name;
        }

        public override string ToString() => Name;
    }
}