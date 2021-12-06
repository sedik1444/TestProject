using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TestProject.Helpers;

namespace TestProject.Pages.GlobalSQA
{
    public class GlobalSQASampleTestPage
    { 
        private readonly IWebDriver _webDriver;
        private readonly Actions _action;
        private readonly ChromeOptions _options;

        private readonly string TestFile = SomeHelper.GetAbsoluteFilePath("Files", "TestFile.jpg");
        
        public GlobalSQASampleTestPage (IWebDriver webDriver, ChromeOptions options ,Actions action)
        {
            _webDriver = webDriver;
            _action = action;
            _options = options;


        }

        #region Locators

        private static By NameInputLocator => By.Id("g2599-name");
        private static By EmailInputLocator => By.Id("g2599-email");
        private static By ExperienceDropdownLocator => By.Id("g2599-experienceinyears");
        private static By ExpertiseCheckboxLocator(string label) => By.XPath($"//input[@type='checkbox' and @value='{label}']");
        private static By EducationRadioGroupLocator(string label) => By.XPath($"//input[@type='radio' and @value='{label}']");
        private static By CommentTextAreaLocator => By.Id("contact-form-comment-g2599-comment");
        private static By SubmitButtonLocator => By.XPath("//button[text()='Submit']");
        private static By AttachFileButtonLocator => By.XPath("//input[@type='file']");
        private static By SubmittedContractFormLocator => By.XPath("//blockquote[@class='contact-form-submission']");

        #endregion

        #region WebElements

        private IWebElement NameInput => _webDriver.FindElement(NameInputLocator, 60);
        private IWebElement EmailInput => _webDriver.FindElement(EmailInputLocator, 60);
        private IWebElement AttachFileButton=> _webDriver.FindElement(AttachFileButtonLocator, 60);
        private IWebElement SubmitButton => _webDriver.FindElement(SubmitButtonLocator, 60);
        private IWebElement CommentTextArea => _webDriver.FindElement(CommentTextAreaLocator, 60);
        private IWebElement ExperienceDropdown => _webDriver.FindElement(ExperienceDropdownLocator, 60);
        private IWebElement ExpertiseCheckbox(string label) => _webDriver.FindElement(ExpertiseCheckboxLocator(label), 60);
        private IWebElement EducationRadioGroup(string label) => _webDriver.FindElement(EducationRadioGroupLocator(label), 60);
        private IWebElement SubmittedContractForm => _webDriver.FindElement(SubmittedContractFormLocator, 60);
       


        #endregion

        #region Actions

        public void InputNameField(string name)
        {
            NameInput.SendKeys(name);
        }

        public void InputEmailField(string email)
        {
            EmailInput.SendKeys(email);
        }
        
        public void AttachFile(string importFilePath)
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

        public void SubmitMessage()
        {
            _action.MoveToElement(SubmitButton).Click().Perform();
        }

        public void InputCommentField(string text)
        {
            CommentTextArea.SendKeys(text);
        }

        public void SelectExperience(string value)
        {
            var experienceDropdown = new SelectElement(ExperienceDropdown);
            experienceDropdown.SelectByValue(value);
        }

        public void SelectExpertise(string value)
        {
            ExpertiseCheckbox(value).Click();
        }

        public void SelectEducation(string value)
        {
            _action.MoveToElement(EducationRadioGroup(value)).Click().Perform();
        }

        public string GetContractFormContent() => SubmittedContractForm.GetAttribute("textContent");
        
        #endregion

    }
        
}