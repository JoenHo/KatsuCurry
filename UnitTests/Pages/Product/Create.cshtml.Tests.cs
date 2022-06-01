using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;


namespace UnitTests.Pages.Product.Create
{
    /// <summary>
    /// This class is for unit testing CreateModel class
    /// The tests cover the following methods:
    /// - OnGet()
    /// </summary>
    public class CreateTests
    {
        #region TestSetup
        public static CreateModel pageModel;

        /// <summary>
        /// Setting up the test environment
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CreateModel(TestHelper.ProductService)
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
        }
        #endregion OnGet

        #region OnPostAsync

        /// <summary>
        /// PageModel should still be valid after a delete.
        /// The page should change to Index when a restaurant is deleted
        /// The restaurant that has been deleted should return null
        /// </summary>
        [Test]
        public void OnPostAsync_Valid_Product_Should_Make_New_Product()
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

            var oldCount = TestHelper.ProductService.GetProducts().Count();

            // Act
            pageModel.OnPost();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(oldCount+1, TestHelper.ProductService.GetProducts().Count());
        }

        /// <summary>
        /// PageModel should still be valid after a delete.
        /// The page should change to Index when a restaurant is deleted
        /// The restaurant that has been deleted should return null
        /// </summary>
        [Test]
        public void OnPostAsync_inValid_Product_Name_Should_Have_Space_Needle_Place_ID()
        {
            // Arrange
            string[] hours = {"11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM", "11:00 AM – 11:00 PM"};

            pageModel.Product = new ContosoCrafts.WebSite.Models.Product
            {
                Id = "test",
                Name = "&inputtype=badquery&key=AIzaSyCUkutN1VIQIdgTfs",
                Phone = "bogus",
                Address = "bogus",
                Url = "bogus",
                Image = "bougs",
                Hours = hours
            };

            var oldCount = TestHelper.ProductService.GetProducts().Count();

            // Act
            pageModel.OnPost();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(oldCount+1, TestHelper.ProductService.GetProducts().Count());
            Assert.AreEqual("ChIJ-bfVTh8VkFQRDZLQnmioK9s", pageModel.Product.PlaceID);
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
