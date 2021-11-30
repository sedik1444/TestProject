using System;
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

    }
}

