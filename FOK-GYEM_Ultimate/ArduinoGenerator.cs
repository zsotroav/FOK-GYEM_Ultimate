using System;
using System.Collections;
using System.Text;
using System.IO;
using PluginBase;
using zsotroav;

namespace FOK_GYEM_Ultimate
{
    public class ArduinoGenerator
    {
        public bool Ready = false;
        private string _template;

        public bool Init()
        {
            if (Ready) return true;
            if (!External.FileExists("resources/arduino/main-cpp_template.txt")) return false;
            try
            {
                _template = File.ReadAllText("resources/arduino/main-cpp_template.txt", Encoding.UTF8);
                Ready = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool GenerateBasic(byte[] data, string saveLoc, int clear, bool loop, int delay, bool invert, int loopClear)
        {
            if (!Ready) return false;

            if (invert)
            {
                var copy = new BitArray(data);
                var modCnt = data.Length / (7 * (Config.ModuleH/8)); // It is in Bytes not bits - 3 bytes/row/mod
                var dat = new BitArray(copy.Length);
                for (int i = 0; i < modCnt * Config.ModuleH; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        dat[i + j * Config.ModuleH * modCnt] = copy[i + (6 - j) * Config.ModuleH * modCnt];
                    }
                }

                data = Utils.ToByteArray(dat);
            }
            var working = _template;
            working = WriteData(working, data);
            working = AddClear(working, clear);
            working = working.Replace("##LOOP##", loop ? "} void loop() {" : "// Loop");
            working += loop ? "" : "void loop() { }";
            working = working.Replace("##DELAY##", $"delay({delay});");
            working = AddClear(working, loopClear, true);

            try
            {
                File.WriteAllText(saveLoc, working);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string WriteData(string working, byte[] data) => 
            working.Replace("##DATA##", "0x" + BitConverter.ToString(data).Replace("-", ", 0x"));

        private static string AddClear(string working, int clear, bool loop = false)
        {
            string tmp;
            switch (clear)
            {
                default:
                    tmp = working.Replace(loop ? "##LOOP_CLEAR##" : "##CLEAR##", "// No clear");
                    return tmp;
                case 1:
                    // 11111111
                    tmp = "0xFF";
                    break;
                case 2:
                    // 00000000
                    tmp = "0x00";
                    break;
                case 3:
                    // 11111111 00000000
                    tmp = "0xFF 0x00";
                    break;
                case 4:
                    // 10101010
                    tmp = "0xAA";
                    break;
                case 5:
                    // 01010101
                    tmp = "0x55";
                    break;
                case 6:
                    // 10101010 01010101
                    tmp = "0xAA 0x55";
                    break;
            }

            var ft = @"for (uint8_t i = 0; i < DRV_DATABUFF_SIZE; i++) { buff[i] = ##D##; }
    driver_setBuffer(buff, DRV_DATABUFF_SIZE);
    driver_forceWriteScreen();
    ";
            
            if (clear is 3 or 6)
            {
                ft += ft.Replace("##D##", tmp[5..]);
                tmp = tmp[..4];
            }
            working = working.Replace(loop ? "##LOOP_CLEAR##" : "##CLEAR##", ft.Replace("##D##", tmp));
            
            return working;
        }
    }
}
