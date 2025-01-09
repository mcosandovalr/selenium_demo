using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_base.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver) { 
            this.driver = driver; 
        }

        #region Protected methods
        protected void ClickElement(By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(by));

            element.Click();
        }

        protected void SendKeys(By by, string keys)
        {
            IWebElement element = driver.FindElement(by);
            element.Clear();
            element.SendKeys(keys);
        }

        protected IWebElement GetWebElement(By by)
        {
            return driver.FindElement(by);
        }

        protected IList<IWebElement> GetWebElements(By by)
        {
            return driver.FindElements(by);
        }
        #endregion Protected methods

        #region Verification/Assertion Methods
        protected bool IsDisplayed(By by)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
                return element.Displayed;
            }
            catch (Exception)
            {

                return false;
            }
        }

        protected void DoesContainsText(IList<IWebElement> elements, string text) 
        {
        }
        #endregion Verification/Assertion Methods
    }
}
