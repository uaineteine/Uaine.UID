using System;
using System.Collections;
using Uaine.Objects.Primitives.ID;

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
        public UniqueID(ref Random rand, bool posonly) : base(randomIDArray(ref rand, posonly))
        {
            //make random one
        }

        public static ID64[] randomIDArray(ref Random rand, bool posonly)
        {
            ID64[] id256 = new ID64[nIDSegments];
            for (int i = 0; i < nIDSegments; i++)
            {
                id256[i] = randomID(ref rand, posonly);
            }
            return id256;
        }
        public static ID64 randomID(ref Random rand, bool posonly)
        {
            if (posonly == false)
            {
                return new ID64(RandomLong(ref rand));
            }
            //else
            return new ID64(RandomLongPosOnly(ref rand));
        }
        public static long RandomLong(ref Random rnd)
        {
            byte[] buffer = new byte[8];
            rnd.NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }
        public static long RandomLongPosOnly(ref Random rnd)
        {
            byte[] buffer = new byte[8];
            rnd.NextBytes(buffer);
            long value = BitConverter.ToInt64(buffer, 0);
            return Math.Abs(value);
            //BitArray bits = new BitArray(buffer);
            //bits[0] = false;
            //return BitConverter.ToInt64(ToByteArray(bits), 0);
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
