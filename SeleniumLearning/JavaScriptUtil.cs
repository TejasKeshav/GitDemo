using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V111.DOM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLearning
{
    public static class JavaScriptUtil
    {
        public static void FlashElement(IWebElement element, IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            String BgColor = element.GetCssValue("background-color");
            for (int i=0;i<10;i++) {
                ChangeColorOfButton("#000000", element, driver);
                ChangeColorOfButton(BgColor, element, driver);
            }

        }
        public static void ChangeColorOfButton(String BgColor, IWebElement element, IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].style.background='" + BgColor + "'", element);
        }

        public static void DrawBorderOfElement(String border,IWebElement element,IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].style.border='" + border + "'", element);

        }

        public static void GenerateAlert(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("alert('Welcome')");
        }

        public static void ElementCLickByJSE(IWebElement element, IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }

        public static void RefreshByJSE( IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("history.go(0)");
        }

        public static String  GetTitleByJSE(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
           String Title= (string)js.ExecuteScript("document.title");
            return Title;
        }

        public static void ScrollIntoView(IWebDriver driver,IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView()",element);
        }

        public static void ScrollTillEnd(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollTo(0,document.body.scrollHeight)");

        }
        public static void ScrollHorizontal(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView()",element);

        }


    }
}
