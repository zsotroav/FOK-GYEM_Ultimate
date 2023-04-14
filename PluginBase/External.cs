using System.Collections;
using System.IO;

// General Purpose library by zsotroav
// Copyright 2021 zsotroav. All rights reserved. Source code available under the AGPL.

namespace zsotroav
{
    public class External
    {
        public static void SaveBin(string loc, byte[] data)
        {
            if (!FileExists(loc))
            {
                Directory.GetParent(loc)?.Create();
                File.Create(loc).Close();
            }
            using var fs = File.Create(loc);
            fs.Write(data, 0, data.Length);
            fs.Close();
        }

        public static byte[] LoadBin(string loc) => File.ReadAllBytes(loc);

        public static bool FileExists(string loc) => File.Exists(loc);

        public static string NameFromPath(string path) => Path.GetFileName(path);

        public static string NameNoExtFromPath(string path) => Path.GetFileNameWithoutExtension(path);

        public static string ExtFromPath(string path) => Path.GetExtension(path);
    }
}
