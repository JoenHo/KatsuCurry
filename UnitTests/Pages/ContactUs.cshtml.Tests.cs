using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.ContactUs
{

    /// <summary>
    /// This class is for unit testing IndexModel class
    /// The tests cover the following methods:
    /// - OnGet()
    /// </summary>
    public class ContactUsTests
    {
        #region TestSetup

        public static ContactUsModel pageModel;

        /// <summary>
        /// Setting up the test environment
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<ContactUsModel>>();

            pageModel = new ContactUsModel(MockLoggerDirect)
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
        }
        #endregion OnGet
    }
}