using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Microsoft.Extensions.Configuration;
using System.Text;
using UglyToad.PdfPig;
using SeleniumExtras.WaitHelpers;

namespace MsTestBase.PageModels
{
    public class UIBase : System.IDisposable
    {
        protected IConfiguration Configuration;

        protected int Timeout { get; private set; }
        public IWebDriver driver { get; private set; }
        public IWebElement element { get; private set; }
        readonly TimeSpan timeout = Config.DefaultTimeout;

        public UIBase()
        {
            try
            {
                // Fetch URL and Browser type from appsettings.json
                string url = ConfigurationHelper.GetSetting("Selenium:Maqs:WebSiteBase", "https://default-url.com") ?? throw new InvalidOperationException("BaseUrl is not configured in appsettings.json.");
                string browser = ConfigurationHelper.GetSetting("Selenium:Maqs:Browser", "Chrome");

                // Initialize WebDriver with proper options
                driver = browser.ToLower() switch
                {
                    "chrome" => new ChromeDriver(),
                    "firefox" => new FirefoxDriver(),
                    _ => throw new ArgumentException($"Unsupported browser: {browser}")
                };

                // Navigate to the specified URL
                if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    driver.Navigate().GoToUrl(url);
                }
                else
                {
                    throw new UriFormatException($"Invalid URL: {url}");
                }
            }
            catch (Exception ex)
            {
                // Log error and rethrow for further handling
                Console.Error.WriteLine($"Error initializing WebDriver: {ex.Message}");
                Dispose();
                throw;
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = timeout;
        }

        private void CaptureScreenshot(string directoryName, string fileNameWithoutExtension)
        {
            try
            {
                if (driver is ITakesScreenshot screenshotDriver)
                {
                    string directory = string.IsNullOrEmpty(directoryName)
                        ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots")
                        : directoryName;

                    Directory.CreateDirectory(directory);
                    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    string filePath = Path.Combine(directory, $"{fileNameWithoutExtension}_{timestamp}.png");

                    /*screenshotDriver.GetScreenshot().SaveAsFile(filePath, ScreenshotImageFormat.Png);
                    Console.WriteLine($"Screenshot saved: {filePath}");*/
                }
                else
                {
                    throw new NotSupportedException("Driver does not support screenshots.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
            }
        }

        public void F1AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void F1Clear(By byLocator)
        {
            driver.FindElement(byLocator).Clear();
        }

        public void F1Clear(IWebElement element)
        {
            element.Clear();
        }

        public void F1Click(By byLocator)
        {
            try
            {
                driver.FindElement(byLocator).Click();
            }
            catch (ElementNotVisibleException)
            {
                F1ScrollIntoView(byLocator);
                driver.FindElement(byLocator).Click();
            }

        }

        public bool F1ClickAndSendKeys(By element, string text)
        {
            try
            {
                F1Click(element);
                F1SendText(element, text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void F1DoubleClick(IWebElement element)
        {
            try
            {
                // Create an instance of Actions class
                Actions actions = new Actions(driver);

                // Perform the double-click action
                actions.MoveToElement(element).DoubleClick().Perform();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while performing double-click: {ex.Message}");
            }
        }

        public string F1GetAlertText()
        {
            return driver.SwitchTo().Alert().Text;
        }

        public string F1GetText(By locator)
        {
            return driver.FindElement(locator).Text;
        }

        public string F1GetTextFromPDF(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path cannot be null or empty.", nameof(path));
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The specified PDF file does not exist.", path);
            }

            var text = new StringBuilder();

            try
            {
                UI.PageModels.PdfDocument pdfDocument = UI.PageModels.PdfDocument.Open(path);
                for (int i = 0; i < pdfDocument.NumberOfPages; i++)
                {
                    var pageText = pdfDocument.GetPage(i)?.Text;
                    if (!string.IsNullOrEmpty(pageText))
                    {
                        text.AppendLine(pageText);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your application requirements
                Console.Error.WriteLine($"Error reading PDF: {ex.Message}");
                throw;
            }

            return text.ToString();
        }

        public string F1GetTextFromPDF(string path, int pageNumber)
        {
            using PdfDocument pdfDocument = PdfDocument.Open(path);
            return pdfDocument.GetPage(pageNumber).Text;
        }

        public IWebElement F1GetShadowElement(ISearchContext shadowRoot, By byCssSelector)
        {
            return shadowRoot.FindElement(byCssSelector);
        }

        public string F1GetUniqueString()
        {
            return Guid.NewGuid().ToString();
        }

        public bool F1Hover(By locator)
        {
            try
            {
                HoverOver(locator);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void F1ScrollIntoView(By byLocator)
        {
            throw new NotImplementedException();
        }

        public SelectElement F1SelectElement(By locator)
        {
            return new SelectElement(driver.FindElement(locator));
        }

        public void F1SelectiFrame(IWebElement element)
        {
            driver.SwitchTo().Frame(element);
        }

        public void F1SelectiFrame(int index)
        {
            driver.SwitchTo().Frame(index);
        }

        public void F1SelectiFrame(string name)
        {
            driver.SwitchTo().Frame(name);
        }

        public bool F1SendText(By byLocator, string text)
        {
            try
            {
                driver.FindElement(byLocator).Clear();
                driver.FindElement(byLocator).SendKeys(text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        private bool F1ScrollIntoView(IWebElement element)
        {
            try
            {
                ScrollIntoView(element);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void F1SwitchWindow(IWebDriver driver)
        {
            int count = driver.WindowHandles.Count();
            var currentWindowhandle = driver.CurrentWindowHandle;
            int num = driver.WindowHandles.ToList().FindIndex((string x) => x.Equals(currentWindowhandle));
            if (count > num + 1)
            {
                driver.SwitchTo().Window(driver.WindowHandles[num + 1]);
            }
            else
            {
                driver.SwitchTo().Window(driver.WindowHandles[0]);
            }
        }

        public void F1SwitchWindow(string tabTitle)
        {
            try
            {
                foreach (string windowHandle in driver.WindowHandles)
                {
                    driver.SwitchTo().Window(windowHandle);
                    if (driver.Title == tabTitle)
                    {
                        break;
                    }
                }
            }
            catch
            {
                throw new Exception("Cannot find with window " + tabTitle);
            }
        }

        public bool F1WaitForElementEnabled(By locator, TimeSpan sleep, bool refresh = false, int maxTimeOut = 0)
        {
            bool result = false;
            if (maxTimeOut == 0)
            {
                maxTimeOut = int.Parse(ConfigurationHelper.GetSetting("F1Config", "MaxTimeOutSeconds"));
            }
            try
            {
                if (IsElementPresent(locator))
                {
                    return result;
                }
                Thread.Sleep(sleep);
                if (refresh)
                {
                    driver.Navigate().Refresh();

                }
                return result;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void F1TakesScreenshot(string directoryName, string fileNameWithoutExtension, bool overrideConfig = false)
        {
            if (ConfigurationHelper.GetSetting("F1Config", "F1TakesScreenshoot").ToUpper().Trim() == "TRUE" || overrideConfig)
            {
                CaptureScreenshot(directoryName, fileNameWithoutExtension);
            }
        }

        public void F1WaitForPageLoad()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        }

        public void ForPageLoad()
        {
            if (!UntilPageLoad(driver))
            {
                throw new TimeoutException("Page load took longer than timrout configuration");
            }
        }

        public string GetPageTitleText()
        {
            return driver.Title.ToString();
        }

        public void HoverOver(By locator)
        {
            Actions actions = new Actions(driver);
            IWebElement element = driver.FindElement(locator);
            actions.MoveToElement(element).Perform();
        }

        public void ScrollIntoView(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public bool UntilPageLoad(IWebDriver driver)
        {
            try
            {
                // Use the default timeout from Config
                WebDriverWait wait = new WebDriverWait(driver, Config.DefaultTimeout);

                // Wait for the page to load
                return wait.Until(driver =>
                {
                    var jsExecutor = (IJavaScriptExecutor)driver;
                    string readyState = jsExecutor.ExecuteScript("return document.readyState").ToString();
                    return readyState == "complete";
                });
            }
            catch (WebDriverTimeoutException)
            {
                return false; // Timeout occurred
            }
        }

        public bool WaitUntilElementAbsent(By locator)
        {
            {
                try
                {
                    return !driver.FindElement(locator).Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true; // Element is absent
                }
            };
        }

        public static Func<IWebDriver, IWebElement> ElementIsVisible(IWebElement element)
        {
            return delegate
            {
                try
                {
                    return element.Displayed ? element : throw new Exception("element not found");

                }
                catch (Exception)
                {
                    return element;
                }
            };
        }

        public IWebElement F1WaitForElementDisplayed(By by, TimeSpan timeout)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver), "WebDriver instance cannot be null.");
            }

            if (by == null)
            {
                throw new ArgumentNullException(nameof(by), "Locator cannot be null.");
            }

            WebDriverWait wait = new WebDriverWait(driver, timeout);

            try
            {
                // Wait until the element is visible on the page
                return wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (WebDriverTimeoutException)
            {
                // Handle the exception when the element is not found or not visible within the timeout
                throw new NoSuchElementException($"Element with locator: {by} was not displayed within the timeout of {timeout.TotalSeconds} seconds.");
            }
        }

        public bool F1WaitUntilAbsent(By locator)
        {
            try
            {
                return WaitUntilElementAbsent(locator);
            }
            catch
            {
                return false;
            }
        }
        public bool F1WaitForVisibleElement(IWebElement element)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(1.0)).Until(ElementIsVisible(element));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetSeqTestOutCome(List<bool> assertLog)
        {
            if (assertLog.Contains(item: false))
            {
                return "FAILED";
            }
            return "PASSED";
        }

        public bool IsElementPresent(By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void PressKeyDown()
        {
            Actions act = new Actions(driver);
            act.SendKeys(Keys.Down).Perform();
        }

        public void PressKeyEnter()
        {
            Actions act = new Actions(driver);
            act.SendKeys(Keys.Enter).Perform();
        }

        public void PressKeyEscape()
        {
            Actions act = new Actions(driver);
            act.SendKeys(Keys.Escape).Perform();
        }

        public void RefreshBrowser()
        {
            driver.Navigate().Refresh();
        }

        public void SelectWindow()
        {
            F1SwitchWindow(driver);
        }

        public void URLToHome(TimeSpan timeOut, string seleniumMaqsSection = "WebSiteBase")
        {
            // Retrieve the URL from the configuration using the specified section
            string url = ConfigurationHelper.GetSetting($"Selenium:Maqs:{seleniumMaqsSection}", string.Empty);

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException($"URL not found in configuration for section: {seleniumMaqsSection}");
            }

            // Navigate to the URL
            driver.Navigate().GoToUrl(url);

            // Wait for the page to load completely
            WaitForPageLoad(driver, timeOut);
        }

        public void WaitForPageLoad(IWebDriver driver, TimeSpan timeout)
        {
            var wait = new WebDriverWait(new SystemClock(), driver, timeout, TimeSpan.FromMilliseconds(500));

            wait.Until(drv =>
            {
                try
                {
                    return (drv as IJavaScriptExecutor)?.ExecuteScript("return document.readyState").ToString() == "complete";
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public void WaitForURL(string expectedUrl)
        {
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.0);
                    if (driver.Url != expectedUrl)
                    {
                        Thread.Sleep(500);
                        continue;
                    }
                    break;
                }
                catch (Exception)
                {
                    break;
                }
            }
        }

        [TestCleanup]
        public void CleanBrowser()
        {

            driver.Quit();
        }

        public void Dispose()
        {
            driver?.Quit();
        }
    }
}

