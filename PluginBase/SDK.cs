using System.Collections;
using System.Collections.Generic;

namespace PluginBase
{
    public delegate bool UpdatePixelDel(pixelData data);
    public delegate bool PixelUpdatedDel(pixelData data);
    public delegate bool ScreenUpdatedFUllDel(BitArray newArray);
    public delegate bool ScreenUpdatedChangesDel(List<pixelData> changes);

    public static class SDK
    {
        /*
         * Invokable events
         */

        public static event UpdatePixelDel UpdPix;
        /// <summary>
        /// Update a pixel based on XY coordinates
        /// </summary>
        public static void UpdatePixel(pixelData data) => UpdPix?.Invoke(data);

        /* 
         * Non-invokable events
         * Should only be invoked by the Core app as the core app does not respond to these invokes
         */

        /// <summary>
        /// Invoked when a pixel is updated
        /// </summary>
        public static event PixelUpdatedDel PixelUpd;
        public static void PixelUpdated(pixelData data) => PixelUpd?.Invoke(data);

        /// <summary>
        /// Invoked when multiple pixels are updated on the screen, 
        /// sends the whole screen again.
        /// </summary>
        public static event ScreenUpdatedFUllDel ScreenUpdatedFull;
        public static void ScreenUpdated(BitArray newArray) => ScreenUpdatedFull?.Invoke(newArray);
    }
}
