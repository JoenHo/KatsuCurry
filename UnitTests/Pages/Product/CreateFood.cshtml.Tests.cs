using System.Linq;

using Microsoft.AspNetCore.Mvc;

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
        /// ModelState.IsValid should return true when OnGet is called with a valid restaurant id
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
        }
        #endregion OnGet

        #region OnPostAsync
        /// <summary>
        /// ModelState.IsValid should return true when OnGet is called to create a new restaurant
        /// There should be one more product than before after creating a new restaurant
        /// </summary>
        [Test]
        public void OnPostAsync_Null_Food_Should_Make_New_Food()
        {
            // Arrange
            var oldCount = TestHelper.ProductService.GetFood().Count();

            // Act
            pageModel.OnPost();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(oldCount + 1, TestHelper.ProductService.GetFood().Count());
        }

        /// <summary>
        /// PageModel should still be valid after a delete.
        /// The page should change to Index when a restaurant is deleted
        /// The restaurant that has been deleted should return null
        /// </summary>
        [Test]
        public void OnPostAsync_Valid_Food_Should_Make_New_Food()
        {
            // Arrange
            pageModel.Food = new ContosoCrafts.WebSite.Models.Food
            {
                Id = "bogus",
                Name = "bogus",
                Description = "bogus",
                Image = "bougs"
            };

            var oldCount = TestHelper.ProductService.GetFood().Count();

            // Act
            pageModel.OnPost();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(oldCount+1, TestHelper.ProductService.GetFood().Count());
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
                Image = "bougs"
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