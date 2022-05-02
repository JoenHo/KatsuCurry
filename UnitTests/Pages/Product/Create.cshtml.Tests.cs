using ContosoCrafts.WebSite.Pages.Product;
using NUnit.Framework;

namespace UnitTests.Pages.Product.Create
{
    class CreateTest
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

       





    }
}
