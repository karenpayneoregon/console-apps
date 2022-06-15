using System;

namespace ConsoleWeb.Classes
{
    public static class Helpers
    {
        public static string TimeOfDay() =>
            DateTime.Now.Hour switch
            {
                <= 12 => "Morning",
                <= 16 => "Afternoon",
                <= 20 => "Evening",
                _ => "Night"
            };
    }
}
