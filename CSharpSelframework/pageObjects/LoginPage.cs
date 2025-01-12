using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.pageObjects
{
    public  class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        
        }
        //Pageobject Factory

        [FindsBy(How = How.Id, Using = "username")]
       private IWebElement username;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement checkBox;

        [FindsBy(How=How.Id,Using = "password")]
        private IWebElement password;

        [FindsBy(How=How.CssSelector,Using = "input[value='Sign In']")]
        private IWebElement signInButton;

        public IWebElement getUserName()
        { 
        return username;
        }
        public IWebElement getUserPassword()
        {
            return password;
        }
        public IWebElement getCheckBox()
        {
            return checkBox;
        }

        public IWebElement getSignInButton()
        {
            return signInButton;
        }
     
        public ProductsPage ValidLogin(String user, String pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            checkBox.Click();
            signInButton.Click();
            return new ProductsPage(driver);

        }



    }
    
}
