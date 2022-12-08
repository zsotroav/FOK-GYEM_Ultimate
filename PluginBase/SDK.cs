using System.Collections;
using System.Collections.Generic;

namespace PluginBase
{
    public delegate bool UpdatePixelDel(pixelData data);
    public delegate void PixelUpdatedDel(pixelData data);
    public delegate void ScreenUpdatedFullDel(BitArray newArray);
    public delegate void ScreenUpdatedChangesDel(List<pixelData> changes);

    public static class SDK
    {
        /*
         * Invokable events
         */

        public static event UpdatePixelDel UpdatePixelEvent;
        /// <summary>
        /// Update a pixel based on XY coordinates
        /// </summary>
        public static void UpdatePixel(pixelData data) => UpdatePixelEvent?.Invoke(data);

        /* 
         * Non-invokable events
         * Should only be invoked by the Core app as the core app does not respond to these invokes
         */

        /// <summary>
        /// Invoked when a pixel is updated
        /// </summary>
        public static event PixelUpdatedDel PixelUpdatedEvent;
        public static void PixelUpdated(pixelData data) => PixelUpdatedEvent?.Invoke(data);

        /// <summary>
        /// Invoked when multiple pixels are updated on the screen, 
        /// sends the whole screen again.
        /// </summary>
        public static event ScreenUpdatedFullDel ScreenUpdatedFull;
        public static void ScreenUpdated(BitArray newArray) => ScreenUpdatedFull?.Invoke(newArray);
    }
}
