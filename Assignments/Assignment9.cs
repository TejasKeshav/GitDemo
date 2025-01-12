using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    internal class Assignment9
    {
        private IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverConfigs.Impl.ChromeConfig();
            driver = new ChromeDriver();
            driver.Url = "https://www.godaddy.com/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        [Test]
        public void menu_SubMenu()
        {
             String expected_Title = "GoDaddy Domain Search - Buy and Register Available Domain Names";
            driver.FindElement(By.Id("id-631b049a-e9c0-4d24-8710-c504745206dd")).Click();
            driver.FindElement(By.XPath("//li[@data-track-name='in_domains']/button")).Click();
            IWebElement menu1 = driver.FindElement(By.XPath("//li[@data-track-name='in_domains']/button"));
            menu1.FindElement(By.XPath("//span[@class='t184fzfo']")).Click();
            String actual_Title1 = driver.Title;
            TestContext.WriteLine(actual_Title1);
            //Assert.That(actual_Title1, Is.EqualTo(expected_Title));
            driver.FindElement(By.Id("bc92338a-8ea1-46e3-ab05-b27bff9d95af")).Click();

            driver.FindElement(By.Id("id-631b049a-e9c0-4d24-8710-c504745206dd")).Click();
            driver.FindElement(By.XPath("//li[@data-track-name='in_hosting']/button")).Click();
            IWebElement menu2 = driver.FindElement(By.XPath("//li[@data-track-name='in_hosting']/button"));
            menu2.FindElement(By.XPath("//span[@class='ly9402x']")).Click();
            String actual_Title2 = driver.Title;
            TestContext.WriteLine(actual_Title2);
            Assert.That(actual_Title2, Is.EqualTo(expected_Title));
            driver.FindElement(By.Id("bc92338a-8ea1-46e3-ab05-b27bff9d95af")).Click();
        }

        
    }
}