using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.UpdateFood
{
    /// <summary>
    /// This class is for unit testing UpdateModel class
    /// The tests cover the following methods:
    /// - OnGet()
    /// - OnPost()
    /// </summary>
    public class UpdateFoodTests
    {
        #region TestSetup
        public static UpdateFoodModel pageModel;

        /// <summary>
        /// Setting up the test environment
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateFoodModel(TestHelper.ProductService)
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
        public void OnGet_Valid_Should_Return_Food()
        {
            // Arrange

            // Act
            pageModel.OnGet("soba");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("SOBA", pageModel.Food.Name);
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
            pageModel.Food = new ContosoCrafts.WebSite.Models.Food
            {
                Id = "bogus",
                Name = "bogus",
                Description = "bogus",
                Image = "bougs",
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
            pageModel.Food = new ContosoCrafts.WebSite.Models.Food
            {
                Id = "bogus",
                Name = "bogus",
                Description = "bogus",
                Image = "bougs",
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