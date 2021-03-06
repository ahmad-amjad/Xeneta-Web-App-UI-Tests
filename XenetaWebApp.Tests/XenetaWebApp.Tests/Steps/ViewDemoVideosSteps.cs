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
    public class ViewDemoVideosSteps
    {
        private WebPages Pages;

        public ViewDemoVideosSteps(WebPages pages) => Pages = pages;

        [Given(@"I am on the Demo Page")]
        public void GivenIAmOnTheDemoPage()
        {
            Pages.DemoPage.NavigateTo();
            Pages.DemoPage.AcceptCookies();
        }

        [When(@"I click the Watch Videos button")]
        public void WhenIClickTheWatchVideosButton()
        {
            Pages.DemoPage.OpenDemoVideos();
        }

        [Then(@"I should be navigated to the demo videos page")]
        public void ThenIShouldBeNavigatedToTheDemoVideosPage()
        {
            Assert.IsTrue(Pages.DemoVideosPage.IsAt(), "User was not navigated to the Demo Videos page.");
        }
    }
}
