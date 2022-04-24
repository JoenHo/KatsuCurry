using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// This class is the pgae model class for About.cshtml 
    /// </summary>
    public class AboutModel : PageModel
    {
        // logger object
        private readonly ILogger<AboutModel> _logger;

        /// <summary>
        /// Constructor for AboutModel class
        /// </summary>
        /// <param name="logger">logger object</param>
        public AboutModel(ILogger<AboutModel> logger) => _logger = logger;

        /// <summary>
        /// Whenever a user makes a GET request to a page, this method is invoked
        /// </summary>
        public void OnGet()
        {
        }
    }
}
