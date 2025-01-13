using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLearning
{
    internal class SortWebTables
    {
       IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverConfigs.Impl.FirefoxConfig();
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }
        [Test]
        public void Sort()
        {
            ArrayList a=new ArrayList();
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByValue("20");

            //Step 1 Get all veggie  names into array list A
           IList<IWebElement> veggies= driver.FindElements(By.XPath("//tbody/tr/td[1]"));
            foreach (IWebElement veggie in veggies)
            {
               a.Add(veggie.Text);
            }
            TestContext.Progress.WriteLine("Before Sorting");
            foreach (String element  in a)
            { 
           TestContext.Progress.WriteLine(element);
            }
            //Step 2 Sort this ArrayList A
            TestContext.Progress.WriteLine("After Sorting");
            a.Sort();
            foreach (String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }
            //Step3 Go and click column
            driver.FindElement(By.XPath("//thead/tr/th[1]")).Click();

            //Step 4 get all veggie names into Arraylist B
            ArrayList b =new ArrayList();
            IList<IWebElement> sortedVeggies = driver.FindElements(By.XPath("//tbody/tr/td[1]"));
            foreach (IWebElement veggie in sortedVeggies)
            {
                b.Add(veggie.Text);
            }

            //Step5 check Arraylist A and B are equal
            Assert.That(b, Is.EqualTo(a));
            //Assert.AreEqual(a, b);
        }
    }
}
