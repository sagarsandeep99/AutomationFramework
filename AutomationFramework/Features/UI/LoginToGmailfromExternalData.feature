Feature: LoginToGmailfromExternalData

A short summary of the feature

@UiTests
Scenario Outline: Login to gmail application by reading data from excel file
	Given user1 launches browser
		| Browsers  |
		| <Browser> |
	And user1 naivagtes to gmail portal <AppURL>
	And user1 enters username and password
	When user1 clicks on login button
	Then user1 should be logged in and and navigate to Home Page
Examples:
	| Browser | AppURL              |
	| chrome  | "https://gmail.com" |


@UiTests
Scenario Outline: Login to gmail application by reading data from csv file
	Given user1 launches browser
		| Browsers  |
		| <Browser> |
	And user1 naivagtes to gmail portal <AppURL>
	And user1 enters username and password
	When user1 clicks on login button
	Then user1 should be logged in and and navigate to Home Page
Examples:
	| Browser | AppURL              |
	| chrome  | "https://gmail.com" |


@UiTests
Scenario Outline: Login to gmail application by reading data from xml file
	Given user1 launches browser
		| Browsers  |
		| <Browser> |
	And user1 naivagtes to gmail portal <AppURL>
	And user1 enters username and password
	When user1 clicks on login button
	Then user1 should be logged in and and navigate to Home Page
Examples:
	| Browser | AppURL              |
	| chrome  | "https://gmail.com" |