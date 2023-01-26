using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JetStreamServiceNoSqlAPI.Models
{
    public class Registration
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        [BsonElement("Name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [BsonElement("EMail")]
        [JsonPropertyName("email")]
        public string EMail { get; set; }

        [BsonElement("Phone")]
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [BsonElement("CreateDate")]
        [JsonPropertyName("create_date")]
        public DateTime CreateDate { get; set; }

        [BsonElement("PickupDate")]
        [JsonPropertyName("pickup_date")]
        public DateTime PickupDate { get; set; }

        [BsonElement("Kommentar")]
        [JsonPropertyName("kommentar")]
        public string Kommentar { get; set; }

        [BsonElement("Service")]
        [JsonPropertyName("service")]
        public string Service { get; set; }

        [BsonElement("Priority")]
        [JsonPropertyName("priority")]
        public string Priority { get; set; }

        [BsonElement("Status")]
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
