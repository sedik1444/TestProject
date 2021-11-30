using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

using TestProject.Helpers;

namespace TestProject.Pages.ETSY
{
    public class CartPage
    {
        private readonly IWebDriver _webDriver;
        private readonly Actions _action;


        public CartPage(IWebDriver webDriver, Actions action)
        {
            _webDriver = webDriver;
            _action = action;

        }
        
        #region Locators
        
        private static By TotalPriceLocator =>
            By.XPath("//th[contains(text(),'Item(s) total')]/following-sibling::td/span[@class='money']");
        private static By TotalItemsLocator =>
            By.XPath("//div[@class='cart-payment-section ']//h1[contains(text(),'Total (1 item)')]");
        private static By ItemInCartLocator => By.XPath("//li/ul[@class='wt-list-unstyled']/li");

        #endregion

        #region WebElements

        private IReadOnlyCollection<IWebElement> ItemsInCartList => _webDriver.FindElements(ItemInCartLocator);
        private IWebElement TotalPrice => _webDriver.FindElement(TotalPriceLocator, 10);
        private IWebElement TotalItems => _webDriver.FindElement(TotalItemsLocator, 10);
        

        #endregion

        #region Actions
        
        public IReadOnlyCollection<IWebElement> GetTotalItemsInCart() => ItemsInCartList;
        public string GetTotalItemsText() => TotalItems.Text;
        public string GetItemTotalPrice() => TotalPrice.Text;

        #endregion

        
    }
}
        
    
