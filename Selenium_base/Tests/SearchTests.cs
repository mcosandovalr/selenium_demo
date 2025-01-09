using Microsoft.Extensions.Configuration;
using Microsoft.Testing.Platform.Configurations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_base.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_base.Tests
{
    [TestClass]
    public class SearchTests
    {
        IWebDriver _driver;
        IConfigurationRoot _configuration;

        // pages
        HomePage homePage;
        ResultsPage resultsPage;

        [TestInitialize]
        public void Init() 
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("testsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            _driver = new ChromeDriver(options);

            _driver.Url = _configuration["url"];
            _driver.Navigate();

            // init pages
            homePage = new HomePage(_driver);

        }

        [TestCleanup]
        public void Cleanup() 
        { 
            _driver.Close();
            _driver.Quit();
        }

        [TestMethod]
        [DataRow("android")]
        [DataRow("apple")]
        public void SearchForWord_VerifyWordExists(string search_for) 
        {
            homePage.SearchFor(search_for);

            resultsPage = new ResultsPage(_driver);
            Assert.IsTrue(resultsPage.ContainsText(search_for));

        }
    }
}
