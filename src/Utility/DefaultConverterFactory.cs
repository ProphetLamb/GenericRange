using System;
using System.Text.Json;
using System.Text.Json.Serialization;

using GenericRange.Extensions;

namespace GenericRange.Utility
{
    public abstract class DefaultConverterFactory<T> : JsonConverterFactory
    {
        private sealed class DefaultConverter : JsonConverter<T>
        {
            private readonly JsonSerializerOptions _options;
            private readonly DefaultConverterFactory<T> _factory;
            private readonly JsonConverter<T>? _defaultConverter;
            
            public DefaultConverter(JsonSerializerOptions options, DefaultConverterFactory<T> factory)
            {
                _factory = factory;
                _options = options.CopyAndRemoveConverter(factory.GetType());
                _defaultConverter = _options.TryGetConverter<T>();
            }
        
            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) => _factory.Write(writer, value, _options, _defaultConverter);

            public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => _factory.Read(ref reader, typeToConvert, _options, _defaultConverter);
        }

        protected virtual T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions modifiedOptions, JsonConverter<T>? defaultConverter)
            => defaultConverter.ReadOrSerialize(ref reader, typeToConvert, modifiedOptions);

        protected virtual void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options, JsonConverter<T>? defaultConverter) 
            => defaultConverter.WriteOrSerialize(writer, value, options);

        public override bool CanConvert(Type typeToConvert) => typeof(T) == typeToConvert;
        
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) => new DefaultConverter(options, this);
    }
}
