using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// This class holds C# representation of the Food.json data
    /// </summary>
    public class Food
    {

        // followings are the properties of Food data
        public string? restaurant { get; set; }
        public string? description { get; set; }
        [JsonPropertyName("img")]
        public string? image { get; set; }

        /// <summary>
        /// This method converts the class objects back to JSON representation
        /// </summary>
        /// Returns a string of JSON representation of the class objects</returns>
        public override string ToString() => JsonSerializer.Serialize<Food>(this);
    }
}
