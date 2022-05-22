using System.Collections.Generic;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    public class HomeModel : PageModel
    {
        public class IndexModel : PageModel
        {
            private readonly ILogger<IndexModel> _logger;

            public IndexModel(ILogger<IndexModel> logger,
                JsonFileProductService productService)
            {
                _logger = logger;
                ProductService = productService;
            }

            public JsonFileProductService ProductService { get; }
            public IEnumerable<Models.Product>? Products { get; private set; }

            public void OnGet() => Products = ProductService.GetProducts();
        }
    }
}