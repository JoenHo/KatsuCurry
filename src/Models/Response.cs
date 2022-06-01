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
        
    }

    public class Candidates
    {
        public string? place_id { get; set; }
    }
}