using System.Linq;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// This class defines the pgae model of Privacy page 
    /// </summary>
    public class ReadModel : PageModel
    {
        // service for acuiring data
        public JsonFileProductService ProductService { get; }
        // restaurant data
        public Models.Product restaurants {get; set;} = default!;
      
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="productService"></param>
        public ReadModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// This function is called when GET requested
        /// </summary>
        /// <param name="id">item id</param>
        public void OnGet(string id)
        {
            var checknull = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
            if (checknull is not null) {
                restaurants = checknull;
            }
        }
    }
}

