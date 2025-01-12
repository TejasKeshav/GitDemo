using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Assignments
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            new WebDriverManager.DriverManager();
            driver = new FirefoxDriver();
            driver.Url = "https://www.edureka.co/";
            driver.Manage().Window.Maximize();

        }


        [Test]
        public void Test1()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//span[@data-button-name='Login']")).Click();
            driver.FindElement(By.Id("si_popup_email")).SendKeys("pavikesh1311@gmail.com");
            driver.FindElement(By.Id("si_popup_passwd")).SendKeys("Hetveek@20");
            driver.FindElement(By.XPath("//button[@class='clik_btn_log btn-block']")).Click();
            Thread.Sleep(5000);
            
            driver.FindElement(By.CssSelector("span.webinar-profile-name")).Click();
            
            driver.FindElement(By.XPath("//ul[@class='dropdown-menu user-menu dropdown-menu-right']/li[4]/a")).Click();
            driver.FindElement(By.ClassName("icon-pr-edit")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("wzrk-confirm")));
            driver.FindElement(By.Id("wzrk-confirm")).Click();
            driver.FindElement(By.Id("fullName")).Clear();
            driver.FindElement(By.Id("fullName")).SendKeys("Pavithra");

            /*driver.FindElement(By.XPath("//span[contains(text(),'Experience *')]")).Clear();
           IList<IWebElement> exp_years = driver.FindElements(By.XPath("//ul[@class='available-items']/li"));

            foreach (IWebElement exp_year in exp_years)
            {

            if (exp_year.Text.Equals("2-4years"))
            {
            exp_year.Click();
            }
            }
            */
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(By.XPath("//span[contains(text(),'Experience*')]")));
            
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(),'Industry*')]")));
            /*driver.FindElement(By.XPath("//span[contains(text(),'Industry*')]")).Click();
            IList<IWebElement> ind_types = driver.FindElements(By.XPath("//ul[@class='available-items']/li"));

            foreach (IWebElement ind_type in ind_types)
            {

                if (ind_type.Text.Equals("Auto"))
                {
                    ind_type.Click();
                }
            }*/
            driver.FindElement(By.Id("designation")).Clear();
            driver.FindElement(By.Id("designation")).SendKeys("SoftwareEngineer");

            driver.FindElement(By.XPath("//div[@class='form-group ed-form-group time-selection'][1]/div")).Click();
            IList<IWebElement> fromDates = driver.FindElements(By.XPath("//ul[@class='available-items']/li"));

            foreach (IWebElement fromDate in fromDates)
            {
                
                if (fromDate.Text.Equals("11:00 AM"))
                {
                    fromDate.Click();
                }
            }
            // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='form-group ed-form-group time-selection'][1]/div[2]")));
           // driver.FindElement(By.XPath("//div[@class='//div[@class='form-group ed-form-group time-selection'][1]/div[2]")).Click();
            driver.FindElement(By.CssSelector(".btn_save")).Click();
            Thread.Sleep(4000);
            String parentID = driver.CurrentWindowHandle;
            driver.FindElement(By.XPath("//a[contains(text(),'Blog')]")).Click();
            driver.SwitchTo().Window(parentID);
            driver.FindElement(By.CssSelector("span.user_name")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'Log Out')]")).Click();
            


        }
    }

}