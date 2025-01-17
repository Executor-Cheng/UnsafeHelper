﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.Unsafe;

public static class StructExtension
{
    public static unsafe TStruct ToStruct<TStruct>(this byte[] bytes) where TStruct : struct
    {
        if (sizeof(TStruct) != bytes.Length)
            throw new ArgumentOutOfRangeException(nameof(bytes), "Bytes array should be the same length as struct size.");
        TStruct val;
        fixed (byte* p = bytes)
        {
            Buffer.MemoryCopy(p, &val, (ulong)sizeof(TStruct), (ulong)sizeof(TStruct));
            return val;
        }
    }
    
    public static unsafe TStruct ToStruct<TStruct>(this Span<byte> bytes) where TStruct : struct
    {
        if (sizeof(TStruct) != bytes.Length)
            throw new ArgumentOutOfRangeException(nameof(bytes), "Bytes array should be the same length as struct size.");
        TStruct val;
        fixed (byte* p = bytes)
        {
            Buffer.MemoryCopy(p, &val, (ulong)sizeof(TStruct), (ulong)sizeof(TStruct));
            return val;
        }
    }
}
