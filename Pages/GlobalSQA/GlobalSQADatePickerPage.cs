using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestProject.Helpers;

namespace TestProject.Pages.GlobalSQA
{
    public class GlobalSQADatePickerPage
    {
        private readonly IWebDriver _webDriver;
        private readonly Actions _action;

        public GlobalSQADatePickerPage (IWebDriver webDriver, Actions action)
        {
            _webDriver = webDriver;
            _action = action;
        }

        #region Locators

        private static By DateInputFieldLocator => By.XPath("//input[@id='datepicker']");
        private static By NextMonthButtonLocator => By.XPath("//a[@class='ui-datepicker-next ui-corner-all' and @title='Next']");
        private static By MonthNameLocator => By.XPath("//span[@class='ui-datepicker-month']");
        private static By DayOfMonthLocator(int day) => By.XPath($"//td[@data-handler='selectDay']/a[text()='{day}']");


        #endregion

        #region WebElements

        private IWebElement DateInputField => _webDriver.FindElement(DateInputFieldLocator);
        private IWebElement NextMonthButton => _webDriver.FindElement(NextMonthButtonLocator);
        private IWebElement MonthNameInCalendar => _webDriver.FindElement(MonthNameLocator);
        private IWebElement DayOfMonth(int day) => _webDriver.FindElement(DayOfMonthLocator(day));


        #endregion

        #region Actions

        public void OpenCalendar() => DateInputField.Click();
        
        public void ClickNextMonthButton() => NextMonthButton.Click();
        
        public string GetSelectedMonthName() => MonthNameInCalendar.GetAttribute("textContent");
        
        public bool IsNextMonthValid() => Equals(DateTime.Now.AddMonths(+1).ToString("MMMM"), GetSelectedMonthName());
        
        public void SelectDayOfMonthFromCalendar(int currentDay) => DayOfMonth(currentDay).Click();

        public string GetSelectedDate() => DateInputField.GetAttribute("value");

        #endregion

    }
}