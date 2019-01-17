using TechTalk.SpecFlow;
using NUnit.Framework;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace com.edgewords.mandm.Steps
{
    [Binding]
    public class BasketSteps : Utilities.TestBase
    {
        private string baseURL = "https://www.mandmdirect.com/";
       
        [Given(@"that I am on the home page")]
        public void GivenThatIAmOnTheHomePage()
        {      
            driver.Navigate().GoToUrl(baseURL);
        }
        
        [When(@"I add an item to the basket")]
        public void WhenIAddAnItemToTheBasket()
        {
            //search for some boots!
            driver.FindElement(By.Id("mainSearchText")).Click();
            driver.FindElement(By.Id("mainSearchText")).Clear();
            driver.FindElement(By.Id("mainSearchText")).SendKeys("boots");
            driver.FindElement(By.Id("mainSearchText")).SendKeys(Keys.Enter);
            driver.FindElement(By.CssSelector("[for='productsalesgender_mens'] .GENDER")).Click();
            //wait for filter to be applied
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(drv => drv.FindElement(By.XPath("/html//div[@id='productlist']//ul[@class='nav nav-list']//span[.='Mens']")).Displayed);
            driver.FindElement(By.CssSelector("[for='sizemandm_uk204'] .SIZE")).Click();
            //wait for filter to be applied
            wait.Until(drv => drv.FindElement(By.XPath("/html//div[@id='productlist']//ul[@class='nav nav-list']//span[.='UK 4']")).Displayed);
            //select the boot size to buy
            driver.FindElement(By.XPath("/html//span[contains(.,'Select Size')]")).Click();
            driver.FindElement(By.LinkText("UK 4 Euro 36.7")).Click();
            driver.FindElement(By.LinkText("Buy")).Click();
        }
        
        [Then(@"it is displayed in the basket")]
        public void ThenItIsDisplayedInTheBasket()
        {
            //go to basket
            driver.FindElement(By.XPath("//div[@id='popup']//button[@class='btn goToBasket']")).Click();
            //capture number of items in basket and check it is one
            string myVal = driver.FindElement(By.XPath("/html//div[@id='viewBasket']//div[@class='siteBasket']//p[@class='text-right totalQuantity']")).Text;
            Assert.That(myVal == "1");
        }

        [When(@"I then remove it from the basket")]
        public void WhenIThenRemoveItFromTheBasket()
        {
            //go to basket
            driver.FindElement(By.XPath("//div[@id='popup']//button[@class='btn goToBasket']")).Click();
            //click the remove item button
            driver.FindElement(By.XPath("/html//div[@id='viewBasket']//div[@class='siteBasket']/div[@class='basketContent']/ul[1]/li//div[@class='container3']/p[@class='hideInMiniBasket']/img[@alt='Remove']")).Click();
            //capture number of items in basket
            //but wait for the checkout button to dissapear first:
            while (driver.FindElement(By.CssSelector(".pull-right.basketCheckoutBtn [data-bind]")).Displayed)
            {
                Thread.Sleep(1000);
            }
        }

        [Then(@"the basket is empty")]
        public void ThenTheBasketIsEmpty()
        {
            string strBasketCount = driver.FindElement(By.XPath("/html//div[@id='viewBasket']//div[@class='siteBasket']//p[@class='text-right totalQuantity']")).Text;
            Assert.That(strBasketCount == "0");
        }

    }
}
