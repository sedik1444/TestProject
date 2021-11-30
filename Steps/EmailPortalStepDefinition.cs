using TechTalk.SpecFlow;
using TestProject.Entities;
using TestProject.Helpers;
using FluentAssertions;
using OpenQA.Selenium;


namespace TestProject.Steps
{
    [Binding]
    public class EmailPortalStepDefinition : TestBase
    {
        private UserCredentials UserCredentials => Variables.Config.UserCredentials;
        private URL URL => Variables.Config.URL;
        private RecipientAddress RecipientAddress => Variables.Config.RecipientAddress;

        public EmailPortalStepDefinition(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }        
        
        [Given(@"I am on MailRu -> ""(.*)""")]
        public void GivenIAmOnMailRuLoginPage(string page)
        {
            _webDriver.Url = page switch
            {
                "LoginPage" => URL.MailRu.LoginPageURL,
                _           => URL.MailRu.AccountPageURL
            };
        }
        
        [When(@"I login with right credentials")]
        public void WhenILoginWithRightCredentials()
        {
            LoginPage.InputUsername(UserCredentials.Username);
            LoginPage.ClickNextButton();
            LoginPage.InputPassword(UserCredentials.Password);
            LoginPage.ClickSignInButton();
        }

        [Given(@"I logged in personal account")]
        public void GivenILoggedInPersonalAccount()
        {
            GivenIAmOnMailRuLoginPage("LoginPage");
            WhenILoginWithRightCredentials();
        }
        
        [When(@"I send email with attachment")]
        public void WhenISendEmailWithAttachment()
        {
            AccountPage.OpenNewMessageTab();
            AccountPage.InputRecipientAddress(RecipientAddress.RecipientEmailAddress);
            AccountPage.AttachFileToTheMessage("TestFile");
            AccountPage.SendMessage();
        }

        [Then(@"info message that email is sent displayed")]
        public void ThenInfoMessageThatEmailIsSentDisplayed()
        {
            var i = AccountPage.IsMessageSent();
            AccountPage.IsMessageSent().Should().BeTrue($"Message is not sent, sent message status = {AccountPage.IsMessageSent()}");
        }

        [StepDefinition(@"I can cancel sending email")]
        public void CanCancelSendingEmail()
        {
            var s = AccountPage.IsMessageCancelable();
            AccountPage.IsMessageCancelable().Should().
                BeTrue($"Message should be cancelable after sending email," +
                       $"Cancel button status is {AccountPage.IsMessageCancelable()}");
        }
        
        [Then(@"I redirected to my personal account")]
        public void ThenIRedirectedToMyPersonalAccount()
        {
            var successLoginURL = URL.MailRu.AccountPageURL;

            AccountPage.IsLoggedIn().Should().BeTrue($"Actual login status is {AccountPage.IsLoggedIn()}");
           
            var redirectedURL = _webDriver.Url;

            redirectedURL.Should().StartWith(successLoginURL,$"{redirectedURL} should match {successLoginURL}");

        }
    }
} 


    