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
    public class WebinarSignUpThankYouPage
    {
        private readonly RemoteWebDriver Browser;
        private const string PageUri = @"https://www.xeneta.com/xeneta-live-group-demo-thank-you-";
        private const string PageTitle = "Xeneta Live Group Demo Thank You";

        public WebinarSignUpThankYouPage(RemoteWebDriver browser) => Browser = browser;

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
