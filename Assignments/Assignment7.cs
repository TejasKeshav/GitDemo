using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V112.SystemInfo;
using System.Drawing;

namespace Assignments
{
    internal class Assignment7
    {
        private IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverConfigs.Impl.ChromeConfig();
            driver = new ChromeDriver();
            driver.Url = "https://www.godaddy.com";
            

        }
        [Test]
        public void browserMaximize()

        {
            
            TestContext.WriteLine(driver.Manage().Window.Size);

            driver.Manage().Window.Size = new System.Drawing.Size(480,400);
            TestContext.Progress.WriteLine(driver.Manage().Window.Size);

            driver.Manage().Window.Maximize();
            TestContext.Progress.WriteLine(driver.Manage().Window.Size);
            
            
        }
        [TearDown]
        public void closeBrowser()
        {

            driver.Close();
        }


    }
}
