using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;

namespace Assignments
{
    internal class Assignment6
    {
        private IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
                 new WebDriverManager.DriverManager();

            driver = new FirefoxDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }
        [Test]
        public void autoSuggestive()
        {
            driver.FindElement(By.Id("APjFqb")).SendKeys("selenium tutorial techlistic");
            IList<IWebElement> suggestions_list = driver.FindElements(By.XPath(" //div[@class='OBMEnb']/ul/li"));
            foreach (IWebElement suggest in suggestions_list)
            {
                TestContext.WriteLine(suggest.Text);
                if (suggest.Text.Equals("selenium tutorial tutorialspoint"))
                {
                    suggest.Click();
                }
            }
           
        }
    }
}
