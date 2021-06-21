using System;
using System.Reflection;
using System.Text.Json;

using GenericRange.Utility;

namespace GenericRange.TypeConverters
{
    public sealed partial class IndexConverter<T>
    {
        internal delegate ReadOnlySpan<char> SerializeDelegate(ref Index<T> index, JsonSerializerOptions options);

        internal delegate T DeserializeDelegate(ref ReadOnlySpan<char> serialized, JsonSerializerOptions options);

        internal static SerializeDelegate Serialize;

        internal static DeserializeDelegate Deserialize;

        private static SerializeDelegate GetSerializeDelegate()
        {
            SerializeDelegate serialize;
            if (IsEnumUnderlying)
            {
                serialize = delegate(ref Index<T> index, JsonSerializerOptions options) {
                    return JsonSerializer.Serialize(index.Value, options).AsSpan()[1..^1];
                };
            }
            else if (IsTimeSpanUnderlying)
            {
                serialize = delegate(ref Index<T> index, JsonSerializerOptions options) {
                    return JsonSerializer.Serialize(index.Value.Cast<TimeSpan>().Ticks, options);
                };
            }
            else
            {
                serialize = delegate(ref Index<T> index, JsonSerializerOptions options) {
                    return JsonSerializer.Serialize(index.Value, options);
                };
            }
            
            return (SerializeDelegate)Delegate.CreateDelegate(typeof(SerializeDelegate), null, serialize.GetMethodInfo());
        }
        
        private static DeserializeDelegate GetDeserializeDelegate()
        {
            DeserializeDelegate deserialize;
            if (IsEnumUnderlying)
            {
                deserialize = delegate(ref ReadOnlySpan<char> serialized, JsonSerializerOptions options) {
                    var quoted = serialized.Quote(stackalloc char[serialized.Length + 2]);
                    return options.Deserialize<T>(quoted);
                };
            }
            else if (IsTimeSpanUnderlying)
            {
                deserialize = delegate(ref ReadOnlySpan<char> serialized, JsonSerializerOptions options) {
                    return new TimeSpan(options.Deserialize<long>(serialized)).Cast<T>();
                };
            }
            else
            {
                deserialize = delegate(ref ReadOnlySpan<char> serialized, JsonSerializerOptions options) {
                    return options.Deserialize<T>(serialized);
                };
            }

            return (DeserializeDelegate)Delegate.CreateDelegate(typeof(DeserializeDelegate), null, deserialize.GetMethodInfo());
        }
    }
}
