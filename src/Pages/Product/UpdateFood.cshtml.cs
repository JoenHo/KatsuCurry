using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class UpdateFoodModel : PageModel
    {
        public JsonFileProductService ProductService { get; }

        public UpdateFoodModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        public void OnGet()
        {
        }
    }
}

