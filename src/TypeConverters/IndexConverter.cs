using System;
using System.Collections.Generic;
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
    /// <inheritdoc/>
    public sealed partial class IndexConverter<T> : DefaultConverterFactory<Index<T>> where T : unmanaged, IComparable
    {
        internal static bool IsEnumUnderlying { get; } = typeof(T).IsEnum;

        internal static bool IsTimeSpanUnderlying { get; } = typeof(T) == typeof(TimeSpan);

        internal static JsonSerializerOptions DefaultOptions { get; } = IsEnumUnderlying ? JsonHelper.EnumOptions : JsonHelper.DefaultOptions;

        static IndexConverter()
        {
            _ = new Index<T>(); // Throws type initializer error if invalid generic type.
        }

        /// <summary>Parses the index from a string.</summary>
        /// <param name="serialized">The string to parse.</param>
        /// <returns>The index represented by the string.</returns>
        /// <exception cref="ArgumentException">The <paramref name="serialized"/> string is empty.</exception>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Index<T> Parse(in ReadOnlySpan<char> serialized) => Parse(serialized, DefaultOptions);

        /// <summary>Parses the index from a string with the specified serialization options.</summary>
        /// <param name="serialized">The string to parse.</param>
        /// <param name="options">The serialization options.</param>
        /// <returns>The index represented by the string.</returns>
        /// <exception cref="ArgumentException">The <paramref name="serialized"/> string is empty.</exception>
        [Pure]
        public static unsafe Index<T> Parse(in ReadOnlySpan<char> serialized, JsonSerializerOptions options)
        {
            if (serialized.IsEmpty)
            {
                throw new ArgumentException("The serialized value cannot be empty.", nameof(serialized));
            }

            bool fromEnd = serialized[0] == '^';
            ReadOnlySpan<char> serializedValue = fromEnd ? serialized.Slice(1) : serialized;
            T resVal;

            if (!IsEnumUnderlying)
            {
                if (!IsTimeSpanUnderlying)
                {
                    resVal = options.Deserialize<T>(serializedValue);
                }
                else
                {
                    // We know that T is TimeSpan, but we have to convince the runtime first.
                    // Since T is unmanaged we are able to cast the stack ptr.
                    TimeSpan timeSpan = new(options.Deserialize<long>(serializedValue));
                    resVal = *(T*)&timeSpan;
                }
            }
            else
            {
                resVal = options.Deserialize<T>(serializedValue.Quote(stackalloc char[serializedValue.Length + 2]));
            }

            return new Index<T>(resVal, fromEnd);
        }

        /// <summary>Serializes the index to a string.</summary>
        /// <param name="index">The index to serialize.</param>
        /// <returns>The string representation of the index.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(in Index<T> index) => ToString(index, DefaultOptions);

        /// <summary>Serializes the index to a string with the specified serialization options.</summary>
        /// <param name="index">The index to serialize.</param>
        /// <param name="options">The serialization options.</param>
        /// <returns>The string representation of the index.</returns>
        [Pure]
        public static unsafe string ToString(Index<T> index, JsonSerializerOptions options)
        {
            string json;
            T value = index.Value;

            if (!IsEnumUnderlying)
            {
                if (!IsTimeSpanUnderlying)
                {
                    json = JsonSerializer.Serialize(value, options);
                }
                else
                {
                    json = JsonSerializer.Serialize((*(TimeSpan*)&value).Ticks, options);
                }
            }
            else
            {
                json = JsonSerializer.Serialize(value, options)[1..^1];
            }
            
            if (index.IsFromEnd)
                return "^" + json;
            return json;
        }
    }
}
