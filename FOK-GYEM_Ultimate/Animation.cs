using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PluginBase;

namespace FOK_GYEM_Ultimate
{
    public class AnimationFrame
    {
        public int i;
        public BitArray Frame;
        public string name;
        public int delay; // Delay BEFORE this frame

        public AnimationFrame(BitArray frame, string name, int delay, int i)
        {
            Frame = frame;
            this.name = name;
            this.delay = delay;
            this.i = i;
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
            var template = File.ReadAllText("resources/Arduino/animation_template.txt");
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
                re += $"delay({AnimationFrames[i].delay});\n";
            }
            
            return re;
        }

        public AnimationFrame GetFrameByName(string name) => 
            AnimationFrames.Where(animationFrame => animationFrame.name == name).Select(animationFrame => animationFrame).FirstOrDefault();
        
        public AnimationFrame GetFrameByNumber(int number) => AnimationFrames[number];

        public List<string> GetAllNames()
        {
            List<string> re = new(FrameCount);
            re.AddRange(AnimationFrames.Select(animationFrame => animationFrame.name));

            return re;
        }
    }
}
