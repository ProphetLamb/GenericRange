using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace GenericRange.TypeConverters
{
    public sealed partial class RangeConverter<T> : JsonConverter<Range<T>> where T : unmanaged, IComparable
    {
        private static readonly Lazy<RangeConverter<T>> s_default = new(() => new RangeConverter<T>());

        static RangeConverter()
        {
            _ = new Range<T>(); // Throws type initializer error if invalid generic type. 
        }

        public static RangeConverter<T> Default => s_default.Value;

        public static Range<T> Parse(string serialized, JsonSerializerOptions? options = default)
        {
            options ??= JsonHelper.DefaultOptions;

            Match match = JsonHelper.RangeFormat.Match(serialized);
            if (!match.Success)
                throw new FormatException("String is in a invalid Format. Expected [^]{start}..[^]{end}");

            JsonConverter<T> valueConverter = options.GetConverter<T>();

            ReadOnlySpan<char> startJson = match.Groups[1].Value;
            bool startFromEnd = startJson[0] == '^';
            T startValue = valueConverter.ParseElement(startJson.Slice(startFromEnd ? 1 : 0), options);

            ReadOnlySpan<char> endJson = match.Groups[1].Value;
            bool endFromEnd = endJson[0] == '^';
            T endValue = valueConverter.ParseElement(endJson.Slice(endFromEnd ? 1 : 0), options);

            return new Range<T>(startValue, startFromEnd, endValue, endFromEnd);
        }

        public static string ToString(Range<T> range, JsonSerializerOptions? options = default)
        {
            options ??= JsonHelper.DefaultOptions;

            string startValue = IndexConverter<T>.SerializeIndexValue(range.Start.Value, options);
            string endValue = IndexConverter<T>.SerializeIndexValue(range.End.Value, options);

            ValueStringBuilder sb = new(stackalloc char[startValue.Length + endValue.Length + 4]);
            if (range.Start.IsFromEnd)
                sb.Append('^');
            sb.Append(startValue);
            sb.Append(range.End.IsFromEnd ? "..^" : "..");
            sb.Append(endValue);
            return sb.ToString();
        }
    }
}
