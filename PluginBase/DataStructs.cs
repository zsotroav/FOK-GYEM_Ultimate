using System.Collections;
using System.Collections.Generic;

namespace PluginBase
{
    public class loc
    {
        public int x;
        public int y;
        public int serial;

        public loc(int x, int y)
        {
            this.x = x;
            this.y = y;
            serial = x + y * Config.ModuleH * Config.ModuleCount;
        }
        
        /* public loc(int x, int y, int panelN){ }*/

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
    }
}