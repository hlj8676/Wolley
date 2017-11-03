﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace network
{
    class ConverterBigLittle
    {
        //internal static UInt32 GetBigEndian(UInt32 value)
        //{
        //    if (BitConverter.IsLittleEndian)
        //    {
        //        return ReverseBytes(value);
        //    }
        //    else
        //    {
        //        return value;
        //    }
        //}

        //internal static UInt32 GetLittleEndian(UInt32 value)
        //{
        //    if (!BitConverter.IsLittleEndian)
        //    {
        //        return ReverseBytes(value);
        //    }
        //    else
        //    {
        //        return value;
        //    }
        //}

        // 翻转字节顺序 (16-bit)
        internal static UInt16 ReverseBytes(UInt16 value)
        {
            return (UInt16)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }

        // 翻转字节顺序 (32-bit)
        internal static UInt32 ReverseBytes(UInt32 value)
        {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }

        // 翻转字节顺序 (64-bit)
        internal static UInt64 ReverseBytes(UInt64 value)
        {
            return (value & 0x00000000000000FFUL) << 56 | (value & 0x000000000000FF00UL) << 40 |
                   (value & 0x0000000000FF0000UL) << 24 | (value & 0x00000000FF000000UL) << 8 |
                   (value & 0x000000FF00000000UL) >> 8 | (value & 0x0000FF0000000000UL) >> 24 |
                   (value & 0x00FF000000000000UL) >> 40 | (value & 0xFF00000000000000UL) >> 56;
        }
    }
}
