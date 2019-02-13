/// <summary>
/// Thanks to https://bitbucket.org/ciniml/desktopwallpaper for the IDesktopWallpaper interface.
/// </summary>
namespace Desky
{
    /// <summary>
    /// This enumeration indicates the wallpaper position for all monitors. (This includes when slideshows are running.)
    /// The wallpaper position specifies how the image that is assigned to a monitor should be displayed.
    /// </summary>
    public enum DesktopWallpaperPosition
    {
        Center = 0,
        Tile = 1,
        Stretch = 2,
        Fit = 3,
        Fill = 4,
        Span = 5,
    }
}
