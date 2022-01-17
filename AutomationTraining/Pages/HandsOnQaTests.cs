using System;
using System.Threading;
using AutomationTraining.Helpers;
using AutomationTraining.Constants;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace AutomationTraining.Pages;

public class HandsOnQaTests: IClassFixture<TestBase>
{
    private TestBase testBase;

    public HandsOnQaTests(TestBase _testBase)
    {
        this.testBase = _testBase;
    }

    [Theory]
    [InlineData("test@email.com", "changeme")]
    public void TestLoginSuccess(string email, string password)
    {
        var wait = new WebDriverWait(testBase.Driver, TimeSpan.FromSeconds(10));
        testBase.Driver.Navigate().GoToUrl(HandsOnQaTestData.LoginUrl);
        var emailTextBox = testBase.Driver.FindElement(By.Id("email"));
        var passwordTextBox = testBase.Driver.FindElement(By.Id("password"));
        emailTextBox.SendKeys(email);
        passwordTextBox.SendKeys(password);
        testBase.Driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        Thread.Sleep(2000);

        var result = testBase.Driver.FindElement(By.Id("loginResult"));
        result.Text.ToLower().Should().Contain("login successful");
    }

    [Theory]
    [InlineData("user@test.com", "changeme")]
    [InlineData("user0@test.com", "changeme")]
    [InlineData("user1@test.com", "changeme")]
    [InlineData("user2@test.com", "changeme")]
    [InlineData("user3@test.com", "changeme")]
    public void TestLoginFail(string email, string password)
    {
        var wait = new WebDriverWait(testBase.Driver, TimeSpan.FromSeconds(10));
        testBase.Driver.Navigate().GoToUrl(HandsOnQaTestData.LoginUrl);
        var emailTextBox = testBase.Driver.FindElement(By.Id("email"));
        var passwordTextBox = testBase.Driver.FindElement(By.Id("password"));
        emailTextBox.SendKeys(email);
        passwordTextBox.SendKeys(password);
        testBase.Driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        Thread.Sleep(2000);

        var result = testBase.Driver.FindElement(By.Id("loginResult"));
        result.Text.ToLower().Should().Be("login failed");
    }

}
