using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GenericRange.TypeConverters
{
    public sealed partial class RangeConverter<T>
    {
        /// <inheritdoc/>
        protected override Range<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options, JsonConverter<Range<T>>? defaultConverter)
        {
            return Parse(reader.GetString()!, options);
        }

        /// <inheritdoc/>
        protected override void Write(Utf8JsonWriter writer, Range<T> value, JsonSerializerOptions options, JsonConverter<Range<T>>? defaultConverter)
        {
            writer.WriteStringValue(ToString(value, options));
        }

        /// <inheritdoc/>
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            if (typeof(T).IsEnum)
                options.Converters.Add(new JsonStringEnumConverter());
            return base.CreateConverter(typeToConvert, options);
        }
    }
}
