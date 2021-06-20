using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace GenericRange.Extensions
{
    public static partial class RangeExtensions
    {
        
        /// <summary>Enumerates all integers in the <see cref="Range{T}"/>, from start inclusive and end inclusive.</summary>
        /// <param name="range">The range.</param>
        /// <param name="length">The length.</param>
        [Pure]
        public static IEnumerable<long> Enumerate(this Range<long> range, long length)
        {
            long start = range.Start.GetOffset(length), end = range.End.GetOffset(length);
            for (long i = start; i < end; i++)
                yield return i;
        }

        /// <summary>Enumerates all integers in the <see cref="Range{T}"/>, from start inclusive and end inclusive.</summary>
        /// <param name="range">The range.</param>
        /// <param name="length">The length.</param>
        [Pure]
        public static IEnumerable<long> Enumerate(this Range<long> range)
        {
            range.AssertNotFromEnd();
            for (long i = range.Start.Value; i < range.End.Value; i++)
                yield return i;
        }
        
        /// <summary>Enumerates all integers in the <see cref="Range{T}"/>, from start inclusive and end inclusive.</summary>
        /// <param name="range">The range.</param>
        /// <param name="length">The length.</param>
        [Pure]
        public static IEnumerable<int> Enumerate(this Range<int> range, int length)
        {
            int start = range.Start.GetOffset(length), end = range.End.GetOffset(length);
            for (int i = start; i < end; i++)
                yield return i;
        }
        
        /// <summary>Enumerates all integers in the <see cref="Range{T}"/>, from start inclusive and end inclusive.</summary>
        /// <param name="range">The range.</param>
        [Pure]
        public static IEnumerable<int> Enumerate(this Range<int> range)
        {
            range.AssertNotFromEnd();
            int start = range.Start.Value, end = range.End.Value;
            for (int i = start; i < end; i++)
                yield return i;
        }
    }
}
