using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace GenericRange
{
    partial struct Index<T>
    {
        private static readonly Func<object, object, object> s_subtract = RangeHelper.GetGenericSubtractDelegate<T>();
        private static readonly Comparer<T> s_comparer = Comparer<T>.Default;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T Subtract(in T minuend, in T subtrahend) => s_subtract(minuend, subtrahend).Cast<T>();
    }

    public static class RangeHelper
    {
        private static readonly Dictionary<Type, MulticastDelegate> s_typeSubtractDelegateMap = new();
        
        // Working around the compiler.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T Cast<T>(this object obj) => (T)obj;

        public static Range ToRange(this Range<int> range) => new(new Index(range.Start.Value, range.Start.IsFromEnd), new Index(range.End.Value, range.End.IsFromEnd));

        public static Range<int> ToRange(this Range range) => new(new Index<int>(range.Start.Value, range.Start.IsFromEnd), new Index<int>(range.End.Value, range.End.IsFromEnd));
        
        public static Func<object, object, object> GetGenericSubtractDelegate<T>() where T : unmanaged, IComparable
        {
            switch (new T())
            {
                case sbyte:
                    return SubtractSByte;
                case byte:
                    return SubtractByte;
                case short:
                    return SubtractInt16;
                case ushort:
                    return SubtractUInt16;
                case int:
                    return SubtractInt32;
                case char:
                    return SubtractChar;
                case uint:
                    return SubtractUInt32;
                case long:
                    return SubtractInt64;
                case ulong:
                    return SubtractUInt64;
                case float:
                    return SubtractSingle;
                case double:
                    return SubtractDouble;
                case decimal:
                    return SubtractDecimal;
                case TimeSpan:
                    return SubtractTimeSpan;
            }

            Type t = typeof(T);
            if (t.IsEnum)
            {
                Type underlyingType = t.GetEnumUnderlyingType();
                if (s_typeSubtractDelegateMap.TryGetValue(underlyingType, out MulticastDelegate? subtractDelegate))
                    return (Func<object, object, object>)subtractDelegate;
                
                MethodInfo getSubtractMethod = typeof(RangeHelper)
                   .GetMethod(nameof(GetGenericSubtractDelegate), BindingFlags.Public | BindingFlags.Static)!
                   .MakeGenericMethod(underlyingType);
                subtractDelegate = (MulticastDelegate)getSubtractMethod.Invoke(null, Array.Empty<object>());
                
                s_typeSubtractDelegateMap.Add(underlyingType, subtractDelegate);
                return (Func<object, object, object>)subtractDelegate;
            }
            
            throw new NotSupportedException("The type is not supported. Supported type are sbyte, byte, short, ushort, int, uint, long, ulong, float, double, decimal, char, TimeSpan, or any Enum or Nullable<T> type with one of the aforementioned as underlying type.");
        }
        
        private static object SubtractSByte(object minuend, object subtrahend) => (sbyte)(minuend.Cast<sbyte>() - subtrahend.Cast<sbyte>());
        private static object SubtractByte(object minuend, object subtrahend) => (byte)(minuend.Cast<byte>() - subtrahend.Cast<byte>());
        private static object SubtractInt16(object minuend, object subtrahend) => (short)(minuend.Cast<short>() - subtrahend.Cast<short>());
        private static object SubtractUInt16(object minuend, object subtrahend) => (ushort)(minuend.Cast<ushort>() - subtrahend.Cast<ushort>());
        private static object SubtractInt32(object minuend, object subtrahend) => minuend.Cast<int>() - subtrahend.Cast<int>();
        private static object SubtractChar(object minuend, object subtrahend) => (char)(minuend.Cast<char>() - subtrahend.Cast<char>());
        private static object SubtractUInt32(object minuend, object subtrahend) => minuend.Cast<uint>() - subtrahend.Cast<uint>();
        private static object SubtractInt64(object minuend, object subtrahend) => minuend.Cast<long>() - subtrahend.Cast<long>();
        private static object SubtractUInt64(object minuend, object subtrahend) => minuend.Cast<ulong>() - subtrahend.Cast<ulong>();
        private static object SubtractSingle(object minuend, object subtrahend) => minuend.Cast<float>() - subtrahend.Cast<float>();
        private static object SubtractDouble(object minuend, object subtrahend) => minuend.Cast<double>() - subtrahend.Cast<double>();
        private static object SubtractDecimal(object minuend, object subtrahend) => minuend.Cast<decimal>() - subtrahend.Cast<decimal>();
        private static object SubtractTimeSpan(object minuend, object subtrahend) => minuend.Cast<TimeSpan>() - subtrahend.Cast<TimeSpan>();
    }
}