using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;
using TestProject.Entities;
using TestProject.Helpers;


namespace TestProject.Steps
{
    [Binding]
    public class GlobalSQAStepDefinition : TestBase
    {
        private URL URL => Variables.Config.URL;
        private ValidData ValidData => Variables.Config.ValidData;
      

        public GlobalSQAStepDefinition(IWebDriver webDriver, Actions action)
        {
            _webDriver = webDriver;
            _action = action;
        }        

        [Given(@"I am on GlobalSQA -> ""(.*)"" page")]
        public void GivenIAmOnPage(string page)
        {
            _webDriver.Url = page switch
            {
                "SamplePageTest" => URL.GlobalSQA.SamplePageTestURL,
                "DropDownMenu"   => URL.GlobalSQA.DropDownMenuPageURL,
                _                => URL.GlobalSQA.Default
            };
        }
        
        [When(@"I fill all required fields with valid data")]
        public void WhenIFillAllRequiredFieldsWithValidData()
        {
            GlobalSQASampleTestPage.AttachFile("TestFile");
            GlobalSQASampleTestPage.InputNameField(ValidData.Name);
            GlobalSQASampleTestPage.InputEmailField(ValidData.Email);
            GlobalSQASampleTestPage.SelectExperience(ValidData.Expirience);
            GlobalSQASampleTestPage.SelectExpertise(ValidData.Profession);
            GlobalSQASampleTestPage.SelectEducation(ValidData.Education);
            GlobalSQASampleTestPage.InputCommentField(ValidData.Comment);
        }

        [StepDefinition(@"I submit test form")]
        public void WhenISubmitTestForm()
        {
            GlobalSQASampleTestPage.SubmitMessage();
        }
        
        [Then(@"test message is sent and displayed information is correct")]
        public void InformationIsCorrect()
        {
            var expectedContent = 
                $"{ValidData.Name}{ValidData.Email}" +
                $"{ValidData.Expirience}{ValidData.Profession}" +
                $"{ValidData.Education}{ValidData.Comment}";
            
            var actualContent = GlobalSQASampleTestPage.GetContractFormContent();
            expectedContent = SomeHelper.Filter(expectedContent);
            actualContent = SomeHelper.Filter(actualContent);

            actualContent.Should().Contain(expectedContent,
                $"Actual information [{actualContent}] is not matched expected [{expectedContent}]");
        }

        [When(@"I open country dropdown")]
        public void WhenIOpenCountryDropdown()
        {
            GlobalSQAPageDropdownPage.OpenCountryDropdown();
        }

        [Then(@"I see valid amount of countries")]
        public void ValidAmountOfCountriesDisplayed()
        {
            var expectedCountryItems = 249;
            GlobalSQAPageDropdownPage.GetCountries().Count.Should().Be(expectedCountryItems);
        }
    }
}