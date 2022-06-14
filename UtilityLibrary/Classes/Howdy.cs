using static System.DateTime;
namespace UtilityLibrary.Classes
{
    public static class Howdy
    {
        public static string TimeOfDay() => Now.Hour switch
        {
            <= 12 => "Good Morning",
            <= 16 => "Good Afternoon",
            <= 20 => "Good Evening",
            _ => "Good Night"
        };


    }
}
