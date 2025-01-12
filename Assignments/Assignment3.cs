using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    internal class Assignment3
    {
        public IWebDriver driver;
        [SetUp]
        public void SetUpBrowser()
        {
            new WebDriverManager.DriverManager();
            driver = new ChromeDriver();
            driver.Url = "https://www.snapdeal.com";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Login()
        {
            Actions a = new Actions(driver);
            a.MoveToElement(driver.FindElement(By.CssSelector(".accountInner"))).Perform();
            a.ClickAndHold(driver.FindElement(By.CssSelector(".accountInner"))).Perform();
        
        }
    }
}
