using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenetaWebApp.UITests.Pages
{
    public class JobApplicationPage
    {
        private readonly RemoteWebDriver Browser;
        private const string PageUri = @"https://apply.workable.com/first-engineers";

        public JobApplicationPage(RemoteWebDriver browser) => Browser = browser;

        public bool IsAt()
        {
            WebDriverWait WaitForPageToLoad = new WebDriverWait(Browser, TimeSpan.FromSeconds(10));

            try
            {
                return WaitForPageToLoad.Until(b => b.Title.Contains(JobApplicationPageTestData.JobTitle));
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        private static class JobApplicationPageTestData
        {
            public const string JobTitle = "Test Automation Engineer";
        }
    }
}
