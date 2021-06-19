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
        private static readonly Dictionary<Type, Delegate> s_typeSubtractDelegateMap = new();
        
        // Working around the compiler.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T Cast<T>(this object obj) => (T)obj;

        public static Range ToRange(this Range<int> range) => new(new Index(range.Start.Value, range.Start.IsFromEnd), new Index(range.End.Value, range.End.IsFromEnd));

        public static Range<int> ToRange(this Range range) => new(new Index<int>(range.Start.Value, range.Start.IsFromEnd), new Index<int>(range.End.Value, range.End.IsFromEnd));
        
        public static Func<object, object, object> GetGenericSubtractDelegate<T>() where T : unmanaged, IComparable
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
                return (object minuend, object subtrahend) => (sbyte)(minuend.Cast<sbyte>() - subtrahend.Cast<sbyte>());
            else if (t == typeof(byte))
                return (object minuend, object subtrahend) => (byte)(minuend.Cast<byte>() - subtrahend.Cast<byte>());
            else if (t == typeof(short))
                return (object minuend, object subtrahend) => (short)(minuend.Cast<short>() - subtrahend.Cast<short>());
            else if (t == typeof(ushort))
                return (object minuend, object subtrahend) => (ushort)(minuend.Cast<ushort>() - subtrahend.Cast<ushort>());
            else if (t == typeof(int))
                return (object minuend, object subtrahend) => minuend.Cast<int>() - subtrahend.Cast<int>();
            else if (t == typeof(char))
                return (object minuend, object subtrahend) => (char)(minuend.Cast<char>() - subtrahend.Cast<char>());
            else if (t == typeof(uint))
                return (object minuend, object subtrahend) => minuend.Cast<uint>() - subtrahend.Cast<uint>();
            else if (t == typeof(long))
                return (object minuend, object subtrahend) => minuend.Cast<long>() - subtrahend.Cast<long>();
            else if (t == typeof(ulong))
                return (object minuend, object subtrahend) => minuend.Cast<ulong>() - subtrahend.Cast<ulong>();
            else if (t == typeof(float))
                return (object minuend, object subtrahend) => minuend.Cast<float>() - subtrahend.Cast<float>();
            else if (t == typeof(double))
                return (object minuend, object subtrahend) => minuend.Cast<double>() - subtrahend.Cast<double>();
            else if (t == typeof(decimal))
                return (object minuend, object subtrahend) => minuend.Cast<decimal>() - subtrahend.Cast<decimal>();
            else if (t == typeof(TimeSpan))
                return (object minuend, object subtrahend) => minuend.Cast<TimeSpan>() - subtrahend.Cast<TimeSpan>();
            return null;
        }

        private static Func<object, object, object> GetEnumSubtractDelegate(Type t)
        {
            Type underlyingType = t.GetEnumUnderlyingType();
            if (s_typeSubtractDelegateMap.TryGetValue(underlyingType, out Delegate? subtractDelegate))
                return (Func<object, object, object>)subtractDelegate;
            MethodInfo getSubtractMethod = typeof(RangeHelper)
               .GetMethod(nameof(GetGenericSubtractDelegate), BindingFlags.Public | BindingFlags.Static)!
               .MakeGenericMethod(underlyingType);
            subtractDelegate = (Delegate)getSubtractMethod.Invoke(null, Array.Empty<object>());

            s_typeSubtractDelegateMap.Add(underlyingType, subtractDelegate);
            return (Func<object, object, object>)subtractDelegate;
        }
    }
}