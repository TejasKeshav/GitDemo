using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    public class Assignment4
    {
       private IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverConfigs.Impl.ChromeConfig();
            driver = new ChromeDriver();
            driver.Url = "https://demo.automationtesting.in/Register.html";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
           
        }

        [Test]
        public void radiButton()
        {
            //driver.FindElement(By.XPath("//input[@placeholder='First Name']")).Clear();
            driver.FindElement(By.XPath("//input[@placeholder='First Name']")).SendKeys("name1");
            driver.FindElement(By.XPath("//input[@placeholder='Last Name']")).SendKeys("name2");
            driver.FindElement(By.CssSelector("[ng-model='Adress']")).SendKeys("Banglore");
            driver.FindElement(By.CssSelector("[ng-model='EmailAdress']")).SendKeys("abcd@gmail.com");
            driver.FindElement(By.CssSelector("[ng-model='Phone']")).SendKeys("9977667576");      
           IList<IWebElement> radios = driver.FindElements(By.CssSelector("[ng-model='radiovalue']"));
              foreach (IWebElement radio in radios)
            {
              if (radio.GetAttribute("value").Equals("FeMale"))
                {
                     radio.Click();
                }
            }

            IWebElement checkbox = driver.FindElement(By.Id("checkbox2"));
            if (checkbox.GetAttribute("value").Equals("Movies"))
            {
                Boolean check=checkbox.Selected;
                if (check != true)
                {
                  checkbox.Click();
                }

            }
            driver.FindElement(By.Id("msdd")).Click();
            IList<IWebElement> languages = driver.FindElements(By.XPath("//li[@class='ng-scope']"));
            foreach (IWebElement language in languages)
            {
                if (language.Text.Equals("Dutch"))  
                {
                    language.Click();
                }
            }

            IWebElement skills=driver.FindElement(By.Id("Skills"));
            SelectElement s=new SelectElement(skills);
            s.SelectByText("Android");
            driver.FindElement(By.CssSelector(".select2-selection")).Click() ;
            driver.FindElement(By.CssSelector("[type='search']")).SendKeys("Ind");
            

            IList<IWebElement> countries = driver.FindElements(By.XPath("//ul[@class='select2-results__options']/li"));
            foreach (IWebElement country in countries)
            {
                
                if (country.Text.Equals("India"))
                    
                {
                    
                    country.Click();
                    
                }
            }
            IWebElement years = driver.FindElement(By.Id("yearbox"));
            SelectElement s1 = new SelectElement(years);
            s1.SelectByText("2015");

            IWebElement months = driver.FindElement(By.CssSelector("[placeholder='Month']"));
            SelectElement s2 = new SelectElement(months);
            s2.SelectByText("June");

            IWebElement days = driver.FindElement(By.Id("daybox"));
            SelectElement s3 = new SelectElement(days);
            s3.SelectByText("5");
            driver.FindElement(By.Id("firstpassword")).SendKeys("testing");
            driver.FindElement(By.Id("secondpassword")).SendKeys("testing");
            driver.FindElement(By.Id("submitbtn")).Click();    
        }

    }
}
