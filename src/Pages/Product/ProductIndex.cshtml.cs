using System.Collections.Generic;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class ProductIndexModel : PageModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public ProductIndexModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // Data Service
        public JsonFileProductService ProductService { get; }

        // Collection of the Restaurant Data
        public IEnumerable<ContosoCrafts.WebSite.Models.Product> Products { get; private set; } = default!;

        // Collection of the Food Data
        public IEnumerable<ContosoCrafts.WebSite.Models.Food> Food { get; private set; } = default!;

        // id passed into this page
        public string RouteId { get; set; } = default!;

        /// <summary>
        /// REST OnGet, return all data
        /// </summary>
        public void OnGet(string id)
        {
            Products = ProductService.GetProducts();
            Food = ProductService.GetFood();
            RouteId = id;
        }
    }
}

