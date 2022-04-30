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
    public class UpdateModel : PageModel
    {
        // Data middletier
        public JsonFileProductService ProductService { get; }
    }

    /// <summary>
    /// Defualt Construtor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="productService"></param>
    public UpdateModel(JsonFileProductService productService)
    {
        ProductService = productService;
    }

    // The data to show, bind to it for the post
    [BindProperty]
    public ContosoCrafts.WebSite.Models.Product Product { get; set; }
}

