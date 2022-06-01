using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class CreateModel : PageModel
    {
        // Data middle tier
        public JsonFileProductService ProductService { get; }

        // Bind the data for the post
        [BindProperty]
        public Models.Product Product { get; set; } = default!;

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public CreateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// This function is called when GET requested
        /// </summary>
        public void OnGet()
        {
            Product = ProductService.CreateData();
        }

        /// <summary>
        /// This function is called when POST requested
        /// </summary>
        /// <returns>index page</returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Product = ProductService.AppendData(Product);
            return RedirectToPage("./ProductIndex", new {id = "restaurant"});
        }
    }
}