﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace zsotroav
{
    internal class ConfigLoader
    {
        public static readonly string AppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string ConfDir = Path.Combine(AppDataDir, "zsotroav");
        public string ConfFile;

        private Dictionary<string, string> _configs = new();

        public void Init(string appName)
        {
            ConfDir = Path.Combine(ConfDir, appName);
            ConfFile = Path.Combine(ConfDir, "conf.xml");

            if (!File.Exists(ConfFile))
            {
                Directory.CreateDirectory(ConfDir);
                File.Create(ConfFile).Close();
                StreamWriter sw = new(ConfFile);
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?><root></root>");
                sw.Close();
            }

            _configs = XElement.Parse(File.ReadAllText(ConfFile))
                .Elements()
                .ToDictionary(k => k.Name.ToString(), v => v.Value.ToString());
        }

        public string Get(string variable, string defaultValue)
        {
            try { return _configs[variable];} 
            catch { return defaultValue; }
        }

        public int GetInt(string variable, int defaultValue)
        {
            if (!_configs.ContainsKey(variable))
                return defaultValue;
            return int.TryParse(_configs[variable], out _)
                ? int.Parse(_configs[variable])
                : defaultValue;
        }

        public void Set(string variable, string value, bool save = true)
        {
            if (_configs.ContainsKey(variable))
                _configs[variable] = value;
            else
                _configs.Add(variable, value);

            if (!save) return;
            Save();
        }

        private void Save() =>
            new XElement("root", _configs.Select(kv => new XElement(kv.Key, kv.Value)))
                .Save(ConfFile, SaveOptions.OmitDuplicateNamespaces);
    }
}
