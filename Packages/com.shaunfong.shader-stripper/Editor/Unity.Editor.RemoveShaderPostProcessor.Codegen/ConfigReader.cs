using System;
using System.IO;
using UnityEngine;


namespace com.shaunfong.ShaderStripper.Editor
{
    public class ConfigReader
    {
        private const string ConfigFile = "Temp/com.shaunfong.shader-stripper.tmp";

        public bool ExecuteRemoveOthers { get; private set; }

        public ConfigReader()
        {
            try
            {
                Init();
            }
            catch (System.Exception e)
            {
                ExecuteRemoveOthers = false;

            }
        }


        private void Init()
        {
            if (!File.Exists(ConfigFile))
            {
                ExecuteRemoveOthers = false;
                return;
            }
            string str = File.ReadAllText(ConfigFile);
            ExecuteRemoveOthers = Boolean.Parse(str);
        }
    }
}