using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Index
{
    /// <summary>
    /// This class is for unit testing ProductIndexModel class
    /// The tests cover the following methods:
    /// - OnGet()
    /// </summary>
    public class IndexTests
    {
        #region TestSetup
        public static PageContext pageContext;

        public static ProductIndexModel pageModel;

        /// <summary>
        /// Setting up the test environment
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ProductIndexModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// ModelState.IsValid should return true when OnGet is called with a valid restaurant id
        /// A list of products should be returned when tolist is called
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("restaurant");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }
        [Test]
        public void OnGet_Valid_Should_Return_Food()
        {
            // Arrange

            // Act
            pageModel.OnGet("food");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Food.ToList().Any());
            Assert.AreEqual("food", pageModel.RouteId);
        }
        #endregion OnGet
    }
}