using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using zsotroav;

namespace PluginBase
{
    public static class ResourceLoader
    {
        public static readonly string AppDataBase = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static readonly string AppData = Path.Combine(AppDataBase, "zsotroav", "FOK-GYEM_Ultimate");

        public static readonly string GlobalResourceFolder = Path.Combine(AppData, "resources");
        public static readonly string InstallResourceFolder = Path.Combine(AppContext.BaseDirectory, "resources");

        public static void Init()
        {
            if (!Directory.Exists(GlobalResourceFolder)) Directory.CreateDirectory(GlobalResourceFolder);
            if (!Directory.Exists(InstallResourceFolder)) Directory.CreateDirectory(InstallResourceFolder);
        }

        public static string[] GetResourceList(string resourceType, bool global = true, bool install = true)
        {
            var list = new List<string>();
            if (global) list.AddRange(Directory.GetFiles(Path.Combine(GlobalResourceFolder, resourceType)));
            if (install) list.AddRange(Directory.GetFiles(Path.Combine(InstallResourceFolder, resourceType)));
            
            return list.Select(External.NameNoExtFromPath).Distinct().ToArray();
        }

        public static string[] GetResourceListPattern(string resourceType, string pattern, bool strip= true, bool global = true, bool install = true)
        {
            var list = new List<string>();
            if (global && Directory.Exists(Path.Combine(GlobalResourceFolder, resourceType))) 
                list.AddRange(Directory.GetFiles(Path.Combine(GlobalResourceFolder, resourceType), pattern));
            if (install && Directory.Exists(Path.Combine(InstallResourceFolder, resourceType))) 
                list.AddRange(Directory.GetFiles(Path.Combine(InstallResourceFolder, resourceType), pattern));

            return strip ? list.Select(External.NameNoExtFromPath).Distinct().ToArray() : list.Distinct().ToArray();
        }

        public static string GetResourcePath(string type, string file)
        {
            if (File.Exists(Path.Combine(GlobalResourceFolder, type, file)))
                return Path.Combine(GlobalResourceFolder, type, file);
            if (File.Exists(Path.Combine(InstallResourceFolder, type, file)))
                return Path.Combine(InstallResourceFolder, type, file);
            return "";
        }
    }
}
