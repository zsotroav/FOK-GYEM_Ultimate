using System.Collections;
using System.Collections.Generic;

namespace PluginBase
{
    public delegate bool UpdatePixelDel(PixelData data);
    public delegate void PixelUpdatedDel(PixelData data);
    public delegate void ScreenUpdatedFullDel(BitArray newArray);
    // public delegate void ScreenUpdatedChangesDel(List<PixelData> changes);

    public delegate void CommunicateDel(string title, string text, string icon = "info");

    public static class SDK
    {
        /*
         * Invokable events
         */

        public static event UpdatePixelDel UpdatePixelEvent;
        /// <summary>
        /// Update a pixel based on XY coordinates
        /// </summary>
        public static void UpdatePixel(PixelData data) => UpdatePixelEvent?.Invoke(data);

        /* 
         * Non-invokable events
         * Should only be invoked by the Core app as the core app does not respond to these invokes
         */

        /// <summary>Invoked when a pixel is updated</summary>
        public static event PixelUpdatedDel PixelUpdatedEvent;
        public static void PixelUpdated(PixelData data) => PixelUpdatedEvent?.Invoke(data);

        /// <summary>
        /// Invoked when multiple pixels are updated on the screen, 
        /// sends the whole screen again.
        /// </summary>
        public static event ScreenUpdatedFullDel ScreenUpdatedFull;
        public static void ScreenUpdated(BitArray newArray) => ScreenUpdatedFull?.Invoke(newArray);

        /// <summary>Request a Win32 MessageBox to be shown to the user</summary>
        public static event CommunicateDel CommunicateEvent;
        public static void Communicate(string title, string text, string icon = "info") => CommunicateEvent?.Invoke(title, text, icon);

    }
}
