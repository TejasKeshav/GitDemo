using OpenQA.Selenium;

namespace MsTestBase.PageModels
{
    public class NavigationPageModel : UIBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="NavigationPageModel"/>.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="webElement">The WebElement instance (optional).</param>
        public NavigationPageModel() : base()
        {
            _navElements = new Elements();
        }
        #endregion

        #region Elements
        private readonly Elements _navElements;
        public class Elements
        {
            public By txtUserName = By.Id("username");
            public By txtPassword = By.Id("password");
            public By btnUserType = By.Id("usertype");
            public By btnSignIn = By.CssSelector("input[value='Sign In']");
            public By txtNavBar = By.ClassName("navbar-brand");
        }
        #endregion

        #region TestSteps
        #region Definition
        #endregion

        #region Actions
        /// <summary>
        /// Fill user name field
        /// </summary>
        /// <param name="password"></param>
        public void FillPassword(string password)
        {
            driver.FindElement(_navElements.txtPassword).SendKeys(password);
        }

        /// <summary>
        /// Fill user name field
        /// </summary>
        /// <param name="userName"></param>
        public void FillUsername(string userName)
        {
            driver.FindElement(_navElements.txtUserName).SendKeys(userName);
        }

        /// <summary>
        /// Click on sign on button
        /// </summary>
        public void ClickSignOn()
        {
            driver.FindElement(_navElements.btnSignIn).Click();
        }
        #endregion

        #region Validations
        /// <summary>
        /// Verify nav bar message with expected value
        /// </summary>
        /// <param name="expectedText"></param>
        /// <returns>bool</returns>
        public bool VerifyNavBarMessage(string expectedText)
        {
            F1WaitForElementDisplayed(_navElements.txtNavBar, TimeSpan.FromSeconds(2));
            string navBarMsg = F1GetText(_navElements.txtNavBar);
            return expectedText.Contains(navBarMsg);
        }
        #endregion

        #region NestedClass
        #endregion
        #endregion
    }
}

