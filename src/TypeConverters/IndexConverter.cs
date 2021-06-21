using System;
using System.Buffers;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GenericRange.TypeConverters
{
    public sealed partial class IndexConverter<T> : JsonConverter<Index<T>> where T : unmanaged, IComparable
    {
        private static readonly Lazy<IndexConverter<T>> s_default = new(() => new IndexConverter<T>());
        
        static IndexConverter()
        {
            _ = new Index<T>(); // Throws type initializer error if invalid generic type.
        }

        public static IndexConverter<T> Default => s_default.Value;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Index<T> Parse(string serialized) => Parse(serialized, JsonHelper.DefaultOptions);

        [Pure]
        public static Index<T> Parse(string serialized, JsonSerializerOptions options)
        {
            bool fromEnd = serialized[0] == '^';
            T value = options.GetConverter<T>().ParseElement(serialized.AsSpan(fromEnd ? 1 : 0), options);
            return new Index<T>(value, fromEnd);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(in Index<T> index) => ToString(index, JsonHelper.DefaultOptions);
        
        [Pure]
        public static string ToString(in Index<T> index, JsonSerializerOptions options)
        {
            string json = SerializeIndexValue(index.Value, options);
            return index.IsFromEnd ? '^' + json : json;
        }

        [Pure]
        internal static string SerializeIndexValue(T value, JsonSerializerOptions options)
        {
            byte[] buffer = ArrayPool<byte>.Shared.Rent(4096); // Lets just rent 1 page so we dont get a buffer-overflow
            ReadOnlySpan<byte> utf8;
            using (Utf8JsonWriter valueWriter = JsonHelper.WriteBuffer(buffer))
            {
                options.GetConverter<T>().Write(valueWriter, value, options);
                valueWriter.Flush();
                utf8 = buffer.AsSpan(0, (int)valueWriter.BytesCommitted);
            }
            string serialized = Encoding.UTF8.GetString(utf8);
            ArrayPool<byte>.Shared.Return(buffer);
            return serialized;
        }
    }
}
