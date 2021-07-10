using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GenericRange.Utility
{
    /// <summary>
    ///     Boilderplate for a <see cref="JsonConverterFactory"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert.</typeparam>
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

        /// <summary>Reads the value from the stream.</summary>
        /// <param name="reader">The stream to read from.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">The options to use for serialization.</param>
        /// <param name="defaultConverter">The converter providing the conversion.</param>
        /// <returns></returns>
        protected virtual T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options, JsonConverter<T>? defaultConverter)
            => defaultConverter.ReadOrSerialize(ref reader, typeToConvert, options);

        /// <summary>Writes the value to the steam.</summary>
        /// <param name="writer">The stream to write to.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="options">The options to use for serialization.</param>
        /// <param name="defaultConverter">The converter providing the conversion.</param>
        protected virtual void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options, JsonConverter<T>? defaultConverter) 
            => defaultConverter.WriteOrSerialize(writer, value, options);

        /// <inheritdoc/>
        public override bool CanConvert(Type typeToConvert) => typeof(T) == typeToConvert;
        
        /// <inheritdoc/>
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) => new DefaultConverter(options, this);
    }
}
