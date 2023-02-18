namespace PluginBase
{
    public class Loc
    {
        public int X;
        public int Y;
        public int Serial;

        /// <summary>
        /// Location based on XY Coordinates
        /// </summary>
        public Loc(int x, int y)
        {
            X = x;
            Y = y;
            Serial = x + y * Config.ModuleH * Config.ModuleCount;
        }
        
        /// <summary>
        /// Location based on XY Coordinates within a module
        /// </summary>
        public Loc(int x, int y, int moduleN){ 
            X = x + moduleN * Config.ModuleH;
            Y = y;
            Serial = (x + moduleN * Config.ModuleH) + y * Config.ModuleH * Config.ModuleCount;
        }

        /// <summary>
        /// Location based on the serial location
        /// </summary>
        public Loc(int serial)
        {
            Serial = serial;
            X = serial % (Config.ModuleH * Config.ModuleCount);
            Y = serial / (Config.ModuleH * Config.ModuleCount);
        }
    }

    public class PixelData
    {
        public Loc Loc;
        public bool State;
        public PixelData(Loc loc, bool state){
            Loc = loc;
            State = state;
        }

        public string Debug => $"{{{Loc.X};{Loc.Y}}} ({Loc.Serial}) - {State}";
    }
}