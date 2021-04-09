﻿using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;
using XenetaWebApp.UITests.Pages;

namespace XenetaWebApp.UITests.Steps
{
    [Binding]
    public class WebinarSignUpSteps
    {
        private WebPages Pages;

        public WebinarSignUpSteps(WebPages pages) => Pages = pages;

        [Given(@"I am on the webinar sign up screen")]
        public void GivenIAmOnTheWebinarSignUpScreen()
        {
            Pages.DemoPage.NavigateTo();
            Pages.DemoPage.AcceptCookies();
            Pages.DemoPage.OpenWebinarSignUpForm();
        }

        [When(@"I submit my webinar signup application")]
        public void WhenISubmitMyWebinarSignupApplication()
        {
            Pages.DemoPage.SignUpForWebinar();
        }

        [Then(@"I should be navigated to the webinar signup thank you page")]
        public void ThenIShouldBeNavigatedToTheWebinarSignupThankYouPage()
        {
            Assert.IsTrue(Pages.WebinarSignUpThankYouPage.IsAt());
        }
    }
}