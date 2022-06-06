using System.Diagnostics;
using ContosoCrafts.WebSite.Pages;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace UnitTests.Pages.Error
{
    /// <summary>
    /// This class is for unit testing ErrorModel class
    /// The tests cover the following methods:
    /// - OnGet()
    /// </summary>
    public class ErrorTests
    {
        #region TestSetup
        public static ErrorModel pageModel;

        /// <summary>
        /// Setting up the test environment
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // initialize ErrorModel instance with ILogger
            var MockLoggerDirect = Mock.Of<ILogger<ErrorModel>>();
            pageModel = new ErrorModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }
        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// ModelState.IsValid should return true after OnGet is called
        /// With valid activity, RequestId should be equal to activity.Id
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            // Arrange
            Activity activity = new Activity("activity");
            activity.Start();

            // Act
            pageModel.OnGet();

            // Reset
            activity.Stop();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(activity.Id, pageModel.RequestId);
        }

        /// <summary>
        /// RequestId should be TraceIdentifier "trace" when the Activity is invalid
        /// ModelState andShowRequestId should return true after OnGet is called
        /// </summary>
        [Test]
        public void OnGet_InValid_Activity_Null_Should_Return_TraceIdentifier()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("trace", pageModel.RequestId);
            Assert.AreEqual(true, pageModel.ShowRequestId);
        }

        /// <summary>
        /// RequestId should be TraceIdentifier "trace" when the Activity is invalid
        /// ModelState andShowRequestId should return true after OnGet is called
        /// </summary>
        [Test]
        public void OnGet_Error_Code_Should_Be_Stored()
        {
            // Arrange
            ErrorModel.func_error("Error 400");
            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Error 400", ErrorModel.error_str);
            Assert.AreEqual(true, pageModel.ShowRequestId);
        }
        #endregion OnGet
    }
}
