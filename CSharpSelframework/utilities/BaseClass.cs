using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CSharpSelFramework.utilities;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Configuration;

namespace CSharpSelframework.utilities
{
    public class BaseClass
    {
         String browserName;
        //public  IWebDriver driver;
      public ExtentReports extent;
        public ExtentTest test;
       
        public ThreadLocal<IWebDriver> driver=new ThreadLocal<IWebDriver>();
        [OneTimeSetUp]
        public void SetUp()
        {
            extent = new ExtentReports();
            String workingDirectory=Environment.CurrentDirectory;
           var projectDirectory= Directory.GetParent(workingDirectory).Parent.Parent.FullName;
           String reportPath= projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            

            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Username","Rahul");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("HostName", "Local host");
            extent.AddSystemInfo("Machine", Environment.MachineName);

        }
        
        [SetUp]
        public void StartBrowser()
        {
            test=extent.CreateTest(TestContext.CurrentContext.Test.Name);
            //Configutation
            browserName = TestContext.Parameters["browserName"];
            if (browserName==null) {
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            
            InitBrowser(browserName);
           
            driver.Value.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
             driver.Value.Manage().Window.Maximize();
        }

        public IWebDriver getDriver()
        {
            return driver.Value;
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager();
                    driver.Value = new FirefoxDriver();
                    break;

                case "chrome":
                    new WebDriverManager.DriverManager();
                    driver.Value = new ChromeDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager();
                    driver.Value = new EdgeDriver();
                    break;


            }
        }

        public  static JsonReader getDataParser()
        {

            return new JsonReader();
        }

       
        [TearDown]
        public void AfterTest()
        {
            var status=TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            DateTime time= DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            if (status == TestStatus.Failed)
            {
                test.Fail("Test failed", captureScreenshot(driver.Value, fileName));
                test.Log(Status.Fail, "test failed with logtrace " + stackTrace);
            }
            else if (status == TestStatus.Passed)
            { 
            
            }
            extent.Flush();
            driver.Value.Quit();
        }

        public MediaEntityModelProvider captureScreenshot(IWebDriver driver,String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
           var screenshot= ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();

        }
    }

    
}
