using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTraining.Helpers
{
    public class TestBase: IDisposable
    {
        public ChromeDriver Driver { get; set; }

        public TestBase()
        {
          var options = new ChromeOptions();
          var location = Directory.GetCurrentDirectory();
          options.AddArgument("--headless");
          options.AddArgument("--disable-extensions");
          options.AddArgument("--disable-gpu");
          options.AddArgument("--remote-debugging-port=9222");
          Driver = new ChromeDriver(location, options);
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
