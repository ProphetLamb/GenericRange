using System;
using System.Buffers;
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

        public static Index<T> Parse(string serialized, JsonSerializerOptions? options = default)
        {
            options ??= JsonHelper.DefaultOptions;
            
            bool fromEnd = serialized[0] == '^';
            T value = options.GetConverter<T>().ParseElement(serialized.AsSpan(fromEnd ? 1 : 0), options);
            return new Index<T>(value, fromEnd);
        }

        public static string ToString(Index<T> index, JsonSerializerOptions? options = default)
        {
            options ??= JsonHelper.DefaultOptions;
            
            string json = SerializeIndexValue(index.Value, options);
            return index.IsFromEnd ? '^' + json : json;
        }

        internal static string SerializeIndexValue(T value, JsonSerializerOptions options)
        {
            byte[] buffer = ArrayPool<byte>.Shared.Rent(1024); // Allocate 1kb in the pool just to be sure we can serialize even the longest value :)
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
