using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;
using XenetaWebApp.UITests.Pages;

namespace XenetaWebApp.UITests.Hooks
{
    [Binding]
    public sealed class WebDriverHooks
    {
        private readonly IObjectContainer Container;
        private RemoteWebDriver Driver;
        private WebPages Pages;
        public WebDriverHooks(IObjectContainer container)
        {
            Container = container;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            string ChromeDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            ChromeOptions Options = new ChromeOptions();
            Options.AddArguments("--start-maximized");
            Driver = new ChromeDriver(ChromeDriverPath, Options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Container.RegisterInstanceAs(Driver);
            Pages = new WebPages(Driver);
            Container.RegisterInstanceAs(Pages);
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            var driver = Container.Resolve<RemoteWebDriver>();

            if (driver != null)
            {
                driver.Dispose();
            }
        }
    }
}
