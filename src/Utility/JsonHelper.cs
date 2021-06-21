using System;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace GenericRange.Utility
{
    internal static class JsonHelper
    {
        private static readonly Lazy<Regex> s_rangeFormat = new (new Regex("^(\\^?.*)\\.{2}(\\^?.*)$", RegexOptions.Compiled));
        private static readonly Lazy<JsonSerializerOptions> s_enumOptions = new(() => {
            JsonSerializerOptions option = new(DefaultOptions);
            option.Converters.Add(new JsonStringEnumConverter());
            return option;
        });
        
        internal static Regex RangeFormat => s_rangeFormat.Value!;

        internal static JsonSerializerOptions DefaultOptions { get; } = new() { WriteIndented = false };

        internal static JsonSerializerOptions EnumOptions => s_enumOptions.Value!;

        internal static T? Deserialize<T>(this JsonSerializerOptions options, ReadOnlySpan<char> serialized)
        {
            Span<byte> utf8 = stackalloc byte[Encoding.UTF8.GetMaxByteCount(serialized.Length)];
            int byteCount = Encoding.UTF8.GetBytes(serialized, utf8);
            return JsonSerializer.Deserialize<T>(utf8.Slice(0, byteCount), options);
        }

        internal static JsonConverter<T>? TryGetConverter<T>(this JsonSerializerOptions options)
        {
            try 
            {
                return (JsonConverter<T>)options.GetConverter(typeof(T));
            }
            catch (NotSupportedException)
            {
                return null;
            }
        }
        
        internal static ReadOnlySpan<char> Quote(this ReadOnlySpan<char> str, Span<char> buffer)
        {
            ValueStringBuilder vsb = new(buffer);
            vsb.Append('\"');
            vsb.Append(str);
            vsb.Append('\"');
            return vsb.AsSpan();
        }
        
        internal static JsonSerializerOptions CopyAndRemoveConverter(this JsonSerializerOptions options, Type converterType)
        {
            JsonSerializerOptions modified = new (options);
            for (var i = modified.Converters.Count - 1; i >= 0; i--)
                if (modified.Converters[i].GetType() == converterType)
                    modified.Converters.RemoveAt(i);
            return modified;
        }
        
        internal static void WriteOrSerialize<T>(this JsonConverter<T>? converter, Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            if (converter != null)
                converter.Write(writer, value, options);
            else
                JsonSerializer.Serialize(writer, value, options);
        }
        
        internal static T? ReadOrSerialize<T>(this JsonConverter<T>? converter, ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return converter != null ? converter.Read(ref reader, typeToConvert, options) : (T)JsonSerializer.Deserialize(ref reader, typeToConvert, options)!;
        }
    }
}
