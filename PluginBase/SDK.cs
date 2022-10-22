namespace PluginBase
{
    public delegate bool UpdatePixelXYDel(int x, int y, bool set);
    public delegate bool UpdatePixelLocDel(int loc, bool set);

    public static class SDK
    {
        public static event UpdatePixelXYDel UpdPXY;
        public static event UpdatePixelLocDel UpdPLoc;

        public static void UpdatePixelXY(int x, int y, bool set) => UpdPXY?.Invoke(x, y, set);
        public static void UpdatePixelLoc(int loc, bool set) => UpdPLoc?.Invoke(loc, set);

    }
}
