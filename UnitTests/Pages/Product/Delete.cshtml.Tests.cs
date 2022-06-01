using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Delete
{

    /// <summary>
    /// This class is for unit testing DeleteModel class
    /// The tests cover the following methods:
    /// - OnGet()
    /// - OnPost()
    /// </summary>
    public class DeleteTests
    {
        #region TestSetup
        public static DeleteModel pageModel;

        /// <summary>
        /// Setting up the test environment
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DeleteModel(TestHelper.ProductService)
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
        /// PageModel should still be valid after a delete.
        /// The page should change to Index when a restaurant is deleted
        /// The restaurant that has been deleted should return null
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

            // First Create the product to delete
            pageModel.Product = TestHelper.ProductService.AppendData(pageModel.Product);
            pageModel.Product.Name = "Example to Delete";
            TestHelper.ProductService.UpdateData(pageModel.Product);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));

            // Confirm the item is deleted
            Assert.AreEqual(null, TestHelper.ProductService.GetProducts().FirstOrDefault(m=>m.Id.Equals(pageModel.Product.Id)));
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