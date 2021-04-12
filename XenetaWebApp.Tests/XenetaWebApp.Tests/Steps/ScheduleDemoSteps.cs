using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;
using XenetaWebApp.Tests.Pages;

namespace XenetaWebApp.Tests.Steps
{
    [Binding]
    public class ScheduleDemoSteps
    {
        private WebPages Pages;
        private ScenarioContext ScenarioContext;

        public ScheduleDemoSteps(WebPages pages, ScenarioContext scenarioContext)
        {
            Pages = pages;
            ScenarioContext = scenarioContext;
        }

        [Given(@"I am on the demo booking screen")]
        public void GivenIAmOnTheDemoBookingScreen()
        {
            Pages.DemoPage.NavigateTo();
            Pages.DemoPage.AcceptCookies();
            Pages.DemoPage.OpenDemoScheduleForm();
        }

        [Given(@"I enter a first name of '(.*)'")]
        public void GivenIEnterAFirstNameOf(string firstName)
        {
            Pages.DemoPage.FirstName = firstName;
        }

        [Given(@"I enter a last name of '(.*)'")]
        public void GivenIEnterALastNameOf(string lastName)
        {
            Pages.DemoPage.LastName = lastName;
        }

        [Given(@"I enter a company name of '(.*)'")]
        public void GivenIEnterACompanyNameOf(string companyName)
        {
            Pages.DemoPage.CompanyName = companyName;
        }

        [Given(@"I enter a business email of '(.*)'")]
        public void GivenIEnterABusinessEmailOf(string businessEmail)
        {
            Pages.DemoPage.BusinessEmail = businessEmail;
        }

        [Given(@"I enter a phone number '(.*)'")]
        public void GivenIEnterAPhoneNumber(string phoneNumber)
        {
            Pages.DemoPage.PhoneNumber = phoneNumber;
        }

        [Given(@"I set a meeting date for '(.*)'")]
        public void GivenISetAMeetingDateFor(string meetingDate)
        {
            Pages.DemoPage.MeetingDate = meetingDate;
        }

        [Given(@"I enter a meeting time of '(.*)'")]
        public void GivenIEnterAMeetingTimeOf(string meetingTime)
        {
            Pages.DemoPage.MeetingTime = meetingTime;
        }

        [Given(@"I enter a job title of '(.*)'")]
        public void GivenIEnterAJobTitleOf(string jobTitle)
        {
            Pages.DemoPage.JobTitle = jobTitle;
        }

        [Given(@"I select that the company is a '(.*)'")]
        public void GivenISelectThatTheCompanyIsA(string companyType)
        {
            Pages.DemoPage.CompanyType = companyType;
            ScenarioContext["CompanyType"] = companyType;
        }

        [Given(@"I select that the global number of TEUs shipped annually is '(.*)'")]
        public void GivenISelectThatTheGlobalNumberOfTEUsShippedAnnuallyIs(string teusShippedAnnually)
        {
            Pages.DemoPage.SetTeusShippedAnnually(ScenarioContext["CompanyType"].ToString(), teusShippedAnnually);
        }

        [Given(@"I select that the annual air freight ton is '(.*)'")]
        public void GivenISelectThatTheAnnualAirFreightTonIs(string annualAirFreightRate)
        {
            Pages.DemoPage.SetAnnualAirFreightRate(ScenarioContext["CompanyType"].ToString(), annualAirFreightRate);
        }

        [Given(@"I agree to the privacy policy of Xeneta")]
        public void GivenIAgreeToThePrivacyPolicyOfXeneta()
        {
            Pages.DemoPage.AcceptPrivacyPolicy();
        }

        [When(@"I submit my demo schedule application")]
        public void WhenISubmitMyDemoScheduleApplication()
        {
            Pages.DemoPage.ScheduleDemo();
        }

        [When(@"I click the privacy policy link")]
        public void WhenIClickThePrivacyPolicyLink()
        {
            Pages.DemoPage.ViewPrivacyPolicy();
        }

        [Then(@"I should see a thank you message confirming my booking for a demo")]
        public void ThenIShouldSeeAThankYouMessageConfirmingMyBookingForADemo()
        {
            Assert.AreEqual("Thank you for your interest in Xeneta!" +
                " Please check your inbox and set your date and time on the calendar." +
                " Happy shipping! ", Pages.DemoPage.DemoBookingConfirmationMessage, "Demo schedule confirmation message was not displayed.");
        }

        [Then(@"I should be navigated to the privacy policy page")]
        public void ThenIShouldBeNavigatedToThePrivacyPolicyPage()
        {
            Assert.IsTrue(Pages.PrivacyPolicyPage.IsAt(), "User was not navigated to the Privacy Policy page.");
        }

        [Given(@"I don't agree to the privacy policy of Xeneta")]
        public void GivenIDonTAgreeToThePrivacyPolicyOfXeneta()
        {
            Pages.DemoPage.DontAcceptPrivacyPolicy();
        }

        [Then(@"Application should not be submitted")]
        public void ThenApplicationShouldNotBeSubmitted()
        {
            Assert.AreEqual("Please complete this required field.", Pages.DemoPage.PrivacyPolicyRequiredFieldValidationMessage, "Application was not rejected.");
        }

    }
}
