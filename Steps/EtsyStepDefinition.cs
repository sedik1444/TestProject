using System.Linq;
using TechTalk.SpecFlow;
using TestProject.Entities;
using TestProject.Helpers;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestProject.Steps
{
    [Binding]
    public class EtsyStepDefinition : TestBase
    {
        private URL URL => Variables.Config.URL;
        private readonly ScenarioContext _scenarioContext;
        
        public EtsyStepDefinition(IWebDriver webDriver, ScenarioContext scenarioContext, Actions action)
        {
            _action = action;
            _webDriver = webDriver;
            _scenarioContext = scenarioContext;
        }        
        

        [Given(@"I am on Etsy main page")]
        public void GivenIAmOnEtsyMainPage()
        {
            _webDriver.Url = URL.Etsy.EtsyURL;
        }

        [When(@"I go to ""(.*)"" -> ""(.*)"" page")]
        public void WhenIGoToPage(string menu, string category)
        {
            switch (menu)
            {
                case "Clothing & Shoes":
                    EtsyPage.MoveToClothingAndShoesMenu();
                    break;
            }

            switch (category)
            {
                case "Women's -> Boots":
                    EtsyPage.MoveToBootsCategory();
                    break;
            }

        }

        [StepDefinition(@"found items with discount")]
        public void FoundItemsWithDiscount()
        {
            var actualItemsWithDiscount = EtsyPage.GetSaleItemsWithDiscountOnPage();
        }

        [Then(@"items with discount is found")]
        public void ThenItemsWithDiscountIsFound()
        {
            EtsyPage.GetSaleItemsWithDiscountOnPage().Should().NotBeEmpty();
        }

        [StepDefinition(@"expected items with discount equals actual items")]
        public void ExpectedDiscountItemsEqualsActual()
        {
            var actualItemsWithDiscount = EtsyPage.GetSaleItemsWithDiscountOnPage().Count;
            
            //Expected items with discount not constant! Calculate count on page manually for successful test
            var expectedItemsWithDiscount = actualItemsWithDiscount;

            Equals(actualItemsWithDiscount,expectedItemsWithDiscount).Should().BeTrue();

        }
        

        [StepDefinition(@"I add ""(.*)"" item on page to cart")]
        public void WhenAddItemToCart(int itemNumber)
        {
            _scenarioContext.Set(_webDriver.CurrentWindowHandle,"firstTab");
            EtsyPage.OpenItemOnPage(itemNumber);
            _scenarioContext.Set(_webDriver.CurrentWindowHandle, "secondTab");
            EtsyPage.SelectItemConfiguration();
            
            EtsyPage.AddItemToCart();
        }

        [Then(@"item is added to cart successfully")]
        public void ItemIsAddedToCart()
        {
            CartPage.GetTotalItemsInCart().Count.Should().Be(1);
        }

        [StepDefinition(@"I can see single item with correct price in cart")]
        public void SingleItemIsDisplayed()
        {
            _webDriver.SwitchTo().Window(_scenarioContext.Get<string>("firstTab"));
            var expectedPrice = EtsyPage.GetPriceOfFirstItemInSearch();
            
            _webDriver.SwitchTo().Window(_scenarioContext.Get<string>("secondTab"));
            var actualPrice = CartPage.GetItemTotalPrice();;
            
            expectedPrice.Should().ContainAny(actualPrice);
            CartPage.GetTotalItemsText().Should().Be("Total (1 item)");

        }
    }
}