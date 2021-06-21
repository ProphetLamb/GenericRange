using System;
using System.Text.Json;

namespace GenericRange.TypeConverters
{
    public sealed partial class IndexConverter<T>
    {
        public override Index<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => Parse(reader.GetString()!, options);

        public override void Write(Utf8JsonWriter writer, Index<T> value, JsonSerializerOptions options) => writer.WriteStringValue(ToString(value, options));
    }
}
