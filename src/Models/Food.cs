using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    public class Food
    {
        public string? restaurant { get; set; }
        public string? description { get; set; }
        [JsonPropertyName("img")]
        public string? image { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Food>(this);
    }
}
