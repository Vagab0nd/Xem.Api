﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xem.Api.Mapping;

namespace Xem.Api
{
    public class MappingCollectionJsonConverter : JsonConverter
    {
        public override bool CanWrite { get; } = false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MappingCollection);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            if (!(jObject is JObject dataValue))
            {
                return null;
            }

            var mappingEntries = dataValue.Properties().Select(me =>
            {
                var nameParts = me.Name.Split('_');
                var entryValues = me.Values().Select(v => v as JProperty);
                return new MappingEntry
                {
                    EntityType = this.GetEntityTypeFromName(nameParts.FirstOrDefault()),
                    EntityIndex = this.GetEntityIndexFromName(nameParts.LastOrDefault()),
                    Absolute = this.GetValueFromProperties(entryValues, "absolute"),
                    Episode = this.GetValueFromProperties(entryValues, "episode"),
                    Season = this.GetValueFromProperties(entryValues, "season")
                };

            })
            .ToList();

            return new MappingCollection(mappingEntries);            
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        private EntityType GetEntityTypeFromName(string name)
        {
            return (EntityType)Enum.Parse(typeof(EntityType), name, true);
        }

        private int GetEntityIndexFromName(string nameIndex)
        {
            return int.TryParse(nameIndex, out var result) ? result : 1;
        }

        private int GetValueFromProperties(IEnumerable<JProperty> properties, string propertyName)
        {
            if(!(properties.FirstOrDefault(v => v.Name == propertyName)?.Value is JToken propertyValue))
            {
                return 0;
            }
            
            return int.TryParse(propertyValue.Value<string>(), out var result) ? result : 0;
        }
    }
}
