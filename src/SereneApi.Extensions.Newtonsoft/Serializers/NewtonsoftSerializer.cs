﻿using Newtonsoft.Json;
using SereneApi.Abstractions.Request.Content;
using SereneApi.Abstractions.Response.Content;
using SereneApi.Abstractions.Serializers;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace SereneApi.Extensions.Newtonsoft.Serializers
{
    /// <summary>
    /// An <seealso cref="ISerializer"/> that implements Newtonsoft for Serialization.
    /// </summary>
    public class NewtonsoftSerializer: ISerializer
    {
        public JsonSerializerSettings DeserializerSettings { get; }

        public JsonSerializerSettings SerializerSettings { get; }

        /// <summary>
        /// Creates a new instance of <see cref="NewtonsoftSerializer"/> using the default settings.
        /// </summary>
        public NewtonsoftSerializer()
        {
            DeserializerSettings = DefaultDeserializerSettings;
            SerializerSettings = DefaultSerializerSettings;
        }

        /// <summary>
        /// Creates a new instance of <see cref="NewtonsoftSerializer"/> using the specified settings.
        /// </summary>
        /// <param name="settings">the settings to be used for serialization and deserialization.</param>
        /// <exception cref="ArgumentNullException">Thrown when a null value is provided.</exception>
        public NewtonsoftSerializer([NotNull] JsonSerializerSettings settings)
        {
            DeserializerSettings = settings ?? throw new ArgumentNullException(nameof(settings));
            SerializerSettings = settings;
        }

        /// <summary>
        /// Creates a new instance of <see cref="NewtonsoftSerializer"/> using the specified settings.
        /// </summary>
        /// <param name="deserializerSettings">the settings to be used for deserialization.</param>
        /// <param name="serializerSettings">the settings to be used for serialization.</param>
        /// <exception cref="ArgumentNullException">Thrown when a null value is provided.</exception>
        public NewtonsoftSerializer([NotNull] JsonSerializerSettings deserializerSettings, [NotNull] JsonSerializerSettings serializerSettings)
        {
            DeserializerSettings = deserializerSettings ?? throw new ArgumentNullException(nameof(deserializerSettings));
            SerializerSettings = serializerSettings ?? throw new ArgumentNullException(nameof(serializerSettings));
        }

        /// <inheritdoc>
        ///     <cref>ISerializer.Deserialize</cref>
        /// </inheritdoc>
        public TObject Deserialize<TObject>([NotNull] IApiResponseContent content)
        {
            if(content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            string contentString = content.GetContentString();

            return JsonConvert.DeserializeObject<TObject>(contentString, DeserializerSettings);
        }

        /// <inheritdoc>
        ///     <cref>ISerializer.DeserializeAsync</cref>
        /// </inheritdoc>
        public async Task<TObject> DeserializeAsync<TObject>([NotNull] IApiResponseContent content)
        {
            if(content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            string contentString = await content.GetContentStringAsync();

            return JsonConvert.DeserializeObject<TObject>(contentString, DeserializerSettings);
        }

        /// <inheritdoc>
        ///     <cref>ISerializer.Serialize</cref>
        /// </inheritdoc>
        public IApiRequestContent Serialize<T>([NotNull] T value)
        {
            if(value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            string jsonContent = JsonConvert.SerializeObject(value, SerializerSettings);

            return new JsonContent(jsonContent);
        }

        /// <inheritdoc>
        ///     <cref>ISerializer.SerializeAsync</cref>
        /// </inheritdoc>
        public Task<IApiRequestContent> SerializeAsync<T>([NotNull] T value)
        {
            if(value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return Task.Factory.StartNew(() =>
            {
                string jsonContent = JsonConvert.SerializeObject(value, SerializerSettings);

                return (IApiRequestContent)new JsonContent(jsonContent);
            });
        }

        /// <summary>
        /// The default settings used for Deserialization by <seealso cref="NewtonsoftSerializer"/>.
        /// </summary>
        public static JsonSerializerSettings DefaultDeserializerSettings { get; } = new JsonSerializerSettings();

        /// <summary>
        /// The default settings used for serialization by <seealso cref="NewtonsoftSerializer"/>.
        /// </summary>
        public static JsonSerializerSettings DefaultSerializerSettings { get; } = new JsonSerializerSettings();
    }
}