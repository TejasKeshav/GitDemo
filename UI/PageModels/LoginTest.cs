using MsTestBase.PageModels;
namespace MsTestBase.UI
{
    /// <summary>
    /// This is test class
    /// </summary>
    [TestClass]
    public class LoginTest : UIBase
    {
        private NavigationPageModel navigationPage;

        public LoginTest() : base()
        { 
        }

        /// <summary>
        /// Initializes code to run before start of test case
        /// </summary>
        [TestInitialize]
        public void TestInitialise()
        {
            navigationPage = new NavigationPageModel();
        }

        [DataTestMethod]
        [DataRow("rahulshettyacademy", "learning", "ProtoCommerce")]
        [TestCategory("DataDependent")]
        public void TestMethod1(string userName, string password, string expectedText)
        {
            navigationPage.FillUsername(userName);
            navigationPage.FillPassword(password);
            navigationPage.ClickSignOn();
            navigationPage.VerifyNavBarMessage(expectedText);
        }
    }

}

