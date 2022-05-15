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
    /// This class defines the pgae model of CreateFood page 
    /// </summary>
    public class CreateFoodModel : PageModel
    {
        // service for acuiring data
        public JsonFileProductService ProductService { get; }

        // Bind the data for the post
        [BindProperty]
        public Food Food { get; set; } = default!;

        // Collection of the Restaurant Data
        public IEnumerable<Models.Product> Products { get; private set; } = default!;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="productService"></param>
        public CreateFoodModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// This function is called when GET requested
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }

        /// <summary>
        /// This function is called when POST requested
        /// </summary>
        /// <returns>index page</returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                if(Products == null)
                {
                    Products = ProductService.GetProducts();
                }

                return Page();
            }
            if (Food is null) {
                var food = new Food
                {
                    Name = "bogus",
                    Description = "bogus",
                    Image = "bougs",
                };
                Food = ProductService.CreateFoodData(food);
                return RedirectToPage("./ProductIndex");
            }
            else {
                Food = ProductService.CreateFoodData(Food);
                return RedirectToPage("./ProductIndex");
            }
        }
    }
}

