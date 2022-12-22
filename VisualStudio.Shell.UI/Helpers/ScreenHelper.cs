using System;
using System.Runtime.InteropServices;
using System.Windows;

using Windows.Win32;
using Windows.Win32.Graphics.Gdi;

namespace VisualStudio.Shell.UI.Helpers
{
    internal class ScreenHelper
    {
        internal static void FindMonitorRectsFromPoint(Point point, out Rect monitorRect, out Rect workAreaRect)
        {
            var hmoitor = PInvoke.MonitorFromPoint(new System.Drawing.Point((int)point.X, (int)point.Y), MONITOR_FROM_FLAGS.MONITOR_DEFAULTTONEAREST);

            monitorRect = new Rect(0.0, 0.0, 0.0, 0.0);
            workAreaRect = new Rect(0.0, 0.0, 0.0, 0.0);

            if (hmoitor != IntPtr.Zero)
            {
                MONITORINFO monitorInfo = default;
                monitorInfo.cbSize = (uint)Marshal.SizeOf(typeof(MONITORINFO));
                PInvoke.GetMonitorInfo(hmoitor, ref monitorInfo);
                monitorRect = new Rect(monitorInfo.rcMonitor.X, monitorInfo.rcMonitor.Y, monitorInfo.rcMonitor.Width, monitorInfo.rcMonitor.Height);
                workAreaRect = new Rect(monitorInfo.rcWork.X, monitorInfo.rcWork.Y, monitorInfo.rcWork.Width, monitorInfo.rcWork.Height);
            }
        }
    }
}