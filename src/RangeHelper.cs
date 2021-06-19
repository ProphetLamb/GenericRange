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

    internal static class RangeHelper
    {
        private static readonly Dictionary<Type, Delegate> s_typeSubtractDelegateMap = new();
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T Cast<T>(this object obj) => (T)obj;
        
        internal static Func<object, object, object> GetGenericSubtractDelegate<T>() where T : unmanaged, IComparable
        {
            Type t = typeof(T);
            var subtractFunction = GetPrimitiveSubtractDelegate(t);
            if (subtractFunction != null)
                return subtractFunction;
            
            if (t.IsEnum)
               return GetEnumSubtractDelegate(t);
            
            throw new NotSupportedException("The type is not supported. Supported type are sbyte, byte, short, ushort, int, uint, long, ulong, float, double, decimal, char, TimeSpan, or any Enum or Nullable<T> type with one of the aforementioned as underlying type.");
        }

        private static Func<object, object, object>? GetPrimitiveSubtractDelegate(Type t)
        {
            if (t == typeof(sbyte))
                return (minuend, subtrahend) => (sbyte)(minuend.Cast<sbyte>() - subtrahend.Cast<sbyte>());
            if (t == typeof(byte))
                return (minuend, subtrahend) => (byte)(minuend.Cast<byte>() - subtrahend.Cast<byte>());
            if (t == typeof(short))
                return (minuend, subtrahend) => (short)(minuend.Cast<short>() - subtrahend.Cast<short>());
            if (t == typeof(ushort))
                return (minuend, subtrahend) => (ushort)(minuend.Cast<ushort>() - subtrahend.Cast<ushort>());
            if (t == typeof(int))
                return (minuend, subtrahend) => minuend.Cast<int>() - subtrahend.Cast<int>();
            if (t == typeof(char))
                return (minuend, subtrahend) => (char)(minuend.Cast<char>() - subtrahend.Cast<char>());
            if (t == typeof(uint))
                return (minuend, subtrahend) => minuend.Cast<uint>() - subtrahend.Cast<uint>();
            if (t == typeof(long))
                return (minuend, subtrahend) => minuend.Cast<long>() - subtrahend.Cast<long>();
            if (t == typeof(ulong))
                return (minuend, subtrahend) => minuend.Cast<ulong>() - subtrahend.Cast<ulong>();
            if (t == typeof(float))
                return (minuend, subtrahend) => minuend.Cast<float>() - subtrahend.Cast<float>();
            if (t == typeof(double))
                return (minuend, subtrahend) => minuend.Cast<double>() - subtrahend.Cast<double>();
            if (t == typeof(decimal))
                return (minuend, subtrahend) => minuend.Cast<decimal>() - subtrahend.Cast<decimal>();
            if (t == typeof(TimeSpan))
                return (minuend, subtrahend) => minuend.Cast<TimeSpan>() - subtrahend.Cast<TimeSpan>();
            return null;
        }

        private static Func<object, object, object> GetEnumSubtractDelegate(Type t)
        {
            Type underlyingType = t.GetEnumUnderlyingType();
            if (s_typeSubtractDelegateMap.TryGetValue(underlyingType, out Delegate? subtractDelegate))
                return (Func<object, object, object>)subtractDelegate;
            MethodInfo getSubtractMethod = typeof(RangeHelper)
               .GetMethod(nameof(GetGenericSubtractDelegate), BindingFlags.NonPublic | BindingFlags.Static)!
               .MakeGenericMethod(underlyingType);
            subtractDelegate = (Delegate)getSubtractMethod.Invoke(null, Array.Empty<object>());

            s_typeSubtractDelegateMap.Add(underlyingType, subtractDelegate);
            return (Func<object, object, object>)subtractDelegate;
        }
    }
}