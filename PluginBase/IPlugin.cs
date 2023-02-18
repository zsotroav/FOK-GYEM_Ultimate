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
		About,
		Plugin
	}

    public struct SubAction
    {
        public string ActionName;
        public int ActionID;
    }

	public struct Action {
		public Menu Menu;
        public string ActionName;
		public int ActionID;
		public List<SubAction> SubActions;
	}
	
	public interface IContext {
		/// <summary>Module count</summary>
		int ModCnt { get; set; }
		/// <summary>Module cut (breakpoint) </summary>
        int ModCut { get; set; }
		/// <summary>Module's vertical size (height)</summary>
		int ModV { get; set; }
		/// <summary>Module's horizontal size (width)</summary>
		int ModH { get; set; }
		/// <summary>Current screen</summary>
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