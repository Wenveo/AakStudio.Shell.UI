using System;
using System.ComponentModel;

using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Gdi;

namespace VisualStudio.Shell.UI.Helpers
{
    internal static class DpiHelper
    {
        public static double DeviceDpiX { get; }

        public static double DeviceDpiY { get; }

        static DpiHelper()
        {
            var hDC = PInvoke.GetDC(HWND.Null);
            if (!hDC.IsNull)
            {
                DeviceDpiX = PInvoke.GetDeviceCaps(hDC, GET_DEVICE_CAPS_INDEX.LOGPIXELSX);
                DeviceDpiY = PInvoke.GetDeviceCaps(hDC, GET_DEVICE_CAPS_INDEX.LOGPIXELSY);

                if (PInvoke.ReleaseDC(HWND.Null, hDC) != 1)
                {
                    throw new Win32Exception("DpiHelper: Failed to Release HDC.");
                }
            }
            else
            {
                DeviceDpiX = (double)GET_DEVICE_CAPS_INDEX.LOGPIXELSX;
                DeviceDpiY = (double)GET_DEVICE_CAPS_INDEX.LOGPIXELSY;
            }
        }

        public static double RoundLayoutValue(double value, double dpiScale)
        {
            double newValue;

            if (!AreClose(dpiScale, 1.0))
            {
                newValue = Math.Round(value / dpiScale);
                if (double.IsNaN(newValue) || double.IsInfinity(newValue) || AreClose(newValue, double.MaxValue))
                {
                    newValue = value;
                }
            }
            else
            {
                newValue = Math.Round(value);
            }

            return newValue;
        }

        public static double RoundLayoutValueX(double value)
        => RoundLayoutValue(value, DeviceDpiX / 96.0);

        public static double RoundLayoutValueY(double value)
        => RoundLayoutValue(value, DeviceDpiY / 96.0);

        private static bool AreClose(double value1, double value2)
        => value1 == value2 || IsVerySmall(value1 - value2);

        private static bool IsVerySmall(double value)
        => Math.Abs(value) < 1E-06;
    }
}
