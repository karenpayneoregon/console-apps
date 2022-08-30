
namespace ConsoleApp1.Classes;

internal class CronSchedules
{
    public static string EveryMinute => "* * * * *";
    public static string EveryFiveMinutes => "*/5 * * * *";
    public static string Every15Minutes => "*/15 * * * *";
    public static string Every30Minutes => "*/30 * * * *";
}