using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using XenetaWebApp.UITests.Pages;

namespace XenetaWebApp.UITests.Steps
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

        [When(@"I click on the title a job")]
        public void WhenIClickOnTheTitleAJob()
        {
            Pages.CareersPage.OpenJobDescription();
        }

        [Then(@"Details of the job should be displayed")]
        public void ThenDetailsOfTheJobShouldBeDisplayed()
        {
            Assert.IsTrue(Pages.CareersPage.IsJobDescriptionDisplayed());
        }

        [When(@"I click the link to apply for the job")]
        public void WhenIClickTheLinkToApplyForTheJob()
        {
            Pages.CareersPage.OpenJobApplication();
        }

        [Then(@"I should be navigated the jobs application page")]
        public void ThenIShouldBeNavigatedTheJobsApplicationPage()
        {
            Assert.IsTrue(Pages.JobApplicationPage.IsAt());
        }
    }
}
