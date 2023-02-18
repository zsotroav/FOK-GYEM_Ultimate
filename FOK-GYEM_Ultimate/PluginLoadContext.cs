using System.Collections;
using System.Reflection;
using System.Runtime.Loader;
using PluginBase;

namespace FOK_GYEM_Ultimate
{
    internal class PluginLoadContext : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver _resolver;

        public PluginLoadContext(string pluginPath)
        {
            _resolver = new AssemblyDependencyResolver(pluginPath);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            string assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);
            return assemblyPath != null ? LoadFromAssemblyPath(assemblyPath) : null;
        }

        protected override nint LoadUnmanagedDll(string unmanagedDllName)
        {
            string libraryPath = _resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
            return libraryPath != null ? LoadUnmanagedDllFromPath(libraryPath) : nint.Zero;
        }

        public class Context : IContext
        {
            public int ModCnt { get; set; }
            public int ModCut { get; set; }
            public int ModH { get; set; }
            public int ModV { get; set; }
            public BitArray ScreenState { get; set; }

            public Context(BitArray screenState)
            {
                ModCnt = Config.ModuleCount;
                ModCut = Config.ModuleCut;
                ModH = Config.ModuleH;
                ModV = Config.ModuleV;
                ScreenState = screenState;
            }
        }
    }
}