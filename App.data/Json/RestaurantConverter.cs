using App.data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace App.data.Json
{
    public class RestaurantConverter : JsonConverter<Restaurant>
    {
        Dictionary<string, Type> typeDeserialize;
        public RestaurantConverter()
        {
            typeDeserialize = new Dictionary<string, Type>();
            typeDeserialize.Add("Restaurant", typeof(Restaurant));
        }
        public override Restaurant Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            //var doc = JsonDocument.ParseValue(ref reader);
            //Restaurant obj = JsonSerializer.Deserialize<Restaurant>(doc);
            //return obj as Restaurant;
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Restaurant value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
