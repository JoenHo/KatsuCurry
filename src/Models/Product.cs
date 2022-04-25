using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// This class holds C# representation of the Product.json data
    /// </summary>
    public class Product
    {

        // followings are the properties of Product
        [JsonPropertyName("place_id")]
        public string? Id { get; set; }
        public string? Maker { get; set; }

        [JsonPropertyName("img")]
        public string? Image { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? phone { get; set; }
        public int[]? Ratings { get; set; }

        /// <summary>
        /// This method converts the class objects back to JSON representation
        /// </summary>
        /// <returns>a string of JSON representation of the class objects</returns>
        public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }
}
