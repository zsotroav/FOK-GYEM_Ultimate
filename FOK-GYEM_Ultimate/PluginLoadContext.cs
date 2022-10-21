using System;
using System.Collections;
using System.Reflection;
using System.Runtime.Loader;
using PluginBase;

namespace FOK_GYEM_Ultimate
{
    class PluginLoadContext : AssemblyLoadContext
    {
        private AssemblyDependencyResolver _resolver;

        public PluginLoadContext(string pluginPath)
        {
            _resolver = new AssemblyDependencyResolver(pluginPath);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            string assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);
            if (assemblyPath != null)
            {
                return LoadFromAssemblyPath(assemblyPath);
            }

            return null;
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            string libraryPath = _resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
            if (libraryPath != null)
            {
                return LoadUnmanagedDllFromPath(libraryPath);
            }

            return IntPtr.Zero;
        }

        public class Context : IContext
        {
            public int ModCnt { get; set; }
            public int ModCut { get; set; }
            public BitArray ScreenState { get; set; }

            public Context(int modCnt, int modCut, BitArray screenState)
            {
                ModCnt = modCnt;
                ModCut = modCut;
                ScreenState = screenState;
            }
        }
    }
}