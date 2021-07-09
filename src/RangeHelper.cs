using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace GenericRange
{
    partial struct Index<T>
    {
        private static readonly IndexHelper<T>.Sub s_subtract = IndexHelper<T>.GetSubtractDelegate();
        internal static readonly Comparer<T> s_comparer = Comparer<T>.Default;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T Subtract(T minuend, T subtrahend)
        {
            return s_subtract(ref minuend, ref subtrahend);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int Compare(in T left, in T right) => s_comparer.Compare(left, right);
    }
    
    internal static unsafe class IndexHelper<T> where T : unmanaged
    {
        internal static ThreadLocal<object[]> s_subParams = new(() => new object[2]);
        
        internal delegate T Sub(ref T minuend, ref T subtrahend);

        internal static Sub GetSubtractDelegate()
        {
            Type t = typeof(T);

            Sub? subDelegate = GetPrimitiveSubtractDelegate(t);
            
            if (subDelegate == null && t.IsEnum)
            {
                Type underlyingType = t.GetEnumUnderlyingType();
                subDelegate = GetPrimitiveSubtractDelegate(underlyingType);
            }

            if (subDelegate != null)
                return (Sub)Delegate.CreateDelegate(typeof(Sub), null, subDelegate.GetMethodInfo());

            throw new InvalidOperationException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Sub? GetPrimitiveSubtractDelegate(Type t)
        {
            if (t == typeof(sbyte))
                return SubSbyte;
            if (t == typeof(byte))
                return SubByte;
            if (t == typeof(short))
                return SubShort;
            if (t == typeof(ushort))
                return SubUShort;
            if (t == typeof(int))
                return SubInt;
            if (t == typeof(uint))
                return SubUInt;
            if (t == typeof(long))
                return SubLong;
            if (t == typeof(ulong))
                return SubULong;
            if (t == typeof(float))
                return SubFloat;
            if (t == typeof(double))
                return SubDouble;
            if (t == typeof(decimal))
                return SubDecimal;
            if (t == typeof(char))
                return SubChar;
            if (t == typeof(TimeSpan))
                return SubTimeSpan;
            return null;
        }
        
        private static T SubSbyte(ref T minuend, ref T subtrahend)
        {
            T l = minuend, r = subtrahend;
            sbyte value = (sbyte)(*(sbyte*)&l - *(sbyte*)&r);
            return *(T*)&value;
        }

        private static T SubByte(ref T minuend, ref T subtrahend) 
        {
            T l = minuend, r = subtrahend;
            byte value = (byte)(*(byte*)&l - *(byte*)&r);
            return *(T*)&value;
        }

        private static T SubShort(ref T minuend, ref T subtrahend)
        {
            T l = minuend, r = subtrahend;
            short value = (short)(*(short*)&l - *(short*)&r);
            return *(T*)&value;
        }
        
        private static T SubUShort(ref T minuend, ref T subtrahend)
        {
            T l = minuend, r = subtrahend;
            ushort value = (ushort)(*(ushort*)&l - *(ushort*)&r);
            return *(T*)&value;
        }
        
        private static T SubInt(ref T minuend, ref T subtrahend)
        {
            T l = minuend, r = subtrahend;
            int value = *(int*)&l - *(int*)&r;
            return *(T*)&value;
        }
        
        private static T SubUInt(ref T minuend, ref T subtrahend)
        {
            T l = minuend, r = subtrahend;
            uint value = *(uint*)&l - *(uint*)&r;
            return *(T*)&value;
        }

        private static T SubLong(ref T minuend, ref T subtrahend)
        {
            T l = minuend, r = subtrahend;
            long value = *(long*)&l - *(long*)&r;
            return *(T*)&value;
        }

        private static T SubULong(ref T minuend, ref T subtrahend)
        {
            T l = minuend, r = subtrahend;
            ulong value = *(ulong*)&l - *(ulong*)&r;
            return *(T*)&value;
        }

        private static T SubFloat(ref T minuend, ref T subtrahend)
        {
            T l = minuend, r = subtrahend;
            float value = *(float*)&l - *(float*)&r;
            return *(T*)&value;
        }

        private static T SubDouble(ref T minuend, ref T subtrahend)
        {
            T l = minuend, r = subtrahend;
            double value = *(double*)&l - *(double*)&r;
            return *(T*)&value;
        }

        private static T SubDecimal(ref T minuend, ref T subtrahend)
        {
            T l = minuend, r = subtrahend;
            decimal value = *(decimal*)&l - *(decimal*)&r;
            return *(T*)&value;
        }
        
        private static T SubChar(ref T minuend, ref T subtrahend)
        {
            T l = minuend, r = subtrahend;
            char value = (char)(*(char*)&l - *(char*)&r);
            return *(T*)&value;
        }
        
        private static T SubTimeSpan(ref T minuend, ref T subtrahend)
        {
            T l = minuend, r = subtrahend;
            TimeSpan value = *(TimeSpan*)&l - *(TimeSpan*)&r;
            return *(T*)&value;
        }
    }
}