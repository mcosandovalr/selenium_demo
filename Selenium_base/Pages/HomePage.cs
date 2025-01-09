using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_base.Pages
{
    public class HomePage:BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        #region Elements
        By txtSearchBox = By.Id("searchbox_input");
        By btnMagnifierGlass = By.XPath("//button[@aria-label='Search']");
        #endregion Elements

        #region Methods
        public void SearchFor(string search)
        { 
            SendKeys(txtSearchBox, search);
            ClickElement(btnMagnifierGlass);
        }
        #endregion Methods
    }
}
