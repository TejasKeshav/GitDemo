using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLearning
{
    internal class FunctionalTest
    {
        OpenQA.Selenium.IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            new WebDriverManager.DriverConfigs.Impl.FirefoxConfig();
           driver= new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
       
        }

        [Test]
        public void dropdown() 
        {
            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement s = new SelectElement(dropdown);
            s.SelectByText("Teacher");
            s.SelectByValue("consult");
           s.SelectByIndex(2);
            IList<IWebElement> radios=driver.FindElements(By.CssSelector("input[type='radio']"));

            foreach (IWebElement rad in radios) 
            {
                if (rad.GetAttribute("value").Equals("user"))
                { 
                    rad.Click();
                }
                
            }
            WebDriverWait wait=new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(ElementNotVisibleException);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")
                ));
            driver.FindElement(By.Id("okayBtn")).Click();
            Boolean result=driver.FindElement(By.Id("usertype")).Selected;
            Assert.IsTrue(result);
        }
    }

    
}
