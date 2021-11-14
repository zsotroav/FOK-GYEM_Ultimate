using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOK_GYEM_Ultimate
{
    internal class Utils
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

        public static byte[] ToByteArrayFlip(BitArray bits)
        {
            var numBytes = bits.Count / 8;
            if (bits.Count % 8 != 0) numBytes++;

            var bytes = new byte[numBytes];
            int byteIndex = 0, bitIndex = 0;

            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                    bytes[byteIndex] |= (byte) (1 << (7 - bitIndex)); // (7 - bitIndex) makes it flip. Remove "7 -" to make it normal

                bitIndex++;
                if (bitIndex != 8) continue;
                bitIndex = 0;
                byteIndex++;
            }
            return bytes;
        }

    }
}
