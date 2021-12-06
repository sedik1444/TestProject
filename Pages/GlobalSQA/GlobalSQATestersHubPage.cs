using System.Collections.Generic;
using OpenQA.Selenium;


namespace TestProject.Pages.GlobalSQA
{
    public class GlobalSQATestersHubPage
    {
        private readonly IWebDriver _webDriver;

        public GlobalSQATestersHubPage (IWebDriver webDriver)
        {
            _webDriver = webDriver;
           
        }

        #region Locators

        private static By FirstColumnItemsLocator => By.XPath("//li[@class='price_column_title' and contains(text(),'First Step')]/following-sibling::li");
        private static By SecondColumnItemsLocator => By.XPath("//li[@class='price_column_title' and contains(text(),'Second Step')]/following-sibling::li");
        private static By ThirdColumnItemsLocator => By.XPath("//li[@class='price_column_title' and contains(text(),'Third Step')]/following-sibling::li");
        private static By LastColumnItemsLocator => By.XPath("//li[@class='price_column_title' and contains(text(),'Last Step')]/following-sibling::li");


        #endregion

        #region WebElements
        
        private IReadOnlyCollection<IWebElement> FirstColumnItemsList => _webDriver.FindElements(FirstColumnItemsLocator);
        private IReadOnlyCollection<IWebElement> SecondColumnItemsList => _webDriver.FindElements(SecondColumnItemsLocator);
        private IReadOnlyCollection<IWebElement> ThirdColumnItemsList => _webDriver.FindElements(ThirdColumnItemsLocator);
        private IReadOnlyCollection<IWebElement> LastColumnItemsList => _webDriver.FindElements(LastColumnItemsLocator);


        #endregion

        #region Actions

        public int GetFirstColumnItemsCount() => FirstColumnItemsList.Count;
        public int GetSecondColumnItemsCount() => SecondColumnItemsList.Count;
        public int GetThirdColumnItemsCount() => ThirdColumnItemsList.Count;
        public int GetLastColumnItemsCount() => LastColumnItemsList.Count;
        
        #endregion
    }
}