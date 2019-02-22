using System;
using System.IO;

namespace Zefugi.DotNet.IO
{
    public static class BinaryReaderExtensions
    {
        public static bool TryRead7BitEncodedInt(this BinaryReader reader, outout int val)
        {
            try
            {
                val = reader.Read7BitEncodedInt();
                return true;
            }
            catch
            {
                val = default(int);
                return false;
            }
        }

        public static bool TryReadBoolean(this BinaryReader reader, outout bool val)
        {
            try
            {
                val = reader.ReadBoolean();
                return true;
            }
            catch
            {
                val = default(bool);
                return false;
            }
        }

        public static bool TryReadByte(this BinaryReader reader, outout byte val)
        {
            try
            {
                val = reader.ReadByte();
                return true;
            }
            catch
            {
                val = default(byte);
                return false;
            }
        }

        public static bool TryReadBytes(this BinaryReader reader, int count, out byte[] val)
        {
            try
            {
                val = reader.ReadBytes(count);
                return true;
            }
            catch
            {
                val = default(byte[]);
                return false;
            }
        }

        public static bool TryReadChar(this BinaryReader reader, out char val)
        {
            try
            {
                val = reader.ReadChar();
                return true;
            }
            catch
            {
                val = default(char);
                return false;
            }
        }

        public static bool TryReadChars(this BinaryReader reader, int count, out char[] val)
        {
            try
            {
                val = reader.ReadChars(count);
                return true;
            }
            catch
            {
                val = default(char[]);
                return false;
            }
        }

        public static bool TryReadDecimal(this BinaryReader reader, out decimal val)
        {
            try
            {
                val = reader.ReadDecimal();
                return true;
            }
            catch
            {
                val = default(decimal);
                return false;
            }
        }

        public static bool TryReadDouble(this BinaryReader reader, out double val)
        {
            try
            {
                val = reader.ReadDouble();
                return true;
            }
            catch
            {
                val = default(double);
                return false;
            }
        }

        public static bool TryReadInt16(this BinaryReader reader, out short val)
        {
            try
            {
                val = reader.ReadInt16();
                return true;
            }
            catch
            {
                val = default(short);
                return false;
            }
        }

        public static bool TryReadInt32(this BinaryReader reader, out int val)
        {
            try
            {
                val = reader.ReadInt32();
                return true;
            }
            catch
            {
                val = default(int);
                return false;
            }
        }

        public static bool TryReadInt64(this BinaryReader reader, out long val)
        {
            try
            {
                val = reader.ReadInt64();
                return true;
            }
            catch
            {
                val = default(long);
                return false;
            }
        }

        public static bool TryReadSByte(this BinaryReader reader, out sbyte val)
        {
            try
            {
                val = reader.ReadSByte();
                return true;
            }
            catch
            {
                val = default(sbyte);
                return false;
            }
        }

        public static bool TryReadSingle(this BinaryReader reader, out float val)
        {
            try
            {
                val = reader.ReadSingle();
                return true;
            }
            catch
            {
                val = default(float);
                return false;
            }
        }

        public static bool TryReadString(this BinaryReader reader, out string val)
        {
            try
            {
                val = reader.ReadString();
                return true;
            }
            catch
            {
                val = default(string);
                return false;
            }
        }

        public static bool TryReaUdInt16(this BinaryReader reader, out ushort val)
        {
            try
            {
                val = reader.ReadUInt16();
                return true;
            }
            catch
            {
                val = default(ushort);
                return false;
            }
        }

        public static bool TryReadUInt32(this BinaryReader reader, out uint val)
        {
            try
            {
                val = reader.ReadUInt32();
                return true;
            }
            catch
            {
                val = default(uint);
                return false;
            }
        }

        public static bool TryReadUInt64(this BinaryReader reader, out ulong val)
        {
            try
            {
                val = reader.ReadUInt64();
                return true;
            }
            catch
            {
                val = default(ulong);
                return false;
            }
        }
    }
}
