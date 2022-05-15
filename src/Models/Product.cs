using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// This class holds C# representation of the Product.json data
    /// </summary>
    public class Product
    {

        // followings are the properties of Product
        public string? Id { get; set; }

        [Required(ErrorMessage = "Restaurant Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }

        [JsonPropertyName("website")]
        [Required(ErrorMessage = "Url input is required")]
        public string? Url { get; set; }

        [JsonPropertyName("img")]
        [Required(ErrorMessage = "Image is required")]
        public string? Image { get; set; }

        [Required(ErrorMessage = "Restaurant Hour is required")]
        public string[]? Hours { get; set; }

        public string[]? Dishes { get; set; }

        public int[]? Ratings { get; set; }
 

        /// <summary>
        /// This method converts the class objects back to JSON representation
        /// </summary>
        /// <returns>a string of JSON representation of the class objects</returns>
        public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }
}
