using ContosoCrafts.WebSite.Controllers;
using NUnit.Framework;

namespace UnitTests.Controllers
{

    class ProductsControllerTest
    {
        #region TestSetup
        //Instance of Model
        public static ProductsController pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ProductsController(TestHelper.ProductService) {};
        }

        #endregion TestSetup

        #region Get

        [Test]
        public void Get_Valid_Should_Return_Products()
        {
            pageModel.Get();

            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        [Test]
        public void GetFoodData_Valid_Should_Return_Food()
        {
            pageModel.GetFoodData();
            
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        #endregion Get

        #region Patch

        [Test]
        public void Patch_Valid_Rating_Patch_Should_Return_Ok()
        {
            var request = new ProductsController.RatingRequest();
            request.ProductId = "kamonegi";
            request.Rating = 5;

            pageModel.Patch(request);

            Assert.AreEqual(true, pageModel.ModelState.IsValid);

        }

        #endregion Patch

    }

}