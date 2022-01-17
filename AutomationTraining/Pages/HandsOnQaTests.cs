using AutomationTraining.Constants;
using AutomationTraining.Helpers;
using FluentAssertions;
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
    [InlineData("user@test.com", "changeme")]
    public void TestLoginFail(string email, string password)
    {
        testBase.Driver.Navigate().GoToUrl("https://www.handsonqa.com/tclog/login.php");
        testBase.Driver.Title.Should().Contain(TestData.NugetTitle);
    }

}
