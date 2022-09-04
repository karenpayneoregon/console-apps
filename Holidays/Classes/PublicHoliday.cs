#nullable disable
namespace Holidays.Classes;

class PublicHoliday
{
    public DateTime Date { get; set; }
    public string LocalName { get; set; }
    public string Name { get; set; }
    public string CountryCode { get; set; }
    public bool Fixed { get; set; }
    public bool Global { get; set; }
    public string[] Counties { get; set; }
    public int? LaunchYear { get; set; }
    public string[] Types { get; set; }

    private sealed class DateEqualityComparer : IEqualityComparer<PublicHoliday>
    {
        public bool Equals(PublicHoliday x, PublicHoliday y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Date.Equals(y.Date);
        }

        public int GetHashCode(PublicHoliday obj) => obj.Date.GetHashCode();

    }

    public static IEqualityComparer<PublicHoliday> DateComparer { get; } = new DateEqualityComparer();

}