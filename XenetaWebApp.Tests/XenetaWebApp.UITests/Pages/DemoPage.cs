using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

namespace XenetaWebApp.UITests.Pages
{
    public class DemoPage
    {
        private readonly RemoteWebDriver Browser;
        private const string PageUri = @"https://www.xeneta.com/demo";
        private const string PageTitle = "Xeneta in Action";
        private const string DemoBookingConfirmationMessageTextPartOne = "Thank you for your interest in Xeneta!";
        private const string DemoBookingConfirmationMessageTextPartTwo = "and set your date and time on the calendar. Happy shipping!";

        public DemoPage(RemoteWebDriver browser) => Browser = browser;

        private IWebElement AcceptCookiesButton => Browser.FindElementById("hs-eu-confirmation-button");

        private IWebElement WatchVideosButton => Browser.FindElementByLinkText("WATCH VIDEOS");

        private IWebElement ScheduleNowButton => Browser.FindElementByXPath("//a[@class = 'popup-btn' and text()='Schedule Now']");

        private IWebElement SignUpHereButton => Browser.FindElementByXPath("//a[text()='Sign up here']");

        private IWebElement FirstNameTextBox => Browser.FindElementByCssSelector("div.current input[name='firstname']");

        private IWebElement LastNameTextBox => Browser.FindElementByCssSelector("div.current input[name='lastname']");

        private IWebElement CompanyNameTextBox => Browser.FindElementByCssSelector("div.current input[name='company']");

        private IWebElement BusinessEmailTextBox => Browser.FindElementByCssSelector("div.current input[name='email']");

        private IWebElement PhoneNumberTextBox => Browser.FindElementByCssSelector("div.current input[name='phone']");

        private IWebElement MeetingDateTextBox => Browser.FindElementByCssSelector("div.current input[name='calendar_date']");

        private IWebElement CurrentDateCalendarElement => Browser.FindElementByCssSelector("div.current .is-today button");

        private IWebElement MeetingTimeTextBox => Browser.FindElementByCssSelector("div.current input[name='time_for_meeting']");

        private IWebElement JobTitleTextBox => Browser.FindElementByCssSelector("div.current input[name='jobtitle']");

        private IWebElement CompanyTypeDropDown => Browser.FindElementByCssSelector("div.current select[name='type_of_prospect']");

        private IWebElement TeusShippedAnnuallyDropDown => Browser.FindElementByCssSelector("div.current select[name='shipper_bco_annual_ocean_teus_cloned_']");

        private IWebElement AnnualAirFreightRateDropDown => Browser.FindElementByCssSelector("div.current select[name='annual_air_freight_ton']");

        private IWebElement PrivacyPolicyLink => Browser.FindElementByCssSelector("div.current input[name='confirm_opt_in'] + span a");

        private IWebElement PrivacyPolicyConfirmationCheckBox => Browser.FindElementByCssSelector("div.current input[name='confirm_opt_in']");

        private IWebElement SubmitApplicationButton => Browser.FindElementByCssSelector("div.current input[type='submit']");

        private IWebElement PrivacyPolicyRequiredFieldValidationLabel => Browser.FindElementByXPath("//input[@name='confirm_opt_in']/../../../../..//label[@class='hs-error-msg']");

        private IWebElement DemoBookingConfirmationMessagePartOneElement => Browser.FindElementByXPath("//div[contains(@class, 'submitted-message')]/p[contains(text(), '" + DemoBookingConfirmationMessageTextPartOne + "')]");

        private IWebElement DemoBookingConfirmationMessagePartTwoElement => Browser.FindElementByXPath("//div[contains(@class, 'submitted-message')]//p[contains(text(), '" + DemoBookingConfirmationMessageTextPartTwo + "')]");

        public void NavigateTo()
        {
            Browser.Navigate().GoToUrl(PageUri);
        }

        public void AcceptCookies()
        {
            AcceptCookiesButton.Click();
        }

        public void OpenDemoScheduleForm()
        {
            ScheduleNowButton.Click();
        }

        public void OpenWebinarSignUpForm()
        {
            SignUpHereButton.Click();
        }

        public string FirstName
        {
            set
            {
                FirstNameTextBox.SendKeys(value);
            }
        }

        public string LastName
        {
            set
            {
                LastNameTextBox.SendKeys(value);
            }
        }

        public string CompanyName
        {
            set
            {
                CompanyNameTextBox.SendKeys(value);
            }
        }

        public string BusinessEmail
        {
            set
            {
                BusinessEmailTextBox.SendKeys(value);
            }
        }

        public string PhoneNumber
        {
            set
            {
                PhoneNumberTextBox.SendKeys(value);
            }
        }

        public string MeetingDate
        {
            set
            {
                MeetingDateTextBox.Click();
                if (value.Equals("today"))
                {
                    CurrentDateCalendarElement.Click();
                }
            }
        }

        public string MeetingTime
        {
            set
            {
                MeetingTimeTextBox.SendKeys(value);
            }
        }

        public string JobTitle
        {
            set
            {
                JobTitleTextBox.SendKeys(value);
            }
        }

        public string CompanyType
        {
            set
            {
                var companyTypeDropDown = new SelectElement(CompanyTypeDropDown);
                companyTypeDropDown.SelectByValue(value);
            }
        }

        public string TeusShippedAnnually
        {
            set
            {
                var teusShippedAnnuallyDropDown = new SelectElement(TeusShippedAnnuallyDropDown);
                teusShippedAnnuallyDropDown.SelectByValue(value);
            }
        }

        public string AnnualAirFreightRate
        {
            set
            {
                var annualAirFreightRateDropDown = new SelectElement(AnnualAirFreightRateDropDown);
                annualAirFreightRateDropDown.SelectByValue(value);
            }
        }

        public string PrivacyPolicyRequiredFieldValidationMessage => PrivacyPolicyRequiredFieldValidationLabel.Text;

        public string DemoBookingConfirmationMessage => DemoBookingConfirmationMessagePartOneElement.Text + ' ' + DemoBookingConfirmationMessagePartTwoElement.Text;

        public void SetTeusShippedAnnually(string companyType, string teusShippedAnnually)
        {
            if (companyType is "Shipper/BCO" || companyType is "Freight Forwarder")
            {
                TeusShippedAnnually = teusShippedAnnually;
            }
        }

        public void SetAnnualAirFreightRate(string companyType, string annualAirFreightRate)
        {
            if (companyType is "Shipper/BCO")
            {
                AnnualAirFreightRate = annualAirFreightRate;
            }
        }

        public void ViewPrivacyPolicy() => PrivacyPolicyLink.Click();

        public void AcceptPrivacyPolicy()
        {
            if (PrivacyPolicyConfirmationCheckBox.Selected is false)
            {
                PrivacyPolicyConfirmationCheckBox.Click();
            }
        }

        public void DontAcceptPrivacyPolicy()
        {
            if (PrivacyPolicyConfirmationCheckBox.Selected is true)
            {
                PrivacyPolicyConfirmationCheckBox.Click();
            }
        }

        public void ScheduleDemo() => SubmitApplicationButton.Click();

        public void SignUpForWebinar() => SubmitApplicationButton.Click();

        public void OpenDemoVideos() => WatchVideosButton.Click();
    }
}
