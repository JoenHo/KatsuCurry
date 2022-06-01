using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Net.Http;
using System.Net;
using System;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{ 
    public class JsonFileProductService
    {
        /// Initiate the web hosting environment for application to apply
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        /// Call the IWebHostEnvironment object
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// Get the file path and filename of Restaurant data for loading
        private string JsonFileRestaurantName => Path.Combine(
            WebHostEnvironment.WebRootPath, "data", "products.json");

        /// Get the file path and filename of Food data for loading
        private string JsonFileFoodName => Path.Combine(
                    WebHostEnvironment.WebRootPath, "data", "food.json");

        /// Get the json text and convert it to list
        public IEnumerable<Product> GetProducts()
        {
            using var jsonFileReader = File.OpenText(JsonFileRestaurantName);

            var productlist = JsonSerializer.Deserialize<Product[]>
                (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            /*if (productlist is null) {
                productlist = new Product[]{};
            }*/
            return productlist;
        }

        /// Get the json text and convert it to list
        public IEnumerable<Food> GetFood()
        {
            using var jsonFileReader = File.OpenText(JsonFileFoodName);
            var foodlist = JsonSerializer.Deserialize<Food[]>
                (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            /*if (foodlist is null) {
                foodlist = new Food[]{};
            }*/
            return foodlist;
        }

        /// <summary>
        /// This method is to add restaurant rating
        /// </summary>
        /// <param name="productId"></param> restaurant Id
        /// <param name="rating"></param> stars as rating
        public bool AddRating(string productId, int rating)
        {

            if (string.IsNullOrEmpty(productId)) {
                return false;
            }

            // Get information of the restaurant
            var products = GetProducts();

            var data = products.FirstOrDefault(x => x.Id == productId);
            
            if (data == null) {
                return false;
            }
            if (rating < 0) {
                return false;
            }
            if (rating > 5) {
                return false;
            }

            if (data.Ratings == null) {
                data.Ratings = new int[] { };
            }

            var ratings = data.Ratings.ToList();
            ratings.Add(rating);
            data.Ratings = ratings.ToArray();

            SaveData(products);

            return true;
        }

        /// <summary>
        /// Creates a restaurant record
        /// </summary>
        /// <returns></returns>
        public ContosoCrafts.WebSite.Models.Product CreateData()
        {
            var data = new ContosoCrafts.WebSite.Models.Product()
            {
                Id = System.Guid.NewGuid().ToString(),
            };

            return data;


        }

        /// <summary>
        /// Creates a food record
        /// </summary>
        /// <returns>food data created</returns>
        public Food CreateFoodData()
        {
            var data = new Food()
            {
                Id = System.Guid.NewGuid().ToString()
            };

            return data;
        }

        /// <summary>
        /// Adds restaurant record to dataset
        /// </summary>
        /// <returns> restaurant data added</returns>
        public Product AppendData(Product restaurant)
        {
            
            // Get the current set, and append the new record to it becuase
            // IEnumerable does not have Add
            var dataSet = GetProducts();

            using (var client = new HttpClient())
            {
                string querystring = restaurant.Name.Replace(" ", "%2C");
                var response = client.GetStringAsync(String.Format("https://maps.googleapis.com/maps/api/place/findplacefromtext/json?input=" + querystring + "&inputtype=textquery&fields=place_id&key=AIzaSyCUkutN1VIQIdgTfs-xbzw1sxL5woLls3Y")).Result;
                var result = JsonSerializer.Deserialize<Response>(response);
                if (result.status != "OK") {
                    restaurant.PlaceID = "ChIJ-bfVTh8VkFQRDZLQnmioK9s";
                }
                else {
                    restaurant.PlaceID = result.candidates[0].place_id;
                }
            }
            
            dataSet = dataSet.Append(restaurant);

            SaveData(dataSet);

            return restaurant;
        }

        /// <summary>
        /// Adds food record to dataset
        /// </summary>
        /// <returns> food data added</returns>
        public Food AppendFoodData(Food food)
        {
            
            // Get the current set, and append the new record to it becuase
            // IEnumerable does not have Add
            var dataSet = GetFood();
            dataSet = dataSet.Append(food);

            SaveFoodData(dataSet);

            return food;
        }

        /// <summary>
        /// Serialize restaurant objects to JSON file
        /// </summary>
        /// <param name="products">restaurant obj to serialize</param>
        private void SaveData(IEnumerable<ContosoCrafts.WebSite.Models.Product>
            products)
        {

            using (var outputStream = File.Create(JsonFileRestaurantName))
            {
                JsonSerializer.Serialize<IEnumerable
                    <ContosoCrafts.WebSite.Models.Product>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }

        /// <summary>
        /// Serialize food objects to JSON file
        /// </summary>
        /// <param name="foods">food objs to serialize</param>
        private void SaveFoodData(IEnumerable<Food> foods)
        {
            using (var outputStream = File.Create(JsonFileFoodName))
            {
                JsonSerializer.Serialize<IEnumerable<Food>>
                (
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    foods
                );
            }
        }


        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        public ContosoCrafts.WebSite.Models.Product UpdateData(
            ContosoCrafts.WebSite.Models.Product data)
        {
            var products = GetProducts();
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (productData == null)
            {
                return null;
            }

            productData.Name = data.Name;
            productData.Url = data.Url;
            productData.Image = data.Image;
            productData.Address = data.Address;
            productData.Phone = data.Phone;
            productData.Hours = data.Hours;

            SaveData(products);

            return productData;
        }

        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        /// <returns>food data updated</returns>
        public Food UpdateFoodData(Food data)
        {
            var foods = GetFood();
            var foodData = foods.FirstOrDefault(x => x is not null && x.Id.Equals(data.Id));
            if (foodData == null)
            {
                return null;
            }

            foodData.Name = data.Name;
            foodData.Description = data.Description;
            foodData.Image = data.Image;
            foodData.Restaurants = data.Restaurants;

            SaveFoodData(foods);

            return foodData;
        }

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public ContosoCrafts.WebSite.Models.Product DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetProducts();
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            var newDataSet = GetProducts().Where(m => m.Id.Equals(id) == false);
            
            SaveData(newDataSet);

            return data;
        }

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public Food DeleteFoodData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetFood();
            var data = dataSet.FirstOrDefault(m => m is not null && m.Id.Equals(id));

            var newDataSet = GetFood().Where(m => m is not null && m.Id.Equals(id) == false);

            SaveFoodData(newDataSet);

            return data;
        }
    }
}
