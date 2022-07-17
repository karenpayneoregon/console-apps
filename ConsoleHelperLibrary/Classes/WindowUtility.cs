using System;
using System.Runtime.InteropServices;

namespace ConsoleHelperLibrary.Classes
{
    public class WindowUtility
    {

        // P/Invoke declarations.

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

        const int MONITOR_DEFAULTTOPRIMARY = 1;

        [DllImport("user32.dll")]
        static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

        [StructLayout(LayoutKind.Sequential)]
        struct MONITORINFO
        {
            public uint cbSize;
            public RECT rcMonitor;
            public RECT rcWork;
            public uint dwFlags;

            public static MONITORINFO Default
            {
                get
                {
                    var inst = new MONITORINFO();
                    inst.cbSize = (uint)Marshal.SizeOf(inst);
                    return inst;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public int x, y;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

        const uint SW_RESTORE = 9;

        [StructLayout(LayoutKind.Sequential)]
        struct WINDOWPLACEMENT
        {
            public uint Length;
            public uint Flags;
            public uint ShowCmd;
            public POINT MinPosition;
            public POINT MaxPosition;
            public RECT NormalPosition;

            public static WINDOWPLACEMENT Default
            {
                get
                {
                    var instance = new WINDOWPLACEMENT();
                    instance.Length = (uint)Marshal.SizeOf(instance);
                    return instance;
                }
            }
        }

        [Flags]
        public enum AnchorWindow
        {
            None = 0x0,
            Top = 0x1,
            Bottom = 0x2,
            Left = 0x4,
            Right = 0x8,
            Center = 0x10,
            Fill = 0x20
        }

        public static void SetConsoleWindowPosition(AnchorWindow position)
        {
            // Get this console window's hWnd (window handle).
            IntPtr hWnd = GetConsoleWindow();

            // Get information about the monitor (display) that the window is (mostly) displayed on.
            // The .rcWork field contains the monitor's work area, i.e., the usable space excluding
            // the taskbar (and "application desktop toolbars" - see https://msdn.microsoft.com/en-us/library/windows/desktop/ms724947(v=vs.85).aspx)
            var mi = MONITORINFO.Default;
            GetMonitorInfo(MonitorFromWindow(hWnd, MONITOR_DEFAULTTOPRIMARY), ref mi);

            // Get information about this window's current placement.
            var wp = WINDOWPLACEMENT.Default;
            GetWindowPlacement(hWnd, ref wp);

            // Calculate the window's new position: lower left corner.
            // !! Inexplicably, on W10, work-area coordinates (0,0) appear to be (7,7) pixels 
            // !! away from the true edge of the screen / taskbar.
            int fudgeOffset = 7;
            int _left = 0, _top = 0;
            switch (position)
            {
                case AnchorWindow.Left | AnchorWindow.Top:
                    wp.NormalPosition = new RECT()
                    {
                        Left = -fudgeOffset,
                        Top = mi.rcWork.Top,
                        Right = (wp.NormalPosition.Right - wp.NormalPosition.Left) - fudgeOffset,
                        Bottom = (wp.NormalPosition.Bottom - wp.NormalPosition.Top)
                    };
                    break;
                case AnchorWindow.Right | AnchorWindow.Top:
                    wp.NormalPosition = new RECT()
                    {
                        Left = mi.rcWork.Right - wp.NormalPosition.Right + wp.NormalPosition.Left + fudgeOffset,
                        Top = mi.rcWork.Top,
                        Right = mi.rcWork.Right + fudgeOffset,
                        Bottom = (wp.NormalPosition.Bottom - wp.NormalPosition.Top)
                    };
                    break;
                case AnchorWindow.Left | AnchorWindow.Bottom:
                    wp.NormalPosition = new RECT()
                    {
                        Left = -fudgeOffset,
                        Top = mi.rcWork.Bottom - (wp.NormalPosition.Bottom - wp.NormalPosition.Top),
                        Right = (wp.NormalPosition.Right - wp.NormalPosition.Left) - fudgeOffset,
                        Bottom = fudgeOffset + mi.rcWork.Bottom
                    };
                    break;
                case AnchorWindow.Right | AnchorWindow.Bottom:
                    wp.NormalPosition = new RECT()
                    {
                        Left = mi.rcWork.Right - wp.NormalPosition.Right + wp.NormalPosition.Left + fudgeOffset,
                        Top = mi.rcWork.Bottom - (wp.NormalPosition.Bottom - wp.NormalPosition.Top),
                        Right = mi.rcWork.Right + fudgeOffset,
                        Bottom = fudgeOffset + mi.rcWork.Bottom
                    };
                    break;
                case AnchorWindow.Center | AnchorWindow.Top:
                    _left = mi.rcWork.Right / 2 - (wp.NormalPosition.Right - wp.NormalPosition.Left) / 2;
                    wp.NormalPosition = new RECT()
                    {
                        Left = _left,
                        Top = mi.rcWork.Top,
                        Right = mi.rcWork.Right + fudgeOffset - _left,
                        Bottom = (wp.NormalPosition.Bottom - wp.NormalPosition.Top)
                    };
                    break;
                case AnchorWindow.Center | AnchorWindow.Bottom:
                    _left = mi.rcWork.Right / 2 - (wp.NormalPosition.Right - wp.NormalPosition.Left) / 2;
                    wp.NormalPosition = new RECT()
                    {
                        Left = _left,
                        Top = mi.rcWork.Bottom - (wp.NormalPosition.Bottom - wp.NormalPosition.Top),
                        Right = mi.rcWork.Right + fudgeOffset - _left,
                        Bottom = fudgeOffset + mi.rcWork.Bottom
                    };
                    break;
                case AnchorWindow.Center:
                    _left = mi.rcWork.Right / 2 - (wp.NormalPosition.Right - wp.NormalPosition.Left) / 2;
                    _top = mi.rcWork.Bottom / 2 - (wp.NormalPosition.Bottom - wp.NormalPosition.Top) / 2;
                    wp.NormalPosition = new RECT()
                    {
                        Left = _left,
                        Top = _top,
                        Right = mi.rcWork.Right + fudgeOffset - _left,
                        Bottom = mi.rcWork.Bottom + fudgeOffset - _top
                    };
                    break;
                case AnchorWindow.Fill:
                    wp.NormalPosition = new RECT()
                    {
                        Left = -fudgeOffset,
                        Top = mi.rcWork.Top,
                        Right = mi.rcWork.Right + fudgeOffset,
                        Bottom = mi.rcWork.Bottom + fudgeOffset
                    };
                    break;
                default:
                    return;
            }

            // Place the window at the new position.
            SetWindowPlacement(hWnd, ref wp);
        }

        /// <summary>
        /// Scroll to top of console window
        /// </summary>
        public static void ScrollTop()
        {
            Console.SetWindowPosition(left: 0, top: 0);
        }

    }
}
