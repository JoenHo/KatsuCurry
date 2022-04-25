using System.Diagnostics;
using ContosoCrafts.WebSite.Pages;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace UnitTests.Pages.Privacy
{
    /// <summary>
    /// This class is for unit testing PrivacyModel class
    /// The tests cover the following methods:
    /// - OnGet()
    /// </summary>
    public class PrivacyTests
    {
        #region TestSetup
        public static PrivacyModel pageModel;

        /// <summary>
        /// Setting up the test environment
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // initialize PrivacyModel instance with ILogger
            var MockLoggerDirect = Mock.Of<ILogger<PrivacyModel>>();
            pageModel = new PrivacyModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }
        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// ModelState.IsValid should return true after OnGet is called
        /// </summary>
        [Test]
        public void OnGet_Valid_Model_State_Return_IsValisd_True()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }
        #endregion OnGet
    }
}
