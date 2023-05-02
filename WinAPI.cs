using System;
using System.Runtime.InteropServices;

class WinAPI
{
    public const int AW_HOR_POSITIVE = 0x00000001;
    public const int AW_HOR_NEGATIVE = 0x00000002;
    public const int AW_SLIDE = 0x00040000;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
}
