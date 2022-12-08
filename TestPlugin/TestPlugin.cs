using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PluginBase;
using Action = PluginBase.Action;

namespace TestPlugin
{
    public class Test : IPlugin
    {
        public string Name => "Test plugin";
        public string Description => "A test and debug plugin to demonstrate how things work";
        public string Author => "zsotroav";
        public string Link => "https://github.com/zsotroav/FOK-GYEM_Ultimate";

        public List<Action> Actions => new()
        {
            new Action
            {
                Menu = Menu.Panel,
                ActionName = "Test",
                ActionID = 0
            }
        };

        public int Init(IContext context)
        {
            AllocConsole();
            Console.OpenStandardOutput();

            SDK.PixelUpdatedEvent += ActionPD;
            SDK.ScreenUpdatedFull += ActionBA;
            return 0;
        }

        public int Run(IContext context, int runID)
        {
            SDK.UpdatePixel(new pixelData(new loc(1, 3), true));
            SDK.UpdatePixel(new pixelData(new loc(10), true));

            return 0;
        }

        public void ActionPD(pixelData data)
        {
            Console.WriteLine(data.debug);
        }

        public void ActionBA(System.Collections.BitArray i){
            Console.WriteLine("Full Screen updated");
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}