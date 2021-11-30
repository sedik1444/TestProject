using System.Collections.Generic;
using OpenQA.Selenium;
using TestProject.Helpers;

namespace TestProject.Pages.GlobalSQA
{
    public class GlobalSQAPageDropdownPage
    { 
        private readonly IWebDriver _webDriver;

        public GlobalSQAPageDropdownPage (IWebDriver webDriver)
        {
            _webDriver = webDriver;
           
        }

        #region Locators

        private static By CountryDropdownLocator => By.XPath("//select");
        private static By CountryItemLocator => By.XPath("//select//option");

        #endregion

        #region WebElements

        private IWebElement CountryDropdown => _webDriver.FindElement(CountryDropdownLocator, 60);
        private IReadOnlyCollection<IWebElement> CountryList => _webDriver.FindElements(CountryItemLocator);


        #endregion

        #region Actions

        public void OpenCountryDropdown()
        {
            CountryDropdown.Click();
        }
        public IReadOnlyCollection<IWebElement> GetCountries() => CountryList;

        #endregion

    }
        
}
