using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;

using GenericRange.Utility;

namespace GenericRange.TypeConverters
{
    public sealed partial class RangeConverter<T> : DefaultConverterFactory<Range<T>> where T : unmanaged, IComparable
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Range<T> Parse(string serialized) => Parse(serialized, IndexConverter<T>.DefaultOptions);

        [Pure]
        public static Range<T> Parse(string serialized, JsonSerializerOptions options)
        {
            Match match = JsonHelper.RangeFormat.Match(serialized);
            if (!match.Success)
                throw new FormatException("String is in a invalid Format. Expected [^]{start}..[^]{end}");

            ReadOnlySpan<char> startGroup = match.Groups[1].Value;
            Index<T> start = IndexConverter<T>.Parse(startGroup, options);
            ReadOnlySpan<char> endGroup = match.Groups[2].Value;
            Index<T> end = IndexConverter<T>.Parse(endGroup, options);
            return new Range<T>(start, end);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(in Range<T> range) => ToString(range, IndexConverter<T>.DefaultOptions);

        [Pure]
        public static string ToString(in Range<T> range, JsonSerializerOptions options)
        {
            ValueStringBuilder vsb = new(stackalloc char[32]);
            vsb.Append(IndexConverter<T>.ToString(range.Start, options));
            vsb.Append("..");
            vsb.Append(IndexConverter<T>.ToString(range.End, options));
            return vsb.ToString();
        }
    }
}
