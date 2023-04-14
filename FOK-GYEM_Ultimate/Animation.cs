using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.Intrinsics.X86;
using System.Windows.Forms;
using PluginBase;

namespace FOK_GYEM_Ultimate
{
    public class AnimationFrame
    {
        public int I;
        public BitArray Frame;
        public string Name;
        public int Delay; // Delay BEFORE this frame

        public AnimationFrame(BitArray frame, string name, int delay, int i)
        {
            Frame = frame;
            Name = name;
            Delay = delay;
            I = i;
        }
    }

    public class Animation
    {
        public List<AnimationFrame> AnimationFrames = new();
        
        public int FrameCount => AnimationFrames.Count;
        
        public delegate void NewFrameNameDel(string name);
        public event NewFrameNameDel NewFrameName;

        public void NewFrame(BitArray frameBuffer, string name, int delay)
        {
            AnimationFrames.Add(new AnimationFrame(frameBuffer, name, delay, AnimationFrames.Count));
            NewFrameName?.Invoke(name);
        }

        public void Export(string loc, bool loop, int loopDelay)
        {
            var template = File.ReadAllText(ResourceLoader.GetResourcePath("Arduino", "animation_template.txt"));
            template = template.Replace("##FRAME_DATA##", BuildData());
            template = template.Replace("##LOOP##", loop ? "} void loop() {" : "// Loop start");
            template += loop ? "" : "void loop() { }";
            var del = "";
            if (loopDelay != 0) del = $"delay({loopDelay}); \n";
            template = template.Replace("##LOOP_END##", loop ? $"{del}" : "// Loop end");
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
                var d = "0x" + BitConverter.ToString(Utils.ToByteArray(AnimationFrames[i].Frame, true)).Replace("-", ", 0x");
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
                re += "driver_writeScreen(); \n";
                re += $"delay({AnimationFrames[i].Delay});\n";
            }
            
            return re;
        }

        public AnimationFrame GetFrameByName(string name) => 
            AnimationFrames.Where(animationFrame => animationFrame.Name == name).Select(animationFrame => animationFrame).FirstOrDefault();
        
        public AnimationFrame GetFrameByNumber(int number) => AnimationFrames[number];

        public List<string> GetAllNames()
        {
            List<string> re = new(FrameCount);
            re.AddRange(AnimationFrames.Select(animationFrame => animationFrame.Name));

            return re;
        }

        public void AddTransition(string type, int modCnt)
        {
            var tmp = new BitArray(Config.ModuleV * Config.ModuleH * modCnt);
            switch (int.Parse(type[..1]))
            {
                case 1:
                    // 11111111
                    for (int i = 0; i < tmp.Length; i++) tmp[i] = true;
                    break;
                case 2:
                    // 00000000
                    for (int i = 0; i < tmp.Length; i++) tmp[i] = false;
                    break;
                case 3:
                    // 11111111 00000000
                    var tmp2 = new BitArray(Config.ModuleV * Config.ModuleH * modCnt);
                    for (int i = 0; i < tmp2.Length; i++) tmp2[i] = true;
                    NewFrame(tmp2, $"Pat{FrameCount} ({type})", 0);
                    for (int i = 0; i < tmp.Length; i++) tmp[i] = false;
                    break;
                case 4:
                    // 10101010
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (i % 2 == 0) tmp[i] = true;
                        else tmp[i] = false;
                    }
                    break;
                case 5:
                    // 01010101
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (i % 2 == 0) tmp[i] = false;
                        else tmp[i] = true;
                    }
                    break;
                case 6:
                    // 10101010 01010101
                    var tmp3 = new BitArray(Config.ModuleV * Config.ModuleH * modCnt);
                    for (int i = 0; i < tmp3.Length; i++)
                    {
                        if (i % 2 == 0) tmp3[i] = true;
                        else tmp3[i] = false;
                    }
                    NewFrame(tmp3, $"Pat{FrameCount} ({type})", 0);
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (i % 2 == 0) tmp[i] = false;
                        else tmp[i] = true;
                    }
                    break;
            }

            NewFrame(tmp, $"pat{FrameCount} ({type})", 0);
        }
    }
}
