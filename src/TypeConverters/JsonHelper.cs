﻿using System;
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
        private static readonly Lazy<JsonSerializerOptions> s_defaultOptions = new(new JsonSerializerOptions { WriteIndented = false });

        internal static Regex RangeFormat => s_rangeFormat.Value!;

        internal static JsonSerializerOptions DefaultOptions => s_defaultOptions.Value!;

        internal static T ParseElement<T>(this JsonConverter<T> converter, ReadOnlySpan<char> json, JsonSerializerOptions options)
        {
            Span<byte> bytes = stackalloc byte[Encoding.UTF8.GetByteCount(json)];
            Encoding.UTF8.GetBytes(json, bytes);
            Utf8JsonReader reader = new(bytes);
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
            return new Utf8JsonWriter(stream);
        }
    }
}
