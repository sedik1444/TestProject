using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestProject.Helpers
{
    public class Waiters
    {
        public static void WaitForSelectDropdown(IWebDriver driver, By element, int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.IgnoreExceptionTypes(typeof(Exception));
            wait.Until(ExpectedConditions. ElementExists(element));
        }
        
        public static void WaitForLoadingPage(IWebDriver driver, int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.IgnoreExceptionTypes(typeof(Exception));

            bool IsLoaded(IWebDriver _driver)
            {
                var title = driver.FindElement(By.XPath("//head/title"));
                return title.GetAttribute("baseURI").Contains("https://www.selenium.dev/");
            }
            
            
            wait.Until(IsLoaded);
        }
        
        public static void WaitForLoadingFinished(IWebDriver driver, int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.IgnoreExceptionTypes(typeof(Exception));
            
            bool IsFinished(IWebDriver driver1)
            {
                var spinner = driver.FindElement(By.CssSelector(".wt-spinner[data-buy-box-price-spinner]"));
                return spinner.GetAttribute("class").Contains("none");
            }

            wait.Until(IsFinished);
        }

        public static void WaitForLoadingDatePickerForm(IWebDriver driver, int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.IgnoreExceptionTypes(typeof(Exception));

            bool IsFormLoaded(IWebDriver _driver)
            {
                var formLocator = driver.FindElement(By.XPath("//div[@rel-title='Simple Date Picker']"));
                return formLocator.GetAttribute("style").Contains("block");
            }
            
            wait.Until(IsFormLoaded);
        }

        public static void WaitForLoadingProgressBarForm(IWebDriver driver, int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.IgnoreExceptionTypes(typeof(Exception));

            bool IsFormLoaded(IWebDriver _driver)
            {
                var formLocator = driver.FindElement(By.XPath("//div[@rel-title='Download Manager']"));
                return formLocator.GetAttribute("style").Contains("block");
            }
            
            wait.Until(IsFormLoaded);
        }
        
        public static void WaitForDownloadingFormDisplaying(IWebDriver driver, int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.IgnoreExceptionTypes(typeof(Exception));

            bool IsFileDownloaded(IWebDriver _driver)
            {
                var downloadingFormLocator = driver.FindElement(By.XPath("//div[@id='dialog']/.."));
                return downloadingFormLocator.GetAttribute("style").Contains("block");
            }
            
            wait.Until(IsFileDownloaded);
            
        }
     
        public static void WaitForDownloadingFile(IWebDriver driver, int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.IgnoreExceptionTypes(typeof(Exception));

            bool IsFileDownloaded(IWebDriver _driver)
            {
                var progressBarLocator = driver.FindElement(By.Id("progressbar"));
                return progressBarLocator.GetAttribute("ariaValueNow").Contains("100");
            }
            
            wait.Until(IsFileDownloaded);
            
        }

        public static void WaitForLoadingCalendarDialogue(IWebDriver driver, int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.IgnoreExceptionTypes(typeof(Exception));

            bool IsCalendarDisplaying(IWebDriver _driver)
            {
                var calendarDialogueLocator = driver.FindElement(By.Id("ui-datepicker-div"));
                return calendarDialogueLocator.GetAttribute("style").Contains("block");
            }
            
            wait.Until(IsCalendarDisplaying);
            
        }

    }
}

