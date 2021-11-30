using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;
using TestProject.Entities;
using TestProject.Helpers;


namespace TestProject.Steps
{
    [Binding]
    public sealed class GoogleSearchStepDefinition : TestBase
    {
        private URL URL => Variables.Config.URL;

        public GoogleSearchStepDefinition(IWebDriver driver, Actions action)
        {
            _webDriver = driver;
            _action = action;
        }

        [Given("I am on google search page")]
        public void GivenIAmOnGoogleSearchPage()
        {
            _webDriver.Url = URL.Google.GoogleSearchURL;
        }

        [StepDefinition(@"I click on Selenium link")]
        public void GivenIClickOnSeleniumLink()
        {
            GoogleSearchPage.OpenSeleniumPage();
        }

        [When(@"I search for ""(.*)"" site")]
        public void WhenISearchForSeleniumSite(string searchValue)
        {
            GoogleSearchPage.Search(searchValue);
        }

        [Then(@"i redirect to Selenium page")]
        public void ThenIRedirectToSeleniumPage()
        {
            GoogleSearchPage.GetCurrentURL().Should().BeEquivalentTo(URL.Selenium.SeleniumMainPageURL,
                $"After redirect '{URL.Google.GoogleSearchURL}' should changed to '{URL.Selenium.SeleniumMainPageURL}'");
        }

        [StepDefinition(@"redirected url is ""(.*)""")]
        public void VerifyRedirectedURL(string expectedURL)
        {

            var currentURL = GoogleSearchPage.GetCurrentURL();

            currentURL.Should().BeEquivalentTo(expectedURL,
                $"Actual redirected URL is '{currentURL}' should be the same as expected '{expectedURL}'");
        }
    }
}