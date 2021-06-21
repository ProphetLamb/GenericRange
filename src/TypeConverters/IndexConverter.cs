using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Text.Json;

using GenericRange.Utility;

namespace GenericRange.TypeConverters
{
    /*
     * Allowed generic types are exclusively primitives or Enums, that are serialized as string values or numerics, not json objects.
     * Therefore there is not need to serialize the range in any other way, especially since we have a nice shorthand for indices [^]{value} and ranges [^]{start}..[^]{end}.
     */
    public sealed partial class IndexConverter<T> : DefaultConverterFactory<Index<T>> where T : unmanaged, IComparable
    {
        internal static bool IsEnumUnderlying { get; } = typeof(T).IsEnum;

        internal static bool IsTimeSpanUnderlying { get; } = typeof(T) == typeof(TimeSpan);
        
        internal static JsonSerializerOptions DefaultOptions { get; } = IsEnumUnderlying ? JsonHelper.EnumOptions : JsonHelper.DefaultOptions;
        
        static IndexConverter()
        {
            _ = new Index<T>(); // Throws type initializer error if invalid generic type.
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Index<T> Parse(ReadOnlySpan<char> serialized) => Parse(serialized, DefaultOptions);

        [Pure]
        public static Index<T> Parse(ReadOnlySpan<char> serialized, JsonSerializerOptions options)
        {
            bool fromEnd = serialized[0] == '^';
            if (fromEnd)
                serialized = serialized.Slice(fromEnd ? 1 : 0);
            if (IsTimeSpanUnderlying)
                return new Index<T>(new TimeSpan(options.Deserialize<long>(serialized)).Cast<T>(), fromEnd);
            if (IsEnumUnderlying)
                return new Index<T>(options.Deserialize<T>(serialized.Quote(stackalloc char[serialized.Length + 2])), fromEnd);
            return new Index<T>(options.Deserialize<T>(serialized), fromEnd);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(in Index<T> index) => ToString(index, DefaultOptions);
        
        [Pure]
        public static string ToString(in Index<T> index, JsonSerializerOptions options)
        {
            ReadOnlySpan<char> json;
            if (IsTimeSpanUnderlying)
                json = JsonSerializer.Serialize(index.Value.Cast<TimeSpan>().Ticks, options);
            else if (IsEnumUnderlying)
                json = JsonSerializer.Serialize(index.Value, options).AsSpan()[1..^1];
            else
                json = JsonSerializer.Serialize(index.Value, options);
            
            if (index.IsFromEnd)
                return "^" + json.ToString();
            return json.ToString();
        }
    }
}
