﻿using System.Collections.Generic;
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

        public ContosoCrafts.WebSite.Models.Product CreateData()
        {
            var data = new ContosoCrafts.WebSite.Models.Product()
            {
                Id = System.Guid.NewGuid().ToString(),
                Name = "Enter Title",
                Url = "Enter URL",
                Image = "",
            };

            // Get the current set, and append the new record to it becuase
            // IEnumerable does not have Add
            var dataSet = GetProducts();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;


        }

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

    }
}
