using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Controllers
{
    /// <summary>
    /// This class is a controller class for Product
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Constructor of ProductsController
        /// </summary>
        /// <param name="productService">product service</param>
        public ProductsController(JsonFileProductService productService) => 
            ProductService = productService;

        /// <summary>
        /// This method is for getting the JsonFileProductService
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// This method returns the product list when HttpGet is requested
        /// </summary>
        /// <returns>product</returns>
        [HttpGet]
        public IEnumerable<Product> Get() => ProductService.GetProducts();

        /// <summary>
        /// This method returns the food list when HttpGet is requested
        /// </summary>
        /// <returns>food</returns>
        [HttpGet]
        public IEnumerable<Food> GetFoodData() => ProductService.GetFood();

        /// <summary>
        /// This method updates the rating of the requested item
        /// </summary>
        /// <param name="request">RatingRequest object</param>
        /// <returns>ActionResult</returns>
        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            if (request.ProductId == null)
                return BadRequest();

            ProductService.AddRating(request.ProductId, request.Rating);

            return Ok();
        }

        /// <summary>
        /// This class holds ProductId and Rating that are requested to be updated
        /// </summary>
        public class RatingRequest
        {
            public string? ProductId { get; set; }
            public int Rating { get; set; }
        }
    }
}
