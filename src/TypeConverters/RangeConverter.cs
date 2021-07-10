using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;

using GenericRange.Utility;

namespace GenericRange.TypeConverters
{
    /// <inheritdoc/>
    public sealed partial class RangeConverter<T> : DefaultConverterFactory<Range<T>> where T : unmanaged, IComparable
    {
        /// <summary>Parses the range from a string.</summary>
        /// <param name="serialized">The string to parse.</param>
        /// <returns>The range represented by the string.</returns>
        /// <exception cref="ArgumentException">The <paramref name="serialized"/> string is empty.</exception>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Range<T> Parse(string serialized) => Parse(serialized, IndexConverter<T>.DefaultOptions);

        /// <summary>Parses the range from a string with the specified serialization options.</summary>
        /// <param name="serialized">The string to parse.</param>
        /// <param name="options">The serialization options.</param>
        /// <returns>The range represented by the string.</returns>
        /// <exception cref="ArgumentException">The <paramref name="serialized"/> string is empty.</exception>
        [Pure]
        public static Range<T> Parse(string serialized, JsonSerializerOptions options)
        {
            Match match = JsonHelper.RangeFormat.Match(serialized);
            if (!match.Success)
                throw new FormatException("String is in a invalid Format. Expected [^]{start}..[^]{end}");

            ReadOnlySpan<char> startGroup = match.Groups[1].Value;
            Index<T> start = startGroup.IsEmpty ? default : IndexConverter<T>.Parse(startGroup, options);

            ReadOnlySpan<char> endGroup = match.Groups[2].Value;
            Index<T> end = endGroup.IsEmpty ? default : IndexConverter<T>.Parse(endGroup, options);

            return new Range<T>(start, end);
        }

        /// <summary>Serializes the range to a string.</summary>
        /// <param name="range">The range to serialize.</param>
        /// <returns>The string representation of the range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(in Range<T> range) => ToString(range, IndexConverter<T>.DefaultOptions);

        /// <summary>Serializes the range to a string with the specified serialization options.</summary>
        /// <param name="range">The range to serialize.</param>
        /// <param name="options">The serialization options.</param>
        /// <returns>The string representation of the range.</returns>
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
