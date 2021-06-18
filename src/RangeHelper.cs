using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace GenericRange
{
    partial struct Index<T>
    {
        private static readonly Func<T, T, T> s_subtract = GetGenericSubtractDelegate();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T Subtract(in T minuend, in T subtrahend) => s_subtract(minuend, subtrahend);
        
        /// <summary>Returns a compiled delegate function evaluating the difference between a minuend and a subtrahend.</summary>
        /// <exception cref="NotSupportedException">
        ///     The generic type is not one of <see langword="sbyte"/>, <see langword="byte"/>, <see langword="short"/>, <see langword="ushort"/>, <see langword="int"/>,
        ///     <see langword="uint"/>, <see langword="long"/>, <see langword="ulong"/>, <see langword="float"/>, <see langword="double"/>, <see langword="decimal"/>, <see langword="char"/>,
        ///     <see langword="TimeSpan"/>, or any <see cref="Enum"/> type with one of the aforementioned as underlying type.
        /// </exception>
        public static Func<T, T, T> GetGenericSubtractDelegate()
        {
            switch (default(T))
            {
                case sbyte:
                case byte:
                case short:
                case ushort:
                case int:
                case char:
                    return SubtractInt32;
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
                if (RangeHelper.TypeToSubtractDelegateMap.TryGetValue(underlyingType, out Delegate? subtractDelegate))
                    return (Func<T, T, T>)subtractDelegate;
                
                Type rangeHelper = typeof(Index<>).MakeGenericType(underlyingType);
                MethodInfo subtractMethod = rangeHelper.GetMethod(nameof(GetGenericSubtractDelegate), BindingFlags.Public | BindingFlags.Static)!;
                Delegate subtractFunction = Delegate.CreateDelegate(rangeHelper, subtractMethod);
                
                RangeHelper.TypeToSubtractDelegateMap.Add(underlyingType, subtractFunction);
                return (Func<T, T, T>)subtractFunction;
            }
            
            throw new NotSupportedException("The type is not supported. Supported type are sbyte, byte, short, ushort, int, uint, long, ulong, float, double, decimal, char, TimeSpan, or any Enum or Nullable<T> type with one of the aforementioned as underlying type.");
        }

        private static T SubtractInt32(T minuend, T subtrahend) => (minuend.Cast<int>() - subtrahend.Cast<int>()).Cast<T>();
        private static T SubtractUInt32(T minuend, T subtrahend) => (minuend.Cast<uint>() - subtrahend.Cast<uint>()).Cast<T>();
        private static T SubtractInt64(T minuend, T subtrahend) => (minuend.Cast<long>() - subtrahend.Cast<long>()).Cast<T>();
        private static T SubtractUInt64(T minuend, T subtrahend) => (minuend.Cast<ulong>() - subtrahend.Cast<ulong>()).Cast<T>();
        private static T SubtractSingle(T minuend, T subtrahend) => (minuend.Cast<float>() - subtrahend.Cast<float>()).Cast<T>();
        private static T SubtractDouble(T minuend, T subtrahend) => (minuend.Cast<double>() - subtrahend.Cast<double>()).Cast<T>();
        private static T SubtractDecimal(T minuend, T subtrahend) => (minuend.Cast<decimal>() - subtrahend.Cast<decimal>()).Cast<T>();
        private static T SubtractTimeSpan(T minuend, T subtrahend) => (minuend.Cast<TimeSpan>() - subtrahend.Cast<TimeSpan>()).Cast<T>();
    }

    internal static class RangeHelper
    {
        private static readonly ThreadLocal<Dictionary<Type, Delegate>> s_typeToSubtractDelegateMap = new(() => new Dictionary<Type, Delegate>());
        
        public static IDictionary<Type, Delegate> TypeToSubtractDelegateMap => s_typeToSubtractDelegateMap.Value!;

        // Working around the compiler.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T Cast<T>(this object obj) => (T)obj;

        public static Range ToRange(this Range<int> range) => new(new Index(range.Start.Value, range.Start.IsFromEnd), new Index(range.End.Value, range.End.IsFromEnd));
    }
}