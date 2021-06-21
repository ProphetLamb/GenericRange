using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace GenericRange.Extensions
{
    public static partial class RangeExtensions
    {
        /// <summary>
        /// Converts the generic range to a integer <see cref="Range"/>.
        /// </summary>
        /// <param name="range">The IConvertible range.</param>
        /// <returns>The <see cref="Range"/> equivalent to the <paramref name="range"/>.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Range ToRange<T>(this Range<T> range) where T : unmanaged, IComparable, IConvertible
        {
            return new(range.Start.ToIndex(), range.End.ToIndex());
        }

        /// <summary>
        /// Converts the generic index to a integer <see cref="Index"/>.
        /// </summary>
        /// <param name="index">The IConvertible index.</param>
        /// <returns>The <see cref="Index"/> equivalent to the <paramref name="index"/>.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Index ToIndex<T>(this Index<T> index) where T : unmanaged, IComparable, IConvertible
        {
            return new(index.Value.Convert<int, T>(), index.IsFromEnd);
        }
    }
}
