using System.Runtime.InteropServices;

/// <summary>
/// Thanks to https://bitbucket.org/ciniml/desktopwallpaper for the IDesktopWallpaper interface.
/// </summary>
namespace Desky
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}
