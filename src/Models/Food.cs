using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// This class holds C# representation of the Food.json data
    /// </summary>
    public class Food
    {

        // followings are the properties of Food data
        public string Id { get; set; } = default!;

        [Required(ErrorMessage = "Food Name is required")]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Food Description is required")]
        public string? Description { get; set; }

        public string? Type { get; set; }

        [JsonPropertyName("img")]
        [Required(ErrorMessage = "Image url is required")]
        [Url(ErrorMessage = "url provided is not valid, try again...")]
        public string? Image { get; set; }
        public string[]? Restaurants { get; set; }

        /// <summary>
        /// This method converts the class objects back to JSON representation
        /// </summary>
        /// Returns a string of JSON representation of the class objects</returns>
        public override string ToString() => JsonSerializer.Serialize<Food>(this);
    }
}
