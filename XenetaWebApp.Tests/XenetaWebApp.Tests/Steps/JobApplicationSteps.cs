using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using XenetaWebApp.Tests.Pages;

namespace XenetaWebApp.Tests.Steps
{
    [Binding]
    public class JobApplicationSteps
    {
        private WebPages Pages;

        public JobApplicationSteps(WebPages pages) => Pages = pages;

        [Given(@"I am on the Careers page")]
        public void GivenIAmOnTheCareersPage()
        {
            Pages.CareersPage.NavigateTo();
            Pages.CareersPage.AcceptCookies();
        }

        [Given(@"I have opened the details of a job")]
        public void GivenIHaveOpenedTheDetailsOfAJob()
        {
            Pages.CareersPage.OpenJobDescription();
        }

        [When(@"I click on the title of a job")]
        public void WhenIClickOnTheTitleOfAJob()
        {
            Pages.CareersPage.OpenJobDescription();
        }

        [Then(@"Details of the job should be displayed")]
        public void ThenDetailsOfTheJobShouldBeDisplayed()
        {
            Assert.IsTrue(Pages.CareersPage.IsJobDescriptionDisplayed(), "Details of the job were not displayed.");
        }

        [When(@"I click the link to apply for the job")]
        public void WhenIClickTheLinkToApplyForTheJob()
        {
            Pages.CareersPage.OpenJobApplication();
        }

        [Then(@"I should be navigated to the job application page")]
        public void ThenIShouldBeNavigatedToTheJobApplicationPage()
        {
            Assert.IsTrue(Pages.JobApplicationPage.IsAt(), "User was not navigated to the Job Application page.");
        }
    }
}
