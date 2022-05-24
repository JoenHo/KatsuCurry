using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.About
{

    /// <summary>
    /// This class is for unit testing IndexModel class
    /// The tests cover the following methods:
    /// - OnGet()
    /// </summary>
    public class AboutTests
    {
        #region TestSetup

        public static AboutModel pageModel;

        /// <summary>
        /// Setting up the test environment
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<AboutModel>>();

            pageModel = new AboutModel(MockLoggerDirect)
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
        public void OnGet_Valid_Should_Page()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }
        #endregion OnGet
    }
}