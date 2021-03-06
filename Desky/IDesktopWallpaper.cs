﻿using System;
using System.Runtime.InteropServices;

/// <summary>
/// Thanks to https://bitbucket.org/ciniml/desktopwallpaper for the IDesktopWallpaper interface.
/// </summary>
namespace Desky
{
    [ComImport, Guid("B92B56A9-8B55-4E14-9A89-0199BBB6F93B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDesktopWallpaper
    {
        void SetWallpaper([MarshalAs(UnmanagedType.LPWStr)] string monitorID, [MarshalAs(UnmanagedType.LPWStr)] string wallpaper);
        [return: MarshalAs(UnmanagedType.LPWStr)]
        string GetWallpaper([MarshalAs(UnmanagedType.LPWStr)] string monitorID);

        /// <summary>
        /// Gets the monitor device path.
        /// </summary>
        /// <param name="monitorIndex">Index of the monitor device in the monitor device list.</param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.LPWStr)]
        string GetMonitorDevicePathAt(uint monitorIndex);
        /// <summary>
        /// Gets number of monitor device paths.
        /// </summary>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.U4)]
        uint GetMonitorDevicePathCount();

        [return: MarshalAs(UnmanagedType.Struct)]
        Rect GetMonitorRECT([MarshalAs(UnmanagedType.LPWStr)] string monitorID);

        void SetBackgroundColor([MarshalAs(UnmanagedType.U4)] uint color);
        [return: MarshalAs(UnmanagedType.U4)]
        uint GetBackgroundColor();

        void SetPosition([MarshalAs(UnmanagedType.I4)] DesktopWallpaperPosition position);
        [return: MarshalAs(UnmanagedType.I4)]
        DesktopWallpaperPosition GetPosition();

        void SetSlideshow(IntPtr items);
        IntPtr GetSlideshow();

        void SetSlideshowOptions(DesktopSlideshowDirection options, uint slideshowTick);
        [PreserveSig]
        uint GetSlideshowOptions(out DesktopSlideshowDirection options, out uint slideshowTick);

        void AdvanceSlideshow([MarshalAs(UnmanagedType.LPWStr)] string monitorID, [MarshalAs(UnmanagedType.I4)] DesktopSlideshowDirection direction);

        DesktopSlideshowDirection GetStatus();

        bool Enable();
    }
}
