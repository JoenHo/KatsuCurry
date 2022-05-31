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
        public string Id { get; set; } = default!;

        [Required(ErrorMessage = "Restaurant Name is required")]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Not a valid phone number")]
        [StringLength(14)]
        public string? Phone { get; set; }

        public string? Type { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(@"^[#.0-9a-zA-Z\s,-]+$",
            ErrorMessage = "Please Enter a valid address!")]
        [StringLength(80)]
        public string? Address { get; set; }

        [JsonPropertyName("website")]
        [Required(ErrorMessage = "Url input is required")]
        [Url(ErrorMessage = "Please Enter a valid address!")]
        public string? Url { get; set; }

        [JsonPropertyName("img")]
        [Required(ErrorMessage = "Image url is required")]
        public string? Image { get; set; }

        [Required(ErrorMessage = "Restaurant Hour is required")]
        public string[]? Hours { get; set; }

        public string[]? Dishes { get; set; }

        public int[]? Ratings { get; set; }

        public string? PlaceID { get; set; }
 

        /// <summary>
        /// This method converts the class objects back to JSON representation
        /// </summary>
        /// <returns>a string of JSON representation of the class objects</returns>
        public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }
}
