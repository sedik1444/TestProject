using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TestProject.Helpers;

namespace TestProject.Pages.ETSY
{
    public class EtsyPage
    {
        private readonly IWebDriver _webDriver;
        private readonly Actions _action;


        public EtsyPage(IWebDriver webDriver, Actions action)
        {
            _webDriver = webDriver;
            _action = action;

        }

        #region Locators

        private static By ClothingAndShoesMenuItemLocator =>
            By.XPath("//a[@href='/c/clothing-and-shoes?ref=catnav-10923']/span[@role='menuitem']");

        private static By BootsCategoryLocator => By.Id("catnav-l4-10935");
        private static By SaleItemLocator => By.XPath("//div[@data-search-results]//li[not(@style)]");

        private static By SaleItemWithDiscountLocator =>
            By.XPath("//div[@data-search-results]//li[not(@style)]//p//span[@class='wt-text-strikethrough']");

        private static By DropdownsLocator => By.CssSelector("#variations *>select");

        private static By AddItemButtonLocator =>
            By.XPath("//button[@type='submit']/div[contains(text(),'Add to cart')]");
        
        #endregion

        #region WebElements

        private IWebElement ClothingAndShoesMenuItem => _webDriver.FindElement(ClothingAndShoesMenuItemLocator, 10);
        private IWebElement AddItemButton => _webDriver.FindElement(AddItemButtonLocator, 10);
        private IReadOnlyCollection<IWebElement> ItemConfigurationsList => _webDriver.FindElements(DropdownsLocator, 10);
        private IWebElement BootsCategory => _webDriver.FindElement(BootsCategoryLocator, 10);
        
        private IReadOnlyCollection<IWebElement> SaleItemsList => _webDriver.FindElements(SaleItemLocator);

        private IReadOnlyCollection<IWebElement> SaleItemsWithDiscountList =>
            _webDriver.FindElements(SaleItemWithDiscountLocator);

        #endregion

        #region Actions

        public IReadOnlyCollection<IWebElement> GetSaleItemsOnPage() => SaleItemsList;
        public IReadOnlyCollection<IWebElement> GetSaleItemsWithDiscountOnPage() => SaleItemsWithDiscountList;

        public void OpenItemOnPage(int itemNumber)
        {
            if (itemNumber < SaleItemsList.Count)
            {
                var oldHandles = _webDriver.WindowHandles.ToList();
                SaleItemsList.ElementAt(itemNumber).Click();
                _webDriver.SwitchToNewWindow(oldHandles);
            }
            else
            {
                throw new ArgumentOutOfRangeException($"No such items on page");
            }
            
        }

        public string GetPriceOfFirstItemInSearch() => SaleItemsList.First().GetAttribute("outerText");

        public void SelectItemConfiguration()
        {
            
            switch (ItemConfigurationsList.Count)
            {
                case 1:
                    SelectDropDownValue(ItemConfigurationsList.ElementAt(0));
                    break;
                case 2:
                    SelectDropDownValue(ItemConfigurationsList.ElementAt(0));
                    Waiters.WaitForLoadingFinished(_webDriver, 5);
                    SelectDropDownValue(ItemConfigurationsList.ElementAt(1));
                    break;
                case 3:
                    SelectDropDownValue(ItemConfigurationsList.ElementAt(0));
                    Waiters.WaitForLoadingFinished(_webDriver, 5);
                    SelectDropDownValue(ItemConfigurationsList.ElementAt(1));
                    Waiters.WaitForLoadingFinished(_webDriver, 5);
                    SelectDropDownValue(ItemConfigurationsList.ElementAt(2));
                    Waiters.WaitForLoadingFinished(_webDriver, 5);
                    break;
                default:
                    return;
            }
        }

        public void AddItemToCart()
        {
            Waiters.WaitForLoadingFinished(_webDriver, 6);
            AddItemButton.Click();

        }

        public void MoveToClothingAndShoesMenu()
        {
            _action.MoveToElement(ClothingAndShoesMenuItem).Perform();
        }

        public void MoveToBootsCategory()
        {
            _action.MoveToElement(BootsCategory).Click().Perform();
        }
        
        public void SelectDropDownValue(IWebElement element)
        {
            var select = new SelectElement(element);
            select.Options.Last().Click();

        }
         
        #endregion
    }
}
        
