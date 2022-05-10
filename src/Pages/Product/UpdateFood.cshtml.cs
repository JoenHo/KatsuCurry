using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// This class defines the pgae model of UpdateFood page 
    /// </summary>
    public class UpdateFoodModel : PageModel
    {
        // service for acuiring data
        public JsonFileProductService ProductService { get; }

        // Bind the data for the post
        [BindProperty]
        public Food Food { get; set; } = default!;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="productService"></param>
        public UpdateFoodModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// This function is called when GET requested
        /// </summary>
        public void OnGet(string id)
        {
            Food = ProductService.GetFood().FirstOrDefault(m => m.Id.Equals(id));
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Food
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        /// <returns>index page</returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ProductService.UpdateFoodData(Food);

            return RedirectToPage("./ProductIndex");
        }
    }
}

