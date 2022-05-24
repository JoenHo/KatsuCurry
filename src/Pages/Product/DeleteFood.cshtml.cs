using System.Collections.Generic;
using System.Linq;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Manage the Delete of the data for a single record
    /// </summary>
    public class DeleteFoodModel : PageModel
    {
        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public DeleteFoodModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public ContosoCrafts.WebSite.Models.Food Food { get; set; } = default!;

        // Collection of the Restaurant Data
        public IEnumerable<Models.Product> Products { get; private set; } = default!;

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            var checknull = ProductService.GetFood().FirstOrDefault(m => m.Id.Equals(id));
            if (checknull is not null) {
                Food = checknull;
            }
            Products = ProductService.GetProducts();
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Delete that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ProductService.DeleteFoodData(Food.Id);

            return RedirectToPage("./ProductIndex", new { id = "food" });
        }

        }
}

