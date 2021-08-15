using System;
using System.Collections;
using Uaine.Objects.Primitives.ID;
using Uaine.Random;

namespace Uaine.UID
{
    public class UniqueID : PolyID64
    {
        public const int nIDSegments = 4;
        public const int BitLength = nIDSegments * SegmentBitLength;
        public UniqueID(ID64[] IDArray) : base(IDArray)
        {
        }
        public UniqueID(ID32[] IDArray) : base(IDArray)
        {
        }
        public UniqueID(ID16[] IDArray) : base(IDArray)
        {
        }
        public UniqueID(bool posonly) : base(randomIDArray(posonly))
        {
            //make random one
        }

        public static ID64[] randomIDArray(bool posonly)
        {
            URandom rand = new URandom();
            ID64[] id256 = new ID64[nIDSegments];
            for (int i = 0; i < nIDSegments; i++)
            {
                id256[i] = randomID(ref rand, posonly);
            }
            return id256;
        }
        public static ID64 randomID(ref URandom rand, bool posonly)
        {
            if (posonly == false)
            {
                return new ID64(rand.RandomLong());
            }
            //else
            return new ID64(rand.RandomLongPosOnly());
        }
        public static byte[] ToByteArray(BitArray bits)
        {
            int numBytes = bits.Length / 8;
            if (bits.Length % 8 != 0) numBytes++;

            byte[] bytes = new byte[numBytes];
            int byteIndex = 0, bitIndex = 0;

            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i])
                    bytes[byteIndex] |= (byte)(1 << (7 - bitIndex));

                bitIndex++;
                if (bitIndex == 8)
                {
                    bitIndex = 0;
                    byteIndex++;
                }
            }
            return bytes;
        }
    }
}
