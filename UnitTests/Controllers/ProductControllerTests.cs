using ContosoCrafts.WebSite.Controllers;
using System.Diagnostics;
using ContosoCrafts.WebSite.Pages;
using Microsoft.Extensions.Logging;
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

        #region OnGet

        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            pageModel.Get();
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        #endregion OnGet

    }

}