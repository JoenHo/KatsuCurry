using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// This class is the pgae model class for Privacy.cshtml 
    /// </summary>
    public class PrivacyModel : PageModel
    {

        // logger object
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// Constructor for PrivacyModel class
        /// </summary>
        /// <param name="logger">logger object</param>
        public PrivacyModel(ILogger<PrivacyModel> logger) => _logger = logger;

        /// <summary>
        /// Whenever a user makes a GET request to a page, this method is invoked
        /// </summary>
        public void OnGet()
        {
        }
    }
}

