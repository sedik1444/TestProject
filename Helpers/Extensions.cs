using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace TestProject.Helpers
{
    public static class Extensions
    {
       
        public  static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(x => x.FindElement(by));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + by + "' was not found in current context page.");
                throw;
            }
            
        }
        public  static IReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(Exception));
            var element = wait.Until(d => driver.FindElements(by));
            return element;

        }
        
        public static void SwitchToNewWindow(this IWebDriver driver, List<string> oldHandles)
        {
            var newPageHandles = driver.WindowHandles;

            foreach (var handle in newPageHandles)
            {
                if (!oldHandles.Contains(handle))
                {
                    driver.SwitchTo().Window(handle);
                }
            }
        }
        
        
    }

}
