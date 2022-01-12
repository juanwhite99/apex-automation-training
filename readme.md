# Apex automation course day 1
---

### Create the new project
```
dotnet new xunit -n "AutomationTraining"
```

### Adding the packages
```
cd AutomationTraining
dotnet add package FluentAssertions
dotnet add package Selenium.WebDriver
dotnet add package Selenium.WebDriver.ChromeDriver
```

### "Sauces"
* https://fluentassertions.com/
* https://fluentassertions.com/introduction
* https://dotnet.microsoft.com/en-us/download
* https://www.lambdatest.com/blog/implicit-wait-csharp-selenium/


### Usefull commands 

* ##### Gitignore generator command
```
dotnet new gitignore
```

* ##### To run the tests
```
dotnet test
```

* ##### To kill the processes
```
taskkill /F /IM chromedriver.exe /T
taskkill /F /IM chrome.exe /T
```

