using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using zsotroav;

namespace FOK_GYEM_Ultimate
{
    class ArduinoGenerator
    {
        public bool Ready = false;
        private string _template;

        public bool init()
        {
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

        public bool GenerateBasic(byte[] data, int clear, bool loop, int delay, bool invert, int loopClear)
        {
            if (!Ready) return false;
            var working = _template;
            working = WriteData(working, data);
            working = working.Replace("##DATA_EXTRA##", "/* DATA_EXTRA to be implemented */");
            working = AddClear(working, clear);
            working = loop ? working.Replace("##LOOP_START##", "while (true) {") : "// Loop start";
            working = loop ? working.Replace("##LOOP_END##", "}") : "// Loop end";
            working = working.Replace("##DELAY##", $"delay({delay});");
            working = working.Replace("##WRITE_EXTRA##", "// WRITE_EXTRA to be implemented");
            working = AddClear(working, loopClear, true);

            try
            {
                File.WriteAllText("main.cpp", working);
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
                    tmp = "0xFF";
                    break;
                case 2:
                    tmp = "0x00";
                    break;
                case 3:
                    tmp = "0xFF 0x00";
                    break;
                case 4:
                    tmp = "0x55";
                    break;
                case 5:
                    tmp = "0xAA";
                    break;
                case 6:
                    tmp = "0x55 0xAA";
                    break;
            }

            var ft = @"for (uint8_t i = 0; i < DRV_DATABUFF_SIZE; i++) { buff[i] = ##D##; }
    driver_setBuffer(buff, DRV_DATABUFF_SIZE);
    driver_writeScreen();
    delay(1000);
    ";
            if (clear == 3 || clear == 6)
            {
                ft += ft.Replace("##D##", tmp[5..]);
                tmp = tmp[..4];
            }
            working = working.Replace(loop ? "##LOOP_CLEAR##" : "##CLEAR##", ft.Replace("##D##", tmp));
            
            return working;
        }
    }
}
