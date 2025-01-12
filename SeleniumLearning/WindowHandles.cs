using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLearning
{
    internal class WindowHandles
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverConfigs.Impl.FirefoxConfig();
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void windowHandles()
        {
            String email = "mentor@rahulshettyacademy.com";
           String parentWindowId= driver.CurrentWindowHandle;
            driver.FindElement(By.ClassName("blinkingText")).Click();
            Assert.That(driver.WindowHandles.Count, Is.EqualTo(2));
           // Assert.AreEqual(2,driver.WindowHandles.Count);
            String childWindowName=driver.WindowHandles[1];

            //Below expresssion Can also used to get the handle of 1st window
            String childWindowName2 = driver.WindowHandles.First();
            driver.SwitchTo().Window(childWindowName);
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);
                string text = driver.FindElement(By.CssSelector(".red")).Text;
            string[] splittedtext = text.Split("at");
           String[] trimmedString= splittedtext[1].Trim().Split(" ");
            Assert.That(trimmedString[0], Is.EqualTo(email));
           // Assert.AreEqual(email, trimmedString[0]);
            driver.SwitchTo().Window(parentWindowId);
            driver.FindElement(By.Id("username")).SendKeys(trimmedString[0]);

            driver.SwitchTo().NewWindow(WindowType.Window);
            driver.SwitchTo().NewWindow(WindowType.Tab);

        }
    }
}
