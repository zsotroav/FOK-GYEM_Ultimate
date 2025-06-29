using System;
using System.Collections;
using System.Runtime.Intrinsics.X86;

namespace PluginBase
{
    public class Utils
    {
        public static byte[] ReverseBytes(byte[] bitArray)
        {
            for (int i = 0; i < bitArray.Length; i++)
            {
                var t = 0;
                for (int j = 0; j < 8; j++)
                {
                    t *= 2;
                    t += bitArray[i] % 2;
                    bitArray[i] >>= 1;
                }

                bitArray[i] = Convert.ToByte(t);
            }

            return bitArray;
        }

        public static byte[] ToByteArray(BitArray bits, bool flip = false)
        {
            var numBytes = bits.Count / 8;
            if (bits.Count % 8 != 0) numBytes++;

            var bytes = new byte[numBytes];
            int byteIndex = 0, bitIndex = 0;

            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                    bytes[byteIndex] |= (byte) (1 << (flip?(7 - bitIndex):bitIndex)); // (7 - bitIndex) makes it flip. Remove "7 -" to make it normal

                bitIndex++;
                if (bitIndex != 8) continue;
                bitIndex = 0;
                byteIndex++;
            }
            return bytes;
        }

        public static BitArray FlipVertical(BitArray bits) =>
            FlipVertical(bits, Config.ModuleH * Config.ModuleCount, Config.ModuleV);

        public static BitArray FlipVertical(BitArray bits, int horizontal, int vertical)
        {
            var re = new BitArray(bits.Length);

            for (int i = 0; i < horizontal; i++)
            for (int j = 0; j < vertical; j++)
                re[i + j * horizontal] = bits[i + (6 - j) * horizontal];

            return re;
        }

        public static BitArray FlipHorizontal(BitArray bits) =>
            FlipHorizontal(bits, 
                Config.ModuleH * Config.ModuleCount, 
                Config.ModuleH * Config.ModuleCut, Config.ModuleV);

        public static BitArray FlipHorizontal(BitArray bits, int horizontal, int breakpoint, int vertical)
        {
            var re = new BitArray(bits.Length);

            for (int i = 0; i < horizontal; i++)
            {
                for (int j = 0; j < vertical; j++)
                    re[i + j * horizontal] = bits[
                        ((i >= breakpoint) ? horizontal + breakpoint: breakpoint) - 1 - i
                        + j * horizontal];
            }

            return re;
        }
    }
}
