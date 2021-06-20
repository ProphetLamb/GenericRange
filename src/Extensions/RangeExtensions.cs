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
        public static Range ToRange(this Range<int> range) => new(new Index(range.Start.Value, range.Start.IsFromEnd), new Index(range.End.Value, range.End.IsFromEnd));
    }
}
