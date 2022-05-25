using ContosoCrafts.WebSite.Controllers;
using NUnit.Framework;

namespace UnitTests.Controllers
{

    /// <summary>
    /// This class is for unit testing ProductsController class
    /// The tests cover the following methods:
    /// - Get()
    /// - Patch()
    /// </summary>
    class ProductsControllerTest
    {
        #region TestSetup
        //Instance of Model
        public static ProductsController pageModel;

        /// <summary>
        /// Setting up the test environment
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ProductsController(TestHelper.ProductService) {};
        }

        #endregion TestSetup

        #region Get
        /// <summary>
        /// ModelState.IsValid should return true after Get is called
        /// </summary>
        [Test]
        public void Get_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.Get();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        /// <summary>
        /// ModelState.IsValid should return true after GetFoodData is called
        /// </summary>
        [Test]
        public void GetFoodData_Valid_Should_Return_Food()
        {
            // Arrange

            // Act
            pageModel.GetFoodData();
            
            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        #endregion Get

        #region Patch
        /// <summary>
        /// ModelState.IsValid should return true after GetFoodData is called
        /// The response should be ok with a valid rating request
        /// </summary>
        [Test]
        public void Patch_Valid_Rating_Patch_Should_Return_Ok()
        {
            // Arrange
            var request = new ProductsController.RatingRequest();
            request.ProductId = "kamonegi";
            request.Rating = 5;

            // Act
            var response = pageModel.Patch(request);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.OkResult>(response);
        }

        /// <summary>
        /// ModelState.IsValid should return true after GetFoodData is called
        /// The response should be bad with a null rating request
        /// </summary>
        [Test]
        public void Patch_Null_Rating_Patch_Should_Return_BadRequest()
        {
            // Arrange
            var request = new ProductsController.RatingRequest();
            request.ProductId = null;
            request.Rating = 5;

            // Act
            var response = pageModel.Patch(request);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.BadRequestResult>(response);
        }

        #endregion Patch

    }

}