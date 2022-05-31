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
        // THe following methods are simple implementation of
        // C# System under HTTPClient to call a request
        // to our desire API, logger and ProdocutService
        // then post it and display to homepage for viewing
        private readonly ILogger<HomeModel> _logger;

        /// <summary>
        /// Constructor for HomeModel class
        /// </summary>
        /// <param name="logger">logger object</param>
        public HomeModel(ILogger<HomeModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }
        public IEnumerable<Models.Product>? Products { get; private set; }
        public IEnumerable<Models.Food>? Foods { get; private set; }

        /// <summary>
        /// Whenever a user makes a GET request to a page, this method is invoked
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetProducts();
            Foods = ProductService.GetFood();
        }
}
}