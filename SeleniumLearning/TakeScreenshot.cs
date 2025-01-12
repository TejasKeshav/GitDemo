using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Net;
using System.IO;
using System.Drawing.Imaging;

namespace SeleniumLearning
{
    public class TakeScreenshot
    {
        IWebDriver driver;
        [Test]
        public void TakingScreenshot()
        {
            new WebDriverManager.DriverManager();
            driver = new FirefoxDriver();
            driver.Url = "https://www.facebook.com/";
            driver.Manage().Window.Maximize();
            
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            ts.GetScreenshot().SaveAsFile("Libraries\\Pictures\file", ScreenshotImageFormat.Png);
            //ts.GetScreenshot().SaveAsFile("Libraries\\Pictures\file.Bmp", ScreenshotImageFormat.Bmp);
            //ts.GetScreenshot().SaveAsFile("Libraries\\Pictures\file.JPeg", ScreenshotImageFormat.Jpeg);

       }

        [Test]
        public void ImageFormat(IWebDriver driver,String fileName,ScreenshotImageFormat format)
        {
            new WebDriverManager.DriverManager();
            driver = new FirefoxDriver();
            driver.Url = "https://www.facebook.com/";
            driver.Manage().Window.Maximize();
            ITakesScreenshot ts = (ITakesScreenshot)driver;
             
            ts.GetScreenshot().SaveAsFile("Libraries\\Pictures\file.jpg", ScreenshotImageFormat.Jpeg);
            ts.GetScreenshot().SaveAsFile("Libraries\\Pictures\file.png", ScreenshotImageFormat.Png);

        }
        [Test]
        public void TakeElementScreenshot()
        {

            driver.Url = "https://www.facebook.com";
            var element = driver.FindElement(By.XPath(""));
            getElementScreenshot(driver,element);


        }

            public void getElementScreenshot(IWebDriver driver,IWebElement element)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            byte[] byteArray=  ts.GetScreenshot().AsByteArray;
            Bitmap bitmap = new Bitmap(new  System.IO.MemoryStream(byteArray));
            
            // Get the Width and Height of the WebElement using
            int width = element.Size.Width;
            int height = element.Size.Height;

            

            // Get the Location of WebElement in a Point.
            // This will provide X & Y co-ordinates of the WebElement
           var xLocation = element.Location.X;
            var yLocation = element.Location.Y;

            // Create a rectangle using Width, Height and element location
           Rectangle rectImage = new Rectangle(xLocation, yLocation, width, height);

            bitmap.Clone(rectImage, bitmap.PixelFormat);
            bitmap.Save(string.Format("Libraries\\Pictures\element.jpg", ScreenshotImageFormat.Jpeg));
            bitmap.Dispose();
            
            

        }
    }
