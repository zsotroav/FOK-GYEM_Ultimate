using System;
using System.Collections.Generic;
using PluginBase;
using Action = PluginBase.Action;

namespace TestPlugin
{
    public class Test : IPlugin
    {
        public string Name => "Test plugin";
        public string Description => "A test plugin to demonstrate how things work";
        public string Author => "zsotroav";
        public string Link => "https://github.com/zsotroav/FOK-GYEM_Ultimate";

        public List<Action> Actions => new() {
            new Action{
                Menu = Menu.Panel,
                ActionName = "Test",
                ActionID = 0
            }
        };

        public int Init(IContext context)
        {
            return 0;
        }

        public int Run(IContext context, int runID)
        {
            SDK.UpdatePixelXY(1, 3, true);
            SDK.UpdatePixelLoc(10, true);

            return 0;
        }
    }
}