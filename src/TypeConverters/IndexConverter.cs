using System;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
        public static Index<T> Parse(in ReadOnlySpan<char> serialized) => Parse(serialized, DefaultOptions);

        [Pure]
        public static unsafe Index<T> Parse(in ReadOnlySpan<char> serialized, JsonSerializerOptions options)
        {
            if (serialized.Length == 0)
            {
                return default;
            }

            bool fromEnd = serialized[0] == '^';
            ReadOnlySpan<char> valueStr = fromEnd ? serialized.Slice(1) : serialized;
            T resVal;
            
            if (!IsEnumUnderlying)
            {
                if (!IsTimeSpanUnderlying)
                {
                    resVal = options.Deserialize<T>(valueStr);
                }
                else
                {
                    // We know that T is TimeSpan, but we have to convince the runtime first.
                    // Since T is unmanaged we are able to cast the stack ptr.
                    TimeSpan timeSpan = new(options.Deserialize<long>(valueStr));
                    resVal = *(T*)&timeSpan;
                }
            }
            else
            {
                resVal = options.Deserialize<T>(valueStr.Quote(stackalloc char[valueStr.Length + 2]));
            }
            return new Index<T>(resVal, fromEnd);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(in Index<T> index) => ToString(index, DefaultOptions);
        
        [Pure]
        public static unsafe string ToString(Index<T> index, JsonSerializerOptions options)
        {
            string json;
            if (!IsEnumUnderlying)
            {
                if (!IsTimeSpanUnderlying)
                {
                    json = JsonSerializer.Serialize(index.Value, options);
                }
                else
                {
                    T value = index.Value;
                    json = JsonSerializer.Serialize((*(TimeSpan*)&value).Ticks, options);
                }
            }
            else
            {
                json = JsonSerializer.Serialize(index.Value, options)[1..^1];
            }
            
            if (index.IsFromEnd)
                return "^" + json;
            return json;
        }
    }
}
