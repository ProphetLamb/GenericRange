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

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static T Subtract(object minuend, object subtrahend) => s_subtract(ref minuend, ref subtrahend);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int Compare(in T left, in T right) => s_comparer.Compare(left, right);
    }
    
    internal static class IndexHelper<T> where T : unmanaged
    {
        internal static ThreadLocal<object[]> s_subParams = new(() => new object[2]);
        
        internal delegate T Sub(ref object minuend, ref object subtrahend);

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

        private static T SubSbyte(ref object minuend, ref object subtrahend) => ((sbyte)(minuend.Cast<sbyte>() - subtrahend.Cast<sbyte>())).Cast<T>();

        private static T SubByte(ref object minuend, ref object subtrahend) => ((byte)(minuend.Cast<byte>() - subtrahend.Cast<byte>())).Cast<T>();

        private static T SubShort(ref object minuend, ref object subtrahend) => ((short)(minuend.Cast<short>() - subtrahend.Cast<short>())).Cast<T>();

        private static T SubUShort(ref object minuend, ref object subtrahend) => ((ushort)(minuend.Cast<ushort>() - subtrahend.Cast<ushort>())).Cast<T>();

        private static T SubInt(ref object minuend, ref object subtrahend) => (minuend.Cast<int>() - subtrahend.Cast<int>()).Cast<T>();

        private static T SubUInt(ref object minuend, ref object subtrahend) => (minuend.Cast<uint>() - subtrahend.Cast<uint>()).Cast<T>();

        private static T SubLong(ref object minuend, ref object subtrahend) => (minuend.Cast<long>() - subtrahend.Cast<long>()).Cast<T>();

        private static T SubULong(ref object minuend, ref object subtrahend) => (minuend.Cast<ulong>() - subtrahend.Cast<ulong>()).Cast<T>();

        private static T SubFloat(ref object minuend, ref object subtrahend) => (minuend.Cast<float>() - subtrahend.Cast<float>()).Cast<T>();

        private static T SubDouble(ref object minuend, ref object subtrahend) => (minuend.Cast<double>() - subtrahend.Cast<double>()).Cast<T>();

        private static T SubDecimal(ref object minuend, ref object subtrahend) => (minuend.Cast<decimal>() - subtrahend.Cast<decimal>()).Cast<T>();
        
        private static T SubChar(ref object minuend, ref object subtrahend) => ((char)(minuend.Cast<char>() - subtrahend.Cast<char>())).Cast<T>();
        
        private static T SubTimeSpan(ref object minuend, ref object subtrahend) => (minuend.Cast<TimeSpan>() - subtrahend.Cast<TimeSpan>()).Cast<T>();
    }

    internal static class RangeHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T Cast<T>(this object obj) => (T)obj;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TOut Convert<TIn, TOut>(this TIn obj)
            where TIn : unmanaged
            where TOut : unmanaged
        {
            return (TOut)System.Convert.ChangeType(obj, typeof(TOut));
        }
    }
}