using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Meldpunt.Models
{
    public class Item
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Naam { get; set; }
        public DateTimeOffset Geboortedatum { get; set; }
        public string Beschrijving { get; set; }
        public string Telefoonnummer { get; set; }
    }

    public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTimeOffset.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
        }
    }
}
