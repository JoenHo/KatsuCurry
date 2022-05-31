using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// This class holds C# representation of the Response.json data
    /// </summary>
    public class Response
    {

        // followings are the properties of Google Places API response
        public Candidates[]? candidates { get; set; }

        public string? status { get; set; }

        /// <summary>
        /// This method converts the class objects back to JSON representation
        /// </summary>
        /// Returns a string of JSON representation of the class objects</returns>
        public override string ToString() => JsonSerializer.Serialize<Response>(this);
    }

    public class Candidates
    {
        public string? formatted_address { get; set; }
        public string? name { get; set; }
        public string? place_id { get; set; }
    }
}