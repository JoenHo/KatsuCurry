using System.Collections.Generic;
using System.Linq;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// This class defines the pgae model of Privacy page 
    /// </summary>
    public class ReadFoodModel : PageModel
    {
        // service for acuiring data
        public JsonFileProductService ProductService { get; }
        // food data
        public Models.Food Food {get; set;} = default!;

        // Collection of the Restaurant Data
        public IEnumerable<Models.Product> Products { get; private set; } = default!;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="productService"></param>
        public ReadFoodModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// This function is called when GET requested
        /// </summary>
        /// <param name="id">item id</param>
        public void OnGet(string id)
        {
            var checknull = ProductService.GetFood().FirstOrDefault(m => m.Id.Equals(id));
            if (checknull is not null) {
                Food = checknull;
            }
            Products = ProductService.GetProducts();
        }
    }
}

