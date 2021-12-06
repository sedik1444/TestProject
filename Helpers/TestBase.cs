using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TestProject.Pages.ETSY;
using TestProject.Pages.GlobalSQA;
using TestProject.Pages.Google;
using TestProject.Pages.Mail.ru;

namespace TestProject.Helpers
{
    public class TestBase
    {
        protected static IWebDriver _webDriver;
        protected static Actions _action;
        protected static ChromeOptions _options;
        protected static LoginPage LoginPage => new LoginPage(_webDriver);
        protected static AccountPage AccountPage => new AccountPage(_webDriver);
        protected static GlobalSQAPageDropdownPage GlobalSQAPageDropdownPage => new GlobalSQAPageDropdownPage(_webDriver);
        protected static GlobalSQASampleTestPage GlobalSQASampleTestPage => new GlobalSQASampleTestPage(_webDriver, _options, _action);
        protected static EtsyPage EtsyPage => new EtsyPage(_webDriver, _action);
        protected static CartPage CartPage => new CartPage(_webDriver, _action);
        protected static GoogleMainPage GoogleSearchPage => new GoogleMainPage(_webDriver);
        protected static GlobalSQATestersHubPage GlobalSQATestersHubPage => new GlobalSQATestersHubPage(_webDriver);
        protected static GlobalSQAMainPage GlobalSQAMainPage => new GlobalSQAMainPage(_webDriver, _action);
        protected static GlobalSQADatePickerPage GlobalSQADatePickerPage => new GlobalSQADatePickerPage(_webDriver, _action);

        protected static GlobalSQAProgressBarPage GlobalSQAProgressBarPage =>
            new GlobalSQAProgressBarPage(_webDriver, _action);
    }
}
