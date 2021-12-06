using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestProject.Pages.GlobalSQA
{
    public class GlobalSQAProgressBarPage
    {
        private readonly IWebDriver _webDriver;
        private readonly Actions _action;

        public GlobalSQAProgressBarPage (IWebDriver webDriver, Actions action)
        {
            _webDriver = webDriver;
            _action = action;
        }

        #region Locators

        private static By DownloadButtonLocator => By.Id("downloadButton");
        private static By DownloadingStatusLocator => By.XPath("//div[@id='dialog']/div[@class='progress-label']");
        private static By DownloadingProgressLocator => By.Id("progressbar");

        #endregion

        #region WebElements

        private IWebElement DownloadButton => _webDriver.FindElement(DownloadButtonLocator);
        private IWebElement DownloadingStatus => _webDriver.FindElement(DownloadingStatusLocator);
        private IWebElement DownloadingProgress => _webDriver.FindElement(DownloadingProgressLocator);

        #endregion

        #region Actions

        public void ClickDownloadFileButton() => DownloadButton.Click();
        public string GetDownloadingStatus() => DownloadingStatus.GetAttribute("textContent");
        public string GetDownloadingProgress() => DownloadingProgress.GetAttribute("ariaValueNow");

        #endregion

    }
}