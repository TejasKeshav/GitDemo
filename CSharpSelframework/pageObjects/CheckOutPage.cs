using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.pageObjects
{
    public class CheckOutPage
    {
        private IWebDriver driver;
        public CheckOutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }
        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> chekOutCards;

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement chekOutButton;

      
        public IList<IWebElement> getCards()
        {
            return chekOutCards;       
         }
        public void chekOut()
        {
             chekOutButton.Click();
           
        }
    }
}
