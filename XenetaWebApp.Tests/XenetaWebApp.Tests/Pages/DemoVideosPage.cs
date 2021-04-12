using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenetaWebApp.Tests.Pages
{
    public class DemoVideosPage
    {
        private readonly RemoteWebDriver Browser;
        private const string PageUri = @"https://www.xeneta.com/watchdemos";
        private const string PageTitle = "Watch Xeneta Videos";

        public DemoVideosPage(RemoteWebDriver browser) => Browser = browser;

        public bool IsAt()
        {
            WebDriverWait WaitForPageToLoad = new WebDriverWait(Browser, TimeSpan.FromSeconds(10));

            try
            {
                return WaitForPageToLoad.Until(b => b.Title.Contains(PageTitle));
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
