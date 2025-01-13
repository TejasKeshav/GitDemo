using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    internal class Locators
    {
        IWebDriver driver;
        [SetUp] 
        public void SetUp() 
        {
           new  WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise";
           // driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(By.Id("SignInBtn")),"SighIn"));

        }

       

        [Test]
        public void LocatorsIdentification()
        {
           driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("rahulshetty");
            driver.FindElement(By.Id("password")).SendKeys("12345");
            driver.FindElement(By.Id("usertype")).Click();
            driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();
            String msg=driver.FindElement(By.ClassName("alert")).Text;
            TestContext.Progress.WriteLine(msg);


        }

    }

    
}
