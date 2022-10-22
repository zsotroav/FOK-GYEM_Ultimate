using System.Collections;
using System.Collections.Generic;

namespace PluginBase
{
    public enum Menu {
		Load,
		Export,
		Panel,
		Edit,
		Preferences,
		About
	}
	
	public struct Action {
		public Menu Menu;
        public string ActionName;
		public int ActionID;
	}
	
	public interface IContext {
		int ModCnt { get; set; }
        int ModCut { get; set; }
		BitArray ScreenState { get; set; }
    }

    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        string Author { get; }
        string Link { get; }
		
		List<Action> Actions { get; }
		

        int Init(IContext context);
		int Run(IContext context, int runID);
    }
}