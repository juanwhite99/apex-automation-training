using AutomationTraining.Constants;
using AutomationTraining.Helpers;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AutomationTraining
{
    [Binding]
    public class NugetStepDefinitions
    {
        private readonly TestBase _testBase;

        public NugetStepDefinitions(TestBase testBase)
        {
            _testBase = testBase;
        }

        [When(@"I navigate to the nuget page")]
        public void WhenINavigateToTheNugetPage()
        {
            _testBase.Driver.Navigate().GoToUrl(TestData.NugetURL);
        }

        [Then(@"the title must be (.*)")]
        public void ThenTheTitleMustBeNuGet(string name)
        {
            _testBase.Driver.Title.Should().Contain(name);
        }


        [When(@"I navigate to the nuget main page")]
        public void WhenINavigateToTheNugetMainPage()
        {
            _testBase.Driver.Navigate().GoToUrl(TestData.NugetURL);
        }

        [When(@"I write in the search box the term (.*)")]
        public void WhenIWriteInTheSearchBoxTheTermSpecFlow(string term)
        {
            var searchBox = _testBase.Driver.FindElement(By.Id(TestData.ElementSearch));
            searchBox.SendKeys(term);
        }

        [When(@"I click in the search button")]
        public void WhenIClickInTheSearchButton()
        {
            var searchButton = _testBase.Driver.FindElement(By.CssSelector(TestData.SearchButtonSelector));
            searchButton.Click();
        }

        [Then(@"I verify that the url is (.*)")]
        public void ThenIVerifyThatTheUrlIsHttpsWww_Nuget_OrgPackagesQSpecflow(string expected)
        {
            _testBase.Driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
            var url = _testBase.Driver.Url;
            url.ToLower().Should().Be(expected);
        }

    }
}
