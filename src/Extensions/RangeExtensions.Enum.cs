using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace GenericRange.Extensions
{
    public static partial class RangeExtensions
    {
        private static ConcurrentDictionary<Type, Array> s_enumValuesMap = new(); 

        /// <summary>
        /// Or`s values of the enum in the range to create a bit-mask.
        /// </summary>
        /// <param name="range">The <see cref="Enum"/> range.</param>
        /// <typeparam name="T">The <see cref="Enum"/> type.</typeparam>
        /// <returns>The signed 64-bit integer representing the created mask.</returns>
        /// <remarks>
        ///     Do not use, if your enum has non-flag, non-zero values, such as <c>All</c> where all bits are set.
        ///     <br/>
        ///     In that case use <see cref="Mask{T}(GenericRange.Range{T}, T)"/> with the highest bit-flag.
        /// </remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Mask<T>(this Range<T> range) where T : unmanaged, Enum
        {
            T[] values = GetEnumValues<T>();
            T maximum = values[values.Length - 1];
            return InternalMask(range, maximum, values);
        }

        /// <summary>
        /// Or`s values of the enum in the range to create a bit-mask.
        /// </summary>
        /// <param name="range">The <see cref="Enum"/> range.</param>
        /// <param name="maximum">The flag with the highest bit.</param>
        /// <typeparam name="T">The <see cref="Enum"/> type.</typeparam>
        /// <returns>The signed 64-bit integer representing the created mask.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Mask<T>(this Range<T> range, T maximum) where T : unmanaged, Enum
        {
            return InternalMask(range, maximum, GetEnumValues<T>());
        }

        private static long InternalMask<T>(Range<T> range, T maximum, T[] values) where T : unmanaged, Enum
        {
            T flag = range.Start.GetOffset(maximum);
            int index = Array.IndexOf(values, flag);

            Debug.Assert(index >= 0, "index >= 0");

            long value = flag.Convert<T, int>();
            while (++index < values.Length)
            {
                if (range.End.CompareTo(values[index], maximum) < 0)
                    break;
                value |= values[index].Convert<T, long>();
            }

            return value;
        }

        private static T[] GetEnumValues<T>() where T : unmanaged, Enum
        {
            Type t = typeof(T);
            
            if (s_enumValuesMap.TryGetValue(t, out var arr))
                return (T[])arr;

            T[] values = (T[])Enum.GetValues(typeof(T))!;
            Array.Sort(values, Index<T>.s_comparer);
            s_enumValuesMap.TryAdd(t, values);

            return values;
        }
    }
}
