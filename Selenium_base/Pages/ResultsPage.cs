using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_base.Pages
{
    public class ResultsPage:BasePage
    {
        public ResultsPage(IWebDriver driver):base(driver) { }

        #region Elements
        By lnkTitle = By.XPath("//li[@data-layout='organic']//a[@data-testid='result-title-a']/span");

        // region filter elements
        By btnRegionFilter = By.XPath("//a[@data-testid='region-filter-label']");
        By btnClearAllFilter = By.XPath("//div[@data-testid='dropdown-options']//div/a[text()='Clear All']");
        By ddlCountryRegion = By.XPath("//div[@data-testid='dropdown-options']//div[@class='BDI1KtNF8HUPBZ4Cw_nK']");
        #endregion Elements

        #region Public Methods
        public void ClearFilter()
        {
            ClickElement(btnRegionFilter);
        }

        public int RegionCount()
        { 
            var elements = GetWebElements(ddlCountryRegion);
            return elements.Count;
        }

        #endregion Public Methods

        #region Verification Methods
        public bool ContainsText(string text_to_find)
        { 
            IList<IWebElement> results_list = GetWebElements(lnkTitle);
            foreach (IWebElement result in results_list) 
            {
                if(!result.Text.Contains(text_to_find))
                {
                    string txt_err = String.Format("result: {0}" +
                        "\nDoes not contain the word {1}", result.Text, text_to_find);
                    throw new Exception(txt_err);
                }
            }
            return true;
        }
        #endregion Methods
    }
}
