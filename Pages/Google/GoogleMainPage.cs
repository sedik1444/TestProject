using System;
using OpenQA.Selenium;
using TestProject.Helpers;

namespace TestProject.Pages.Google
{
    public class GoogleMainPage
    {
        private readonly IWebDriver _webDriver;
     

        public GoogleMainPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        #region Locators
        private static By SearchInputFieldLocator => By.XPath("//input[@type='text']");
        private static By LinkLocator(string linkURL) => By.XPath($"//a[@href={linkURL}]");
        private static By SeleniumLinkLocator => By.XPath("//cite[text()='https://www.selenium.dev']");
        private static By AcceptCookieButtonLocator => By.Id("L2AGLb");
        #endregion
        

        #region WebElements

        private IWebElement SearchInputField => _webDriver.FindElement(SearchInputFieldLocator);
        private IWebElement LinkItem(string linkURL) => _webDriver.FindElement(LinkLocator(linkURL));
        private IWebElement AcceptCookieButton => _webDriver.FindElement(AcceptCookieButtonLocator);
        private IWebElement SeleniumLink => _webDriver.FindElement(SeleniumLinkLocator);

        #endregion

        #region Actions
        
        public void Search(string value)
        {
            SearchInputField.SendKeys(value);
            SearchInputField.Submit();
        }
        
        public void OpenPageByLink(string linkURL)
        {
            LinkItem(linkURL).Click();
        }

        public void OpenSeleniumPage()
        {
            SeleniumLink.Click();
        }

        public string GetCurrentURL()
        {
            Waiters.WaitForLoadingPage(_webDriver,5);
            return _webDriver.Url;
        }
        
        #endregion

    }
}