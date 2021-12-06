using System;
using System.Globalization;
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
                "Main"           => URL.GlobalSQA.Default,
                _                => throw new ArgumentOutOfRangeException(nameof(page), page, null)
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

        [When(@"I switch to TESTER’S HUB -> ""(.*)"" page")]
        public void WhenISwitchToDemoTestingSite(string option)
        {
           GlobalSQAMainPage.OpenTestersHubMenu();
           GlobalSQAMainPage.OpenTestersHubDropdownLink(option);
        }
        
        [When(@"I switch to TESTER’S HUB -> ""(.*)"" -> ""(.*)"" submenu")]
        public void WhenISwitchToDemoSiteSubMenu(string submenu, string sub_submenu)
        {
            GlobalSQAMainPage.OpenTestersHubMenu();
            GlobalSQAMainPage.OpenSiteSubMenu(submenu, sub_submenu);
        }

        [StepDefinition("choose current day of the next month from calendar")]
        public void WhenIChooseDayFromCalendar()
        {
            var currentDay = DateTime.Today.Day;
            
            Waiters.WaitForLoadingDatePickerForm(_webDriver,10);
            
            _webDriver.SwitchTo().Frame(_webDriver.FindElement(By.XPath("//iframe[@class='demo-frame lazyloaded']")));
          
            GlobalSQADatePickerPage.OpenCalendar();
            Waiters.WaitForLoadingCalendarDialogue(_webDriver,10);

            GlobalSQADatePickerPage.ClickNextMonthButton();
            if (GlobalSQADatePickerPage.IsNextMonthValid())
            {
                GlobalSQADatePickerPage.SelectDayOfMonthFromCalendar(currentDay);
            }
        }

        [Then(@"date displaying in ""(.*)"" format")]
        public void ThenDateDisplayingInProperFormat(string format)
        {
            var selectedDate = GlobalSQADatePickerPage.GetSelectedDate();
            
            var isDateHaveExpectedFormat = DateTime.TryParseExact(selectedDate, format,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime _);
            
            isDateHaveExpectedFormat.Should().BeTrue($"{selectedDate} should have expected date format '{format}'");
        }

        [StepDefinition("start downloading the file")]
        public void StartDownloadingTheFile()
        {
            Waiters.WaitForLoadingProgressBarForm(_webDriver,10);
            _webDriver.SwitchTo().Frame(_webDriver.FindElement(By.XPath("//iframe[@class='demo-frame lazyloaded']")));
            
            GlobalSQAProgressBarPage.ClickDownloadFileButton();
            
            
        }

        [Then("file downloaded successfully")]
        public void FileDownloadedSuccessfully()
        {
            const string expectedProgress = "100";
            
            Waiters.WaitForDownloadingFormDisplaying(_webDriver, 10);
            Waiters.WaitForDownloadingFile(_webDriver, 10);
            GlobalSQAProgressBarPage.GetDownloadingProgress().Should().Be(expectedProgress,
                $"Actual downloading progress is {GlobalSQAProgressBarPage.GetDownloadingProgress()}");
        }

        [StepDefinition(@"downloading status is ""(.*)""")]
        public void DownloadingStatusIsCompleted(string status)
        {
            GlobalSQAProgressBarPage.GetDownloadingStatus().Should().Be(status,
                $"{GlobalSQAProgressBarPage.GetDownloadingStatus()} should be the same as expected downloading status {status}");
        }

        [Then(@"I see count of options in each column equal to ""(.*)""")]
        public void ValidAmountOfItemsDisplayed(int expectedItems)
        {
            expectedItems.Should().Be(GlobalSQATestersHubPage.GetFirstColumnItemsCount(),
                $"Expected count of options in first column {expectedItems} should be the same as actual {GlobalSQATestersHubPage.GetFirstColumnItemsCount()}");

            expectedItems.Should().Be(GlobalSQATestersHubPage.GetSecondColumnItemsCount(),
                $"Expected count of options in second column {expectedItems} should be the same as actual {GlobalSQATestersHubPage.GetSecondColumnItemsCount()}");

            expectedItems.Should().Be(GlobalSQATestersHubPage.GetThirdColumnItemsCount(),
                $"Expected count of options in third column {expectedItems} should be the same as actual {GlobalSQATestersHubPage.GetThirdColumnItemsCount()}");
        }
    }
}