using System;
using System.Text.Json;

namespace GenericRange.TypeConverters
{
    public sealed partial class RangeConverter<T>
    {
        public override Range<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => Parse(reader.GetString()!, options);

        public override void Write(Utf8JsonWriter writer, Range<T> value, JsonSerializerOptions options) => writer.WriteStringValue(ToString(value, options));
    }
}
