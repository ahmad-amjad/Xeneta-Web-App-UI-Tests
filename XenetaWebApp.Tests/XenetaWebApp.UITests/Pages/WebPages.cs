using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenetaWebApp.UITests.Pages
{
    public class WebPages
    {
        private RemoteWebDriver Driver;
        private DemoPage DemoPageObject;
        private DemoVideosPage DemoVideosPageObject;
        private PrivacyPolicyPage PrivacyPolicyPageObject;
        private WebinarSignUpThankYouPage WebinarSignUpThankYouPageObject;
        private CareersPage CareersPageObject;
        private JobApplicationPage JobApplicationPageObject;

        public WebPages(RemoteWebDriver driver) => Driver = driver;

        public DemoPage DemoPage
        {
            get
            {
                if (DemoPageObject is null)
                {
                    DemoPageObject = new DemoPage(Driver);
                }
                return DemoPageObject;
            }
        }

        public DemoVideosPage DemoVideosPage
        {
            get
            {
                if (DemoVideosPageObject is null)
                {
                    DemoVideosPageObject = new DemoVideosPage(Driver);
                }
                return DemoVideosPageObject;
            }
        }

        public PrivacyPolicyPage PrivacyPolicyPage
        {
            get
            {
                if (PrivacyPolicyPageObject is null)
                {
                    PrivacyPolicyPageObject = new PrivacyPolicyPage(Driver);
                }
                return PrivacyPolicyPageObject;
            }
        }

        public WebinarSignUpThankYouPage WebinarSignUpThankYouPage
        {
            get
            {
                if (WebinarSignUpThankYouPageObject is null)
                {
                    WebinarSignUpThankYouPageObject = new WebinarSignUpThankYouPage(Driver);
                }
                return WebinarSignUpThankYouPageObject;
            }
        }

        public CareersPage CareersPage
        {
            get
            {
                if (CareersPageObject is null)
                {
                    CareersPageObject = new CareersPage(Driver);
                }
                return CareersPageObject;
            }
        }

        public JobApplicationPage JobApplicationPage
        {
            get
            {
                if (JobApplicationPageObject is null)
                {
                    JobApplicationPageObject = new JobApplicationPage(Driver);
                }
                return JobApplicationPageObject;
            }
        }
    }
}
