using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public void OnGet()
        {
        }
    }
}

