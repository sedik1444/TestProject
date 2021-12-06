using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace TestProject.Pages.GlobalSQA
{
    public class GlobalSQAMainPage
    {
        private readonly IWebDriver _webDriver;
        private readonly Actions _action;

        public GlobalSQAMainPage (IWebDriver webDriver, Actions action)
        {
            _webDriver = webDriver;
            _action = action;
        }

        #region Locators

        private static By TestersHubLinkLocator => By.XPath("//div[@id='menu']//a[@href='https://www.globalsqa.com/testers-hub/']");
        private static By DemoSiteLinkLocator => By.XPath("//li[@id='menu-item-2822']//a[@href='https://www.globalsqa.com/demo-site/']");
        private static By TestersHubOptionsLocator(string optionText) => By.XPath($"//li[@id='menu-item-2822']//span[contains(text(),'{optionText}')]");
        private static By DemoSiteSubMenuItemsLocator(string subMenuText) => By.XPath($"//div[@class='subsub_menu']//span[text()='{subMenuText}']");

        #endregion

        #region WebElements

        private IWebElement TestersHubLink => _webDriver.FindElement(TestersHubLinkLocator);
        private IWebElement DemoSiteLink => _webDriver.FindElement(DemoSiteLinkLocator);

        private IWebElement DemoSiteSubMenuLink(string subMenuText) => _webDriver.FindElement(DemoSiteSubMenuItemsLocator(subMenuText));
        private IWebElement TestersHubOptionsLink(string linkText) => _webDriver.FindElement(TestersHubOptionsLocator(linkText));

        #endregion

        #region Actions

        public void OpenTestersHubMenu() => _action.MoveToElement(TestersHubLink).Perform();
        public void OpenTestersHubDropdownLink(string label) => TestersHubOptionsLink(label).Click();
        public void OpenSiteSubMenu(string subMenuText, string sub_subMenuText)
        {
            _action.MoveToElement(TestersHubOptionsLink(subMenuText)).Perform();
            DemoSiteSubMenuLink(sub_subMenuText).Click();
        }

        #endregion


    }
}