using OpenQA.Selenium;
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
        protected static LoginPage LoginPage => new LoginPage(_webDriver);
        protected static AccountPage AccountPage => new AccountPage(_webDriver);
        protected static GlobalSQAPageDropdownPage GlobalSQAPageDropdownPage => new GlobalSQAPageDropdownPage(_webDriver);
        protected static GlobalSQASampleTestPage GlobalSQASampleTestPage => new GlobalSQASampleTestPage(_webDriver, _action);
        protected static EtsyPage EtsyPage => new EtsyPage(_webDriver, _action);
        protected static CartPage CartPage => new CartPage(_webDriver, _action);
        protected static GoogleMainPage GoogleSearchPage => new GoogleMainPage(_webDriver);


    }
}
