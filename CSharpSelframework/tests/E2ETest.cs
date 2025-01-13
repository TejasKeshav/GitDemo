using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using CSharpSelFramework.pageObjects;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

namespace CSharpSelframework.tests
{
    [Parallelizable(ParallelScope.Children)]
    public class E2ETest : utilities.BaseClass
    {

        [Test,TestCaseSource(nameof(AddTestDataConfig)),Category("Smoke")]
        //[TestCase("rahulshettyacademy", "learning")]
        //[TestCase("rahulshetty", "learning")]

        // [TestCaseSource(nameof(AddTestDataConfig))]

        [Parallelizable(ParallelScope.All)]
        public void E2EFlow(String username, String password, string[] expectdProducts)
        {
            //string[] expectdProducts = { "iphone X", "Blackberry" };
            string[] actualProducts = new string[2];
            LoginPage loginPage = new LoginPage(getDriver());
            ProductsPage productsPage = loginPage.ValidLogin(username, password);
            productsPage.waitForPageDisplay();
            IList<IWebElement> products = productsPage.getCards();

            foreach (IWebElement product in products)
            {

                if (expectdProducts.Contains(product.FindElement(productsPage.getCardTitle()).Text))
                {
                    product.FindElement(productsPage.addToCartButton()).Click();

                }

            }
            CheckOutPage checkOutPage = productsPage.checkOut();

            IList<IWebElement> checkoutCards = checkOutPage.getCards();
            for (int i = 0; i < checkoutCards.Count; i++)
            {
                actualProducts[i] = checkoutCards[i].Text;
            }
            Assert.That(actualProducts, Is.EqualTo(expectdProducts));

            checkOutPage.chekOut();


            driver.Value.FindElement(By.Id("country")).SendKeys("Ind");

            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));

            driver.Value.FindElement(By.LinkText("India")).Click();
            driver.Value.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            driver.Value.FindElement(By.CssSelector("[value='Purchase']")).Click();
            string confirmText = driver.Value.FindElement(By.CssSelector(".alert-success")).Text;
            StringAssert.Contains("Success", confirmText);

            
        
        }
        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
          yield return  new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("username_wrong"), getDataParser().extractData("password_wrong"), getDataParser().extractDataArray("products"));

        }

    }
}