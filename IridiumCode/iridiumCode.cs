using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IridiumCode
{
    static public class iridiumCode
    {
        public static Byte[] Encode(string message)
        {
            BitArray inArray = new BitArray(Encoding.ASCII.GetBytes(message));
            BitArray outArray = new BitArray((inArray.Count / 8) * 7);
            byte[] paylod = new byte[outArray.Count % 8 == 0 ? outArray.Count / 8 : (outArray.Count / 8) + 1];
            for (int n = 0, i = 0; i < inArray.Count; i++)
            {
                if ((i + 1) % 8 != 0)
                {
                    outArray.Set(i - n, inArray.Get(i));
                }
                else
                {
                    n++;
                }
            }
            outArray.CopyTo(paylod, 0);

            return paylod;
        }

        public static string Decode(byte[] paylod)
        {
            BitArray inArray = new BitArray(paylod);
            BitArray outArray = new BitArray((inArray.Count / 7) * 8);
            byte[] Bytes = new byte[(outArray.Count / 8)];

            for (int n = 0, i = 0; i < outArray.Count; i++)
            {
                if ((i + 1) % 8 != 0)
                {
                    outArray.Set(i, inArray.Get(i - n));
                }
                else
                {
                    outArray.Set(i, false);
                    n++;
                }

            }
            outArray.CopyTo(Bytes, 0);
            return Encoding.ASCII.GetString(Bytes);
        }
    }
}
