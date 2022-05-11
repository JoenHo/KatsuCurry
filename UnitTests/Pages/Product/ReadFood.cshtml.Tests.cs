using ContosoCrafts.WebSite.Pages.Product;
using NUnit.Framework;

namespace UnitTests.Pages.Product.ReadFood
{
    /// <summary>
    /// This class is for unit testing ReadModel class
    /// The tests cover the following methods:
    /// - OnGet()
    /// </summary>
    public class ReadTests
    {
        #region TestSetup
        public static ReadFoodModel pageModel;

        /// <summary>
        /// Setting up the test environment
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadFoodModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// ModelState.IsValid should return true when OnGet is called with a valid restaurant id
        /// PageModel should be able to obtain the correct attributes of food data
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Be_Able_To_Read_Food()
        {
            // Arrange

            // Act
            pageModel.OnGet("soba");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("SOBA", pageModel.foods.Name);
        }
        #endregion OnGet
    }
}