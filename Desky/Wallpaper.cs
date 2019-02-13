using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desky
{

    public sealed class Wallpaper
    {
        private static IDesktopWallpaper _dsk;
        public static IDesktopWallpaper Interface
        {
            get
            {
                if (_dsk == null)
                    _dsk = (IDesktopWallpaper)new DesktopWallpaperClass();

                return _dsk;
            }
        }

        public static string[] GetMonitors()
        {
            List<string> strs = new List<string>();

            var count = Interface.GetMonitorDevicePathCount();
            for (uint j = 0; j < count; j++)
            {
                var monitorId = Interface.GetMonitorDevicePathAt(j);
                var size = Interface.GetMonitorRECT(monitorId);
                strs.Add($"{j + 1}: {size.Right - size.Left}x{ size.Bottom - size.Top } {{{size.Left}, {size.Top}; {size.Right}, {size.Bottom}}}");
            }

            return strs.ToArray();
        }

        private struct MonitorInfo
        {
            public Rect Rect { get; set; }
            public uint Id { get; set; }
        }

        public static void ShowIdentifiers()
        {
            var count = Interface.GetMonitorDevicePathCount();
            for (uint j = 0; j < count; j++)
            {
                var monitorId = Interface.GetMonitorDevicePathAt(j);
                var size = Interface.GetMonitorRECT(monitorId);

                WinFormUtil.ShowToastAt(j + 1, size);
            }
        }

        public static string GetAsciiMonitorRepresentation()
        {
            List<MonitorInfo> monitors = new List<MonitorInfo>();
            List<string> monitorStrings = new List<string>();

            var count = Interface.GetMonitorDevicePathCount();
            for (uint j = 0; j < count; j++)
            {
                var monitorId = Interface.GetMonitorDevicePathAt(j);
                var size = Interface.GetMonitorRECT(monitorId);

                monitors.Add(new MonitorInfo() { Rect = size, Id = j });
            }

            var monitorResult = monitors.OrderBy(mon => mon.Rect.Left);
            
            foreach (var monitor in monitorResult)
            {
                monitorStrings.Add($"[{monitor.Id + 1}]");
            }

            return string.Join(" ", monitorStrings);
        }

        /// <summary>
        /// Gets the wallpaper path of the specified monitor
        /// </summary>
        /// <param name="monitorIndex">The monitor index</param>
        /// <returns>The path of the wallpaper</returns>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public static string GetWallpaper(uint monitorIndex)
        {
            var count = Interface.GetMonitorDevicePathCount();
            if (monitorIndex > count)
                throw new ArgumentOutOfRangeException($"Invalid monitor index {monitorIndex}, total of monitors is {count}");

            var monitorId = Interface.GetMonitorDevicePathAt(monitorIndex);
            return Interface.GetWallpaper(monitorId);
        }

        public static void SetWallpaper(uint monitorIndex, string wallpaper)
        {
            var count = Interface.GetMonitorDevicePathCount();
            if (monitorIndex > count)
                throw new ArgumentOutOfRangeException($"Invalid monitor index {monitorIndex}, total of monitors is {count}");

            var monitorId = Interface.GetMonitorDevicePathAt(monitorIndex);
            Interface.SetWallpaper(monitorId, wallpaper);
        }
    }
}
