using System.Collections;
using System.Collections.Generic;

namespace PluginBase
{
    public class loc
    {
        public int x;
        public int y;
        public int serial;

        /// <summary>
        /// Location based on XY Coordinates
        /// </summary>
        public loc(int x, int y)
        {
            this.x = x;
            this.y = y;
            serial = x + y * Config.ModuleH * Config.ModuleCount;
        }
        
        /// <summary>
        /// Location based on XY Coordinates within a module
        /// </summary>
        public loc(int x, int y, int moduleN){ 
            this.x = x + moduleN * Config.ModuleH;
            this.y = y;
            serial = (x + moduleN * Config.ModuleH) + y * Config.ModuleH * Config.ModuleCount;
        }

        /// <summary>
        /// Location based on the serial location
        /// </summary>
        public loc(int serial)
        {
            this.serial = serial;
            x = serial % (Config.ModuleH * Config.ModuleCount);
            y = serial / (Config.ModuleH * Config.ModuleCount);
        }
    }

    public class pixelData
    {
        public loc loc;
        public bool state;
        public pixelData(loc loc, bool state){
            this.loc = loc;
            this.state = state;
        }

        public string debug => $"{{{loc.x};{loc.y}}} ({loc.serial}) - {state}";
    }
}