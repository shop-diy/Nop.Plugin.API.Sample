using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public class HubSpotPropertiesConverter : JsonConverter<HubSpotProperties>
    {
        public override HubSpotProperties ReadJson(JsonReader reader, Type objectType, [AllowNull] HubSpotProperties existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartObject)
            {
                throw new JsonException();
            }

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                {
                    return new HubSpotProperties(dictionary);
                }

                // Next value must be a property name
                if (reader.TokenType != JsonToken.PropertyName)
                {
                    throw new JsonException();
                }

                string key = reader.Value as string;

                // Get the value.
                string value = reader.ReadAsString();

                // Add to dictionary
                dictionary.Add(key, value as string);
            }

            throw new JsonException();
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] HubSpotProperties value, Newtonsoft.Json.JsonSerializer serializer)
        {
            writer.WriteStartObject();

            foreach (var kvp in value)
            {
                writer.WritePropertyName(kvp.Key);
                serializer.Serialize(writer, kvp.Value);
            }

            writer.WriteEndObject();
        }
    }
}
