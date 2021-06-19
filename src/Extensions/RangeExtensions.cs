using System;

namespace GenericRange.Extensions
{
    public static partial class RangeExtensions
    {
        public static Range ToRange(this Range<int> range) => new(new Index(range.Start.Value, range.Start.IsFromEnd), new Index(range.End.Value, range.End.IsFromEnd));

        public static Range<int> ToRange(this Range range) => new(new Index<int>(range.Start.Value, range.Start.IsFromEnd), new Index<int>(range.End.Value, range.End.IsFromEnd));
    }
}
