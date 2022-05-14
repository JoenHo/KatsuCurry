using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
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
            return JsonSerializer.Deserialize<Product[]>
                (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        /// Get the json text and convert it to list
        public IEnumerable<Food> GetFood()
        {
            using var jsonFileReader = File.OpenText(JsonFileFoodName);
            return JsonSerializer.Deserialize<Food[]>
                (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        /// <summary>
        /// This method is to add restaurant rating
        /// </summary>
        /// <param name="productId"></param> restaurant Id
        /// <param name="rating"></param> stars as rating
        public void AddRating(string productId, int rating)
        {
            // Get information of the restaurant
            var products = GetProducts();

            if (products.First(x => x.Id == productId).Ratings == null)
            {
                products.First(x => x.Id == productId).Ratings = new int[]
                {
                    rating
                };
            }
            else
            {
                var ratings =
                    products.First(x => x.Id == productId).Ratings.ToList();
                ratings.Add(rating);
                products.First(x => x.Id == productId).Ratings =
                    ratings.ToArray();
            }

            // Update client's rating to restaurant
            using var outputRestaurantStream =
                File.OpenWrite(JsonFileRestaurantName);

            JsonSerializer.Serialize<IEnumerable<Product>>(
                new Utf8JsonWriter(outputRestaurantStream, new JsonWriterOptions
                {
                    SkipValidation = true,
                    Indented = true
                }),
                products
            );
        }

        /// <summary>
        /// Creates a restaurant record
        /// </summary>
        /// <returns></returns>
        public ContosoCrafts.WebSite.Models.Product CreateData(Product restaurant)
        {
            var data = new ContosoCrafts.WebSite.Models.Product()
            {
                Id = System.Guid.NewGuid().ToString(),
                Name = restaurant.Name,
                Phone = restaurant.Phone,
                Address = restaurant.Address,
                Url = restaurant.Url,
                Image = restaurant.Image,
                Hours = restaurant.Hours,
            };

            // Get the current set, and append the new record to it becuase
            // IEnumerable does not have Add
            var dataSet = GetProducts();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;


        }

        /// <summary>
        /// Creates a food record
        /// </summary>
        /// <returns>food data created</returns>
        public Food CreateFoodData(Food food)
        {
            var data = new Food()
            {
                Id = System.Guid.NewGuid().ToString(),
                Name = food.Name,
                Description = food.Description,
                Image = food.Image,
            };

            // Get the current set, and append the new record to it becuase
            // IEnumerable does not have Add
            var dataSet = GetFood();
            dataSet = dataSet.Append(data);

            SaveFoodData(dataSet);

            return data;
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
            var productData = products.FirstOrDefault(x =>
            x.Id.Equals(data.Id));
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
            var foodData = foods.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (foodData == null)
            {
                return null;
            }

            foodData.Name = data.Name;
            foodData.Description = data.Description;
            foodData.Image = data.Image;

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
    }
}
