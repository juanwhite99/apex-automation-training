using AutomationTraining.Constants;
using AutomationTraining.Helpers;
using FluentAssertions;
using OpenQA.Selenium;

using Xunit;

namespace AutomationTraining.Pages;

public class NugetAutomation : IClassFixture<TestBase>
{
  private TestBase testBase;

  public NugetAutomation(TestBase _testBase)
  {
    this.testBase = _testBase;
  }


  [Fact]
  public void TestTitle()
  {
    testBase.Driver.Navigate().GoToUrl(TestData.NugetURL);
    testBase.Driver.Title.Should().Contain(TestData.NugetTitle);
  }

  [Fact]
  public void TestSearch()
  {
    testBase.Driver.Navigate().GoToUrl(TestData.NugetURL);
    testBase.Driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
    var searchBox = testBase.Driver.FindElement(By.Id(TestData.ElementSearch));
    searchBox.SendKeys("Selenium");
    var searchButton = testBase.Driver.FindElement(By.CssSelector(TestData.SearchButtonSelector));
    searchButton.Click();
    var url = testBase.Driver.Url;
    url.ToLower().Should().Be(TestData.ExpectedURL);
  }
}
