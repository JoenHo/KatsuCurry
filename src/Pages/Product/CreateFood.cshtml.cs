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
    public class CreateFoodModel : PageModel
    {
        public JsonFileProductService ProductService { get; }

        public CreateFoodModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        public void OnGet()
        {
        }
    }
}

