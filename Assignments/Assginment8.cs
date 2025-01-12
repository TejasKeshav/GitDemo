using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    internal class Assginment8
    {
        public IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverConfigs.Impl.ChromeConfig();
            driver = new ChromeDriver();
            driver.Url = "https://www.godaddy.com";


        }
        [Test]
        public void pageTitle()

        {
            
            String expctecd_Title = "Domain Names, Websites, Hosting & Online Marketing Tools - GoDaddy IN";
            String expctecd_Url = "https://www.godaddy.com";
            driver.Manage().Window.Size = new System.Drawing.Size(480, 320);
            TestContext.Progress.WriteLine(driver.Manage().Window.Size);
            string actual_Title = driver.Title;
            Assert.That(actual_Title,Is.EqualTo(expctecd_Title) );
            String actual_Url=driver.Url;
            TestContext.Progress.WriteLine(actual_Url);
          
            Assert.That(actual_Url, Is.EqualTo(expctecd_Url));
            String page_Source=driver.PageSource;
            page_Source.Contains(expctecd_Url);
            TestContext.Progress.WriteLine(page_Source);
            Assert.That(page_Source.Contains(expctecd_Url),Is.True);
            driver.Close();
        }
        [TearDown]
        public void closeBrowser()
        {

            driver.Close();
        }
    }
}