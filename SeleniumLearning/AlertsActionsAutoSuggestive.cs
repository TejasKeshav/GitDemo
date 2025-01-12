using OpenDialogWindowHandler;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;
using AngleSharp.Dom;

namespace SeleniumLearning
{
    internal class AlertsActionsAutoSuggestive
    {
        IWebDriver driver;
        [SetUp]
        public void setUp()
        {
            new WebDriverManager.DriverConfigs.Impl.FirefoxConfig();
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            // driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            driver.Url = "https://www.google.com/imghp?hl=en&tab=ri&authuser=0&ogbl";
        }



        [Test]
        public void frames()
        {
            IWebElement frameScroll = driver.FindElement(By.Id("courses-iframe"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", frameScroll);
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.LinkText("All Access Plan")).Click();
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
            driver.SwitchTo().DefaultContent();
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
        }
        [Test]
        public void AutoSuggest()
        {
            String name = "Rahul";
            driver.FindElement(By.CssSelector("#name")).SendKeys(name);
            driver.FindElement(By.CssSelector("#confirmbtn")).Click();
            String alertText=driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            // driver.SwitchTo().Alert().Dismiss();
            //driver.SwitchTo().Alert().SendKeys("OK");
            StringAssert.Contains(name,alertText);
        }

        [Test]
        public void test_AutoSuggestiveDropDowns() 
        {
            driver.FindElement(By.Id("autocomplete")).SendKeys("ind");
            IList<IWebElement> options=driver.FindElements(By.XPath("//ul[@id='ui-id-1']/li"));
            foreach (IWebElement option in options)
            {
                if (option.Text.Equals("India"))
                     { 
                option.Click();
                }
            }
            TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));
        }
        [Test]
        public void test_Actions()
        {
            driver.Url = "https://rahulshettyacademy.com/#/index/";
            Actions a = new Actions(driver);
            //mouse events
            a.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
            //driver.FindElement(By.XPath("//ul[@class=''dropdown-menu]/li[1]/a")).Click();
            a.MoveToElement(driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a"))).Click().Perform();
driver.Url = "https://demoqa.com/droppable";
            a.DragAndDrop(driver.FindElement(By.Id("draggable")), driver.FindElement(By.Id("droppable"))).Perform();
            a.SendKeys("").Perform();
            a.ClickAndHold().Perform();
            a.Click().Perform();
            a.ContextClick(element).Perform();
            a.DoubleClick().Perform(); 
            a.MoveByOffset(0, 0).Perform();
            a.Release(element).Perform()

            //Keyboard events
            a.KeyUp(driver.FindElement(By.XPath("//a[@hre='hgf']")),Keys.ArrowUp).Perform();
            a.KeyDown(driver.FindElement(By.XPath("//a[@hre='hgf']")), Keys.Enter).Perform();
            //Convert text entered to upper case
            a.KeyDown(driver.FindElement(By.XPath("//a[@hre='hgf']")), Keys.Shift).SendKeys("automation tech guru").Build().Perform();

              
        
        }

        [Test]
        public void Copy_Paste()
        {
            driver.Url = "https://www.facebook.com/";
           IWebElement ele= driver.FindElement(By.Id("email"));
            Actions a = new Actions(driver);
            a.SendKeys(ele, "Selenium").Perform();
            a.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Build().Perform();
            a.KeyDown(Keys.Control).SendKeys("c").KeyUp(Keys.Control).Build().Perform();
            driver.FindElement(By.Id("pass")).Click();
            a.KeyDown(Keys.Control).SendKeys("v").KeyUp(Keys.Control).Build().Perform();
        }
        [Test]
        public void Refresh_page()
        {
            driver.Url = "https://www.facebook.com/";
            Thread.Sleep(1000);
            Actions a=new Actions(driver);
            a.KeyDown(Keys.Control).SendKeys("F5").Build().Perform();
        }

        [Test]
        public void Flash_Element()
        {
            driver.Url = "https://www.facebook.com/";
            IWebElement element=driver.FindElement(By.Name("login"));
            JavaScriptUtil.FlashElement( element, driver);

            //Change the color of button
            JavaScriptUtil.ChangeColorOfButton("yellow", element,driver);

            //Draw  a border for element
            JavaScriptUtil.DrawBorderOfElement("3px solid red",element, driver);

            //Generate Alert
            JavaScriptUtil.GenerateAlert(driver);

            //Click on element by JavascriptExecutor
            JavaScriptUtil.ElementCLickByJSE(driver.FindElement(By.Name("login")), driver);

            JavaScriptUtil.RefreshByJSE(driver);

         Console.WriteLine( JavaScriptUtil.GetTitleByJSE(driver));

            //ScrollIntoView
            JavaScriptUtil.ScrollIntoView(driver, element);

            //ScrollTillEnd
            JavaScriptUtil.ScrollTillEnd(driver);

            //ScrollHorizontal
            JavaScriptUtil.ScrollHorizontal(driver, element);

        }
        [Test]

        public void UploadImage()
        {
            //driver = new ChromeDriver();
            //driver.Url = "https://www.google.com/imghp?hl=en&tab=ri&authuser=0&ogbl";
            driver.FindElement(By.CssSelector("svg.Gdd5U")).Click();
            driver.FindElement(By.XPath("//span[@jsaction='D0HE7']")).Click();
            // driver.FindElement(By.CssSelector(".cB9M7")).SendKeys("C:\\Users\\0615C4744\\Downloads")
            
            //Using AutoIt to upload
            AutoItX3 autoit = new AutoItX3();
            autoit.WinActivate("File Upload");
            autoit.Send(ImageURL);
            autoit.Send("{ENTER}");
            ;
            //HandleDialog();

        }
        //public static void HandleDialog()
        //{ 
        //HandleOpenDialog hndOpen=new HandleOpenDialog();
        //    hndOpen.fileOpenDialog("C:\\Users\\0615C4744\\Downloads","Image");
        //}
        [Test]
        public void DownloadImage()
        {
            driver.FindElement(By.LinkText("anylink")).Click();
        
        }
       
    }
}
