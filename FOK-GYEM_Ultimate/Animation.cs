﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FOK_GYEM_Ultimate
{
    public class Animation
    {
        public List<BitArray> Frames = new();
        public int FrameCount = 0;

        public Dictionary<string, int> FrameDictionary = new();
        public Dictionary<string, int> DelayDictionary = new();

        public void newFrame(BitArray frameBuffer, string name, int delay)
        {
            FrameDictionary.Add(name, FrameCount);
            DelayDictionary.Add(name, delay);
            Frames.Add(frameBuffer);
            FrameCount++;
        }

        public void Export(string loc, bool loop, int loopDelay)
        {
            var template = File.ReadAllText("resources/Arduino/animation_template.txt");
            template = template.Replace("##FRAME_DATA##", BuildData());
            template = template.Replace("##LOOP_START##", loop ? "while (true) {" : "// Loop start");
            template = template.Replace("##LOOP_END##", loop ? $"delay({loopDelay}; \n}}" : "// Loop end");
            template = template.Replace("##FRAME_WRITE##", BuildWrite());

            try
            {
                File.WriteAllText(loc, template);
            }
            catch
            {
                MessageBox.Show(@"Couldn't save file.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuildData()
        {
            var re = "";
            for (int i = 0; i < FrameCount; i++)
            {
                var d = "0x" + BitConverter.ToString(Utils.ToByteArray(Frames[i], true)).Replace("-", ", 0x");
                re += $"uint8_t f{i}[] = {{ {d} }}; \n";
            }

            return re;
        }

        private string BuildWrite()
        {
            var re = "";
            for (int i = 0; i < FrameCount; i++)
            {
                re += $"driver_setBuffer(f{i}, DRV_DATABUFF_SIZE); \n";
                re += "driver_writeScreen(); \n\n";
            }

            return re;
        }

        public BitArray getFrameName(string name) => Frames[FrameDictionary[name]];
        public BitArray getFrameNumber(int number) => Frames[number];
    }
}
