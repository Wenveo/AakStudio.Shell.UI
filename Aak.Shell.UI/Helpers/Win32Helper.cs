using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace Aak.Shell.UI.Helpers
{
    internal static class Win32Helper
    {
        [DllImport("USER32.dll", ExactSpelling = true, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern unsafe IntPtr GetCursorPos(global::System.Drawing.Point* lpPoint);

        [DllImport("USER32.dll", ExactSpelling = true, EntryPoint = "SystemParametersInfoW", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern unsafe IntPtr SystemParametersInfo(uint uiAction, uint uiParam, [Optional] void* pvParam, uint fWinIni);


        [StructLayout(LayoutKind.Sequential)]
        private struct PointWrap
        {
            public int X;
            public int Y;
        }


        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private static bool GetPointWrap(out PointWrap point)
        {
            unsafe
            {
                fixed (PointWrap* ptr = &point)
                {
                    return GetCursorPos((System.Drawing.Point*)ptr) != IntPtr.Zero;
                }
            }
        }

        internal static Point GetMousePosition()
        {
            if (GetPointWrap(out var point))
            {
                return new Point(point.X, point.Y);
            }

            return new Point();
        }

        internal static bool GetWorkArea(out RECT rect)
        {
            unsafe
            {
                fixed (void* ptr = &rect)
                {
                    return SystemParametersInfo(0x00000030, 0, ptr, 0) != IntPtr.Zero;
                }
            }
        }
    }
}
