Feature: Example

User will nevigate to BBC news website and the search the word and verify word present in tile of results


Scenario: Search word on bbc and verify it
	Given User nevigate to BBC news website
	When User verify its on BBC news website
	Then User Click on Search bar
	And User search word "Chorley"
	Then User verify word appear in "5" title of search result

