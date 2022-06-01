using System.Linq;

using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Home
{

    /// <summary>
    /// This class is for unit testing HomeModel class
    /// The tests cover the following methods:
    /// - OnGet()
    /// </summary>
    public class HomeTests
    {
        #region TestSetup

        public static HomeModel pageModel;

        /// <summary>
        /// Setting up the test environment
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<HomeModel>>();

            pageModel = new HomeModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// ModelState.IsValid should return true after OnGet is called
        /// With valid activity, Products should contain items
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
            Assert.AreEqual(true, pageModel.Foods.ToList().Any());
        }
        #endregion OnGet
    }
}