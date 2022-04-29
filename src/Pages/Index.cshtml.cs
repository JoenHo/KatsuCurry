using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
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

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }
        public IEnumerable<ContosoCrafts.WebSite.Models.Product>? Products { get; private set; }

        public void OnGet() => Products = ProductService.GetProducts();
    }
}
