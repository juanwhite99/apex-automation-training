using System.Diagnostics;
using System.IO;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using Xunit;

namespace AutomationTraining;

public class NugetAutomation 
{
  private ChromeDriver _driver;

  public NugetAutomation()
  {
    var options = new ChromeOptions();
    var location = Directory.GetCurrentDirectory();
    options.AddArgument("--headless");
    options.AddArgument("--disable-extensions");
    options.AddArgument("--disable-gpu");
    options.AddArgument("--remote-debugging-port=9222");
    _driver = new ChromeDriver(location, options);
  }


  [Fact]
  public void TestTitle()
  {
    _driver.Navigate().GoToUrl("https://nuget.org");
    _driver.Title.Should().Contain("NuGet");
    _driver.Quit();
  }

  [Fact]
  public void TestSearch()
  {
    _driver.Navigate().GoToUrl("https://nuget.org");
    _driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
    var searchBox = _driver.FindElement(By.Id("search"));
    searchBox.SendKeys("Selenium");
    var searchButton = _driver.FindElement(By.CssSelector("#skippedToContent > section > div.jumbotron.text-center > div.container > div:nth-child(2) > div > form > div.input-group > span > button"));
    searchButton.Click();
    var url = _driver.Url;
    url.ToLower().Should().Be("https://www.nuget.org/packages?q=selenium");
    _driver.Quit();
  }
}