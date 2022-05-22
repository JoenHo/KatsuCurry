using System.Collections.Generic;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Apply simple and efficient authorize attribute for razor page
    /// </summary>
    public class HomeModel : PageModel
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

            /// <summary>
            /// Constructor for IndexModel class
            /// </summary>
            /// <param name="logger">logger object</param>
            public IndexModel(ILogger<IndexModel> logger,
                JsonFileProductService productService)
            {
                _logger = logger;
                ProductService = productService;
            }

            public JsonFileProductService ProductService { get; }
            public IEnumerable<Models.Product>? Products { get; private set; }

            /// <summary>
            /// Whenever a user makes a GET request to a page, this method is invoked
            /// </summary>
            public void OnGet() => Products = ProductService.GetProducts();
        }
    }
}