using OpenQA.Selenium;
using TestProject.Helpers;

namespace TestProject.Pages.Mail.ru
{
    public class LoginPage
    {
        
        private readonly IWebDriver _webDriver;
        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        #region Locators

        private static By InputUsernameLocator => By.XPath("//input[@name='username']");
        private static By InputPasswordLocator => By.XPath("//input[@name='password']");
        private static By SignInButtonLocator => By.XPath("//button[@data-test-id='submit-button']");
        private static By NextButtonLocator => By.XPath("//button[@data-test-id='next-button']");
       
        

        #endregion

        #region WebElements

        private IWebElement InputUserNameField => _webDriver.FindElement(InputUsernameLocator, 60);
        private IWebElement InputPasswordField => _webDriver.FindElement(InputPasswordLocator, 100);
        private IWebElement SignInButton => _webDriver.FindElement(SignInButtonLocator, 60);
        private IWebElement NextButton => _webDriver.FindElement(NextButtonLocator, 60);
        

        #endregion

        #region Actions

        public void ClickNextButton()
        {
            NextButton.Click();
        }

        public void ClickSignInButton()
        {
            SignInButton.Click();
        }

        public void InputUsername(string username)
        {
            InputUserNameField.SendKeys(username);
        }

        public void InputPassword(string password)
        {
            InputPasswordField.SendKeys(password);
        }
        
        #endregion
    }
}