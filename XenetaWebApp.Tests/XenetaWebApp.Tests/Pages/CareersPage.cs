using NUnit.Framework;
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
    public class CareersPage
    {
        private readonly RemoteWebDriver Browser;
        private const string PageUri = @"https://www.xeneta.com/careers";

        public CareersPage(RemoteWebDriver browser) => Browser = browser;

        private IWebElement AcceptCookiesButton => Browser.FindElementById("hs-eu-confirmation-button");

        private IWebElement JobTitleHeading => Browser.FindElementByXPath("//div[@class='accordion']//h4[contains(text(), '" + CareersPageTestData.JobTitle + "')]");

        private IWebElement JobDetailsAccordion => Browser.FindElementByCssSelector(".expanded");

        private IWebElement AboutXenetaHeading => Browser.FindElementByXPath("//div[contains(@class, 'expanded')]//h4/span[text()='About Xeneta']");

        private IWebElement ResponsibilitiesHeading => Browser.FindElementByXPath("//div[contains(@class, 'expanded')]//h4/span[text()='What will you be doing']");

        private IWebElement ExperienceHeading => Browser.FindElementByXPath("//div[contains(@class, 'expanded')]//h4/span[text()='Who you are']");

        private IWebElement RequirementsHeading => Browser.FindElementByXPath("//div[contains(@class, 'expanded')]//h4/span[text()='Requirements']");

        private IWebElement OptionalExperienceHeading => Browser.FindElementByXPath("//div[contains(@class, 'expanded')]//h4/span[text()='Nice to have']");

        private IWebElement BenefitsHeading => Browser.FindElementByXPath("//div[contains(@class, 'expanded')]//h4/span[text()='What we offer']");

        private IWebElement ApplyLink => Browser.FindElementByCssSelector("div.expanded a");

        private IList<IWebElement> JobDetailsAccordionContent => Browser.FindElementsByCssSelector("div.expanded p");

        public void NavigateTo()
        {
            Browser.Navigate().GoToUrl(PageUri);
        }

        public void AcceptCookies()
        {
            AcceptCookiesButton.Click();
        }

        public void OpenJobDescription()
        {
            JobTitleHeading.Click();
        }

        public bool IsJobDescriptionDisplayed()
        {
            WebDriverWait WaitForAccordionToExpand = new WebDriverWait(Browser, TimeSpan.FromSeconds(5));

            try
            {
                WaitForAccordionToExpand.Until(b =>
                {
                    return JobDetailsAccordion.Displayed;
                });
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }

            bool isJobDesciptionDisplayed =
                IsJobDescriptionContentDisplayed(AboutXenetaHeading, CareersPageTestData.AboutUsDetails) &&
                IsJobDescriptionContentDisplayed(ResponsibilitiesHeading, CareersPageTestData.ResponsibilitiesDetails) &&
                IsJobDescriptionContentDisplayed(ExperienceHeading, CareersPageTestData.ExperienceDetails) &&
                IsJobDescriptionContentDisplayed(RequirementsHeading, CareersPageTestData.RequirementsDetails) &&
                IsJobDescriptionContentDisplayed(OptionalExperienceHeading, CareersPageTestData.OptionalExperienceDetails) &&
                IsJobDescriptionContentDisplayed(BenefitsHeading, CareersPageTestData.BenefitsDetails) &&
                IsJobDescriptionContentDisplayed(ApplyLink, CareersPageTestData.ApplicationInstructionsDetails);

            return isJobDesciptionDisplayed;
        }

        private bool IsJobDescriptionContentDisplayed(IWebElement jobDescriptionContentTitle, IList<string> jobDescriptionContentDetails)
        {
            if (jobDescriptionContentTitle.Displayed.Equals(false))
            {
                return false;
            }
            foreach (string paragraph in jobDescriptionContentDetails)
            {
                if (JobDetailsAccordionContent.Single(paragraphElement => paragraphElement.Text.Contains(paragraph)).Displayed.Equals(false))
                {
                    return false;
                }
            }
            return true;
        }

        public void OpenJobApplication()
        {
            ApplyLink.Click();
            WaitForNewTabToOpen();
            Browser.SwitchTo().Window(Browser.WindowHandles[1]);
        }

        private void WaitForNewTabToOpen()
        {
            WebDriverWait WaitForNewTabToOpen = new WebDriverWait(Browser, TimeSpan.FromSeconds(2));
            WaitForNewTabToOpen.Until(b => b.WindowHandles.Count.Equals(2));
        }

        private static class CareersPageTestData
        {
            public const string JobTitle = "Test Automation Engineer";
            public static IList<string> AboutUsDetails = new List<string> { AboutUsFirstParagraph, AboutUsSecondParagraph, AboutUsThirdParagraph };
            public static IList<string> ResponsibilitiesDetails = new List<string> { ResponsibilitiesFirstParagraph };
            public static IList<string> ExperienceDetails = new List<string> { ExperienceFirstParagraph };
            public static IList<string> RequirementsDetails = new List<string> { RequirementsFirstBulletPoint, RequirementsSecondBulletPoint, RequirementsThirdBulletPoint, RequirementsFourthBulletPoint, RequirementsFifthBulletPoint, RequirementsFirstParagraph };
            public static IList<string> OptionalExperienceDetails = new List<string> { OptionalExperienceFirstBulletPoint, OptionalExperienceSecondBulletPoint, OptionalExperienceThirdBulletPoint };
            public static IList<string> BenefitsDetails = new List<string> { BenefitsFirstBulletPoint, BenefitsSecondBulletPoint, BenefitsThirdBulletPoint, BenefitsFirstParagraph };
            public static IList<string> ApplicationInstructionsDetails = new List<string> { ApplicationInstructionsFirstParagraph, ApplicationInstructionsSecondParagraph };
            private const string AboutUsFirstParagraph = "At Xeneta, our goal is to become the global reference point" +
                " for the ocean and air freight. Since our launch in 2012, we have led the data transformation of the" +
                " freight industry by providing our customers with market intelligence and freight rate benchmarking" +
                " through our SaaS platform.";
            private const string AboutUsSecondParagraph = "Our data comprises over 200 million freight container datapoints" +
                " and covers over 160,000 global trade routes. We focus on bringing transparency to the container shipping" +
                " market, thus enabling our customers to make the best decisions when procuring freight and establishing" +
                " supply chains. We have amazing customers including big brands like Unilever, Electrolux, Continental," +
                " Puma, Nestle and ThyssenKrupp.";
            private const string AboutUsThirdParagraph = "Headquartered in Oslo, with offices in Hamburg and New York, and" +
                " employees from over 30 different countries, we are a truly international company. Having been named" +
                " Norway's 'Startup of the Year' in 2016, a 'Gartner Cool Vendor' in 2018, and one of the hottest tech" +
                " scale-ups in Norway by TheNextWeb in 2019, we are excited to continue to grow across the world.";
            private const string ResponsibilitiesFirstParagraph = "As part of our Technology team, you will help us improve" +
                " and polish our internal and external products, and ensure reliable deliveries. You will collaborate with" +
                " the Tech and Product teams in planning, product testing, and the release process. As a Test Automation" +
                " Engineer, you will develop and support test automation cases. Manual testing of new features is also" +
                " part of the job.";
            private const string ExperienceFirstParagraph = "A person with over 3 years of experience in Quality Assurance of" +
                " Web projects. You are curious and inquisitive, with interest in web technologies and the ability to analyze" +
                " and explain complex problems. You care about quality, enjoy learning, and improving yourself and the team" +
                " around you.";
            private const string RequirementsFirstBulletPoint = "Experience in test automation with Python or other";
            private const string RequirementsSecondBulletPoint = "Experience in manual and exploratory testing";
            private const string RequirementsThirdBulletPoint = "Strong troubleshooting skills, understanding of OS/browsers" +
                " dependencies";
            private const string RequirementsFourthBulletPoint = "Experience in Agile/Scrum development processes";
            private const string RequirementsFifthBulletPoint = "Fluent in English, oral and written";
            private const string RequirementsFirstParagraph = "If you are not already authorized to work in Norway, a" +
                " Bachelor or a Master in a relevant field.";
            private const string OptionalExperienceFirstBulletPoint = "Experience in API testing";
            private const string OptionalExperienceSecondBulletPoint = "Experience in functional test plan development";
            private const string OptionalExperienceThirdBulletPoint = "Relevant higher education";
            private const string BenefitsFirstBulletPoint = "A great work environment with highly motivated people";
            private const string BenefitsSecondBulletPoint = "Competitive benefits, along with a generous vacation plan," +
                " flexible working hours and educational opportunities";
            private const string BenefitsThirdBulletPoint = "An opportunity to be a part of building a global company that" +
                " is transforming an industry";
            private const string BenefitsFirstParagraph = "Xeneta has a positive, diverse, and supportive culture—we look" +
                " for people who are innovative, funny, and curious and love to learn and be better every single day." +
                " Our key aim is to put the customer first and deliver memorable experiences to our audience and our" +
                " employees. Collaboration is the name of the game. We are one. If this sounds like a good fit for you," +
                " we’d love to hear from you.";
            private const string ApplicationInstructionsFirstParagraph = "Make sure to highlight your past achievements" +
                " that you think are relevant. Be sure to give us an idea of who you are as a real live person—not just" +
                " your professional experience.";
            private const string ApplicationInstructionsSecondParagraph = "Looking forward to hearing from you!";
        }
    }
}
