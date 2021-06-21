using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace GenericRange.TypeConverters
{
    /*
     * Allowed generic types are only primitives, that are serialized as string values or numerics, not json objects.
     * Therefore there is not need to serialize the range in any other way, especially since we have a nice shorthand for indices [^]{value} and ranges [^]{start}..[^]{end}.
     */
    internal static class JsonHelper
    {
        private static readonly Lazy<Regex> s_rangeFormat = new (new Regex("^(\\^?.*)\\.{2}(\\^?.*)$", RegexOptions.Compiled));

        internal static Regex RangeFormat => s_rangeFormat.Value!;

        internal static JsonSerializerOptions DefaultOptions = new() { WriteIndented = false };
        
        private static Utf8JsonReader ReadString(ReadOnlySpan<char> json)
        {
            Span<byte> bytes = new byte[Encoding.UTF8.GetByteCount(json)];
            Encoding.UTF8.GetBytes(json, bytes);
            return new Utf8JsonReader(bytes);
        }

        internal static T ParseElement<T>(this JsonConverter<T> converter, ReadOnlySpan<char> json, JsonSerializerOptions options)
        {
            Utf8JsonReader reader = ReadString(json);
            T? value = converter.Read(ref reader, typeof(T), options);
            return value!;
        }

        internal static JsonConverter<T> GetConverter<T>(this JsonSerializerOptions options)
        {
            return (JsonConverter<T>)options.GetConverter(typeof(T));
        }

        internal static Utf8JsonWriter WriteBuffer(byte[] buffer)
        {
            using MemoryStream stream = new(buffer);
            return new(stream);
        }
    }
}
