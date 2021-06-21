using System;

namespace GenericRange.Extensions
{
    public static partial class RangeExtensions
    {
        /// <summary>
        /// Converts the generic range to a integer <see cref="Range"/>.
        /// </summary>
        /// <param name="range">The range</param>
        /// <returns>The <see cref="Range"/> equivalent to the <paramref name="range"/>.</returns>
        public static Range ToRange(this Range<int> range) => new(range.Start.ToIndex(), range.End.ToIndex());
        
        /// <summary>
        /// Converts the generic index to a integer <see cref="Index"/>.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The <see cref="Index"/> equivalent to the <paramref name="index"/>.</returns>
        public static Index ToIndex(this Index<int> index) => new(index.Value, index.IsFromEnd);
    }
}
