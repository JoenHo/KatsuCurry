using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Update
{
    public class UpdateTests
    {
        #region TestSetup
        public static UpdateModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
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