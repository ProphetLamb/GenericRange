using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace GenericRange.Extensions
{
    public static partial class RangeExtensions
    {
        /// <summary>Enumerates all integers in the <see cref="Range{T}"/>, from start inclusive and end inclusive.</summary>
        /// <param name="range">The range.</param>
        /// <param name="length">The length.</param>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<int> Enumerate(this Range<int> range, int length)
        {
            int start = range.Start.GetOffset(length), end = range.End.GetOffset(length);
            for (int i = start; i < end; i++)
                yield return i;
        }
        
        /// <summary>Enumerates all integers in the <see cref="Range{T}"/>, from start inclusive and end inclusive.</summary>
        /// <param name="range">The range.</param>
        /// <param name="length">The length.</param>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<long> Enumerate(this Range<long> range, long length)
        {
            long start = range.Start.GetOffset(length), end = range.End.GetOffset(length);
            for (long i = start; i < end; i++)
                yield return i;
        }
    }
}
