using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    internal class SeleniumFirst
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser() 
        {
            // new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            //ChromeDriverManager.chromedriver().setup();
           //driver =new ChromeDriver();
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1() 
        {
            driver.Url ="https://rahulshettyacademy.com/#/index";
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);
            driver.Quit();
            driver.Close();

        }
    }
}
    