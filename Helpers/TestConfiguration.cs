using System;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace TestProject.Helpers
{
    [Binding]
    public sealed class TestConfiguration
    {
        private static IWebDriver _webDriver;
        private readonly IObjectContainer container;
        private static Actions _action;
        
   

        public TestConfiguration(IObjectContainer container)
        {
            this.container = container;
        }

            [BeforeFeature]
            public static void OneTime()
            {
                
                var options = new ChromeOptions();
                options.AddArgument("no-sandbox");
                options.AddArgument("--disable-popup-blocking");
                
                _webDriver = new ChromeDriver(options);
                _action = new Actions(_webDriver);
                
                _webDriver.Manage().Window.Maximize();
                _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
                _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(2000);

            }

            [BeforeScenario]
            public void SetUp()
            {
                container.RegisterInstanceAs<IWebDriver>(_webDriver);
            }

            [AfterScenario]
            public void TearDown()
            {
                
            }

            [AfterFeature]
            public static void FeatureTearDown()
            {
                if (_webDriver == null)
                    return;

                _webDriver.Quit();
                _webDriver = null;
            }
        }
}