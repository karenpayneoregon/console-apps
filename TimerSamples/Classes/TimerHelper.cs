using System.Runtime.InteropServices;
using Timer = System.Threading.Timer;

namespace ThreadingTimerApp.Classes;

public class TimerHelper
{
    [DllImport("user32.dll")]
    private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
    private const byte VkScroll = 0x91;
    private const byte KeyeventfKeyup = 0x2;

    /// <summary>
    /// How long between intervals, currently 20 seconds
    /// </summary>
    public static int Interval = 1000 * 20;
    private static Timer _workTimer;

    /// <summary>
    /// Text to display to listener 
    /// </summary>
    /// <param name="message">text</param>
    public delegate void MessageHandler(string message);
    /// <summary>
    /// Optional event 
    /// </summary>
    public static event MessageHandler Message;
    /// <summary>
    /// Flag to determine if timer should initialize 
    /// </summary>
    public static bool ShouldRun { get; set; } = true;

    /// <summary>
    /// Default initializer
    /// </summary>
    private static void Initialize()
    {
        if (!ShouldRun) return;
        _workTimer = new Timer(Dispatcher);
        _workTimer.Change(Interval, Timeout.Infinite);
    }

    /// <summary>
    /// Initialize with time to delay before triggering <see cref="Worker"/>
    /// </summary>
    /// <param name="interval"></param>
    private static void Initialize(int interval)
    {
        if (!ShouldRun) return;
        Interval = interval;
        _workTimer = new Timer(Dispatcher);
        _workTimer.Change(Interval, Timeout.Infinite);
    }
    /// <summary>
    /// Trigger work, restart timer
    /// </summary>
    /// <param name="e"></param>
    private static void Dispatcher(object e)
    {
        Worker();
        _workTimer.Dispose();
        Initialize();
    }

    /// <summary>
    /// Start timer without an <see cref="Action"/>
    /// </summary>
    public static void Start()
    {
        Initialize();
        Message?.Invoke("Started");
    }

    /// <summary>
    /// Stop timer
    /// </summary>
    public static void Stop()
    {
        _workTimer.Dispose();
        Message?.Invoke("Stopped");
    }

    /// <summary>
    /// This is were work is performed
    /// </summary>
    private static void Worker()
    {
        Message?.Invoke("Performing work");
        PressScrollLock();
        PressScrollLock();
    }
    
    private static void PressScrollLock()
    {
        keybd_event(VkScroll, 0x45, 0, (UIntPtr)0);
        keybd_event(VkScroll, 0x45, KeyeventfKeyup, (UIntPtr)0);
    }
}