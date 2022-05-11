using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;


namespace UnitTests.Pages.Product.CreateFood
{
    /// <summary>
    /// This class is for unit testing CreateModel class
    /// The tests cover the following methods:
    /// - OnGet()
    /// </summary>
    public class CreateTests
    {
        #region TestSetup
        public static CreateFoodModel pageModel;

        /// <summary>
        /// Setting up the test environment
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CreateFoodModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// ModelState.IsValid should return true when OnGet is called to create a new restaurant
        /// There should be one more product than before after creating a new restaurant
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            var oldCount = TestHelper.ProductService.GetProducts().Count();

            // Act
            pageModel.OnPost();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(oldCount + 1, TestHelper.ProductService.GetProducts().Count());
        }
        #endregion OnGet
    }
}