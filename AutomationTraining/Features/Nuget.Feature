Feature: Nuget
	NuGet page test automation

@PageTitle
Scenario: Go to the first page and check the title
	When I navigate to the nuget page
	Then the title must be NuGet

@PageSearch
Scenario: Make a search in the nuget page and get results
	When I navigate to the nuget main page
	And I write in the search box the term SpecFlow
	And I click in the search button
	Then I verify that the url is https://www.nuget.org/packages?q=specflow