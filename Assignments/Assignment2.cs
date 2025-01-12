using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace Assignments
{
    public class Assignment2
    {
        private IWebDriver driver;
        
        public  Assignment2()
        {
            String browserName = "Firefox";
            initBrowser(browserName);
            driver.Url = "https://www.ebay.com//";
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);



        }
            public void initBrowser(String browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    new WebDriverManager.DriverManager();
                    driver = new ChromeDriver();
                    break;
                case  "Firefox":
                    new WebDriverManager.DriverManager();
                    driver = new FirefoxDriver();
                    break;
                case  "Edge":
                    new WebDriverManager.DriverManager();
                    driver = new EdgeDriver();
                    break;
               
            }
        }
        [Test]
        public void products()
        {
            driver.FindElement(By.Id("gh-ac")).SendKeys("Apple watches");
            driver.FindElement(By.Id("gh-shop-a")).Click();
            driver.FindElement(By.XPath("//tbody/tr/td[1]/h3[2]/a")).Click();
        }
    }
}
