using OpenQA.Selenium;
using TestProject.Helpers;

namespace TestProject.Pages.Mail.ru
{
    public class AccountPage
    {
        private readonly IWebDriver _webDriver;
        private readonly string TestFile = SomeHelper.GetAbsoluteFilePath("Files", "TestFile.jpg");
     

        public AccountPage (IWebDriver webDriver)
        {
            _webDriver = webDriver;
           
        }

        #region Locators
        private static By RecipientAddressInputLocator => By.XPath("//div//input[@tabindex='100']");
        private static By AttachFileButtonLocator => By.XPath("//input[@class='desktopInput--3cWPE']");
        private static By SendMessageButtonLocator => By.XPath("//span[@tabindex='570']");
        private static By NewMessageButtonLocator => By.XPath("//a[@href='/compose/']");
        private static By SentMessageInfoDialogueLocator => By.XPath("//a[text()='Message sent']");
        private static By CancelSendingButtonLocator => By.XPath("//span[@title='Cancel sending']");

        #endregion

        #region WebElements
        private IWebElement RecipientAddressInput => _webDriver.FindElement(RecipientAddressInputLocator, 60);
        private IWebElement AttachFileButton => _webDriver.FindElement(AttachFileButtonLocator, 60);
        private IWebElement NewMessageButton => _webDriver.FindElement(NewMessageButtonLocator, 30);
        private IWebElement SendMessageButton => _webDriver.FindElement(SendMessageButtonLocator, 60);
        private IWebElement SentMessageInfoDialogue => _webDriver.FindElement(SentMessageInfoDialogueLocator, 60);
        private IWebElement CancelSendingButton => _webDriver.FindElement(CancelSendingButtonLocator, 60);
        #endregion

        #region Actions
        public bool IsMessageCancelable() => CancelSendingButton.Enabled;
        
        public bool IsMessageSent() => SentMessageInfoDialogue.Displayed;
        
        public bool IsLoggedIn() => NewMessageButton.Enabled;

        public void InputRecipientAddress(string emailAddress)
        {
            RecipientAddressInput.SendKeys(emailAddress);
        }
        
        public void OpenNewMessageTab()
        {
            NewMessageButton.Click();
        }
        
        public void AttachFileToTheMessage(string importFilePath)
        {
            switch (importFilePath)
            {
                case "TestFile":
                    importFilePath = TestFile;
                    AttachFileButton.SendKeys(importFilePath);
                    break;
                default:
                    AttachFileButton.SendKeys(importFilePath);
                    break;
            }
        }

        public void SendMessage()
        {
            SendMessageButton.Click();
        }
        
        #endregion
        
        
    }
}