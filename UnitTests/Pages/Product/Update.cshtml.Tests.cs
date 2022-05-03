using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Update
{
    /// <summary>
    /// This class is for unit testing UpdateModel class
    /// The tests cover the following methods:
    /// - OnGet()
    /// - OnPost()
    /// </summary>
    public class UpdateTests
    {
        #region TestSetup
        public static UpdateModel pageModel;

        /// <summary>
        /// Setting up the test environment
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// ModelState.IsValid should return true when OnGet is called with a valid restaurant id
        /// PageModel should be able to obtain the correct attributes of requested data
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("kamonegi");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Kamonegi", pageModel.Product.Name);
        }
        #endregion OnGet

        #region OnPostAsync
        /// <summary>
        /// PageModel should still be valid after an update.
        /// The page should change to Index when a restaurant is updated
        /// </summary>
        [Test]
        public void OnPostAsync_Valid_Should_Return_Products()
        {
            // Arrange
            string[] hours = {"11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM"};
            pageModel.Product = new ContosoCrafts.WebSite.Models.Product
            {
                Id = "bogus",
                Name = "bogus",
                Phone = "bogus",
                Address = "bogus",
                Url = "bogus",
                Image = "bougs",
                Hours = hours
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }

        [Test]
        /// <summary>
        /// An invalid model should return an invalid page
        /// </summary>
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
            string[] hours = {"11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM"};
            pageModel.Product = new ContosoCrafts.WebSite.Models.Product
            {
                Id = "bogus",
                Name = "bogus",
                Phone = "bogus",
                Address = "bogus",
                Url = "bogus",
                Image = "bougs",
                Hours = hours
            };

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPostAsync
    }
}