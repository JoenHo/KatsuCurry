using System.Collections.Generic;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Apply simple and efficient authorize attribute for razor page
    /// </summary>
    public class IndexModel : PageModel
    {
        // THe following methods are simple implementation of
        // C# System under HTTPClient to call a request
        // to our desire API, logger and ProdocutService
        // then post it and display to homepage for viewing
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger) => _logger = logger;

        public void OnGet()
        {
        }
    }
}
