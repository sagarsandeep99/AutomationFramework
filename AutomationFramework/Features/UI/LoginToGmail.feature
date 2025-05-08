Feature: LoginToGmail

A short summary of the feature

@UiTests
Scenario Outline: Login to gmail application
	Given user launches browser
		| Browsers  |
		| <Browser> |
	And user naivagtes to gmail portal <AppURL>
	#And user enters username and password
	#| UserName                   | Password      | UserName1         | Password1 |
	#| wipfli.india.llp@gmail.com | Password@1234 | wipfli2@gmail.com | password  |
	And user enters username and password
		| UserName                   | Password      |
		| wipfli.india.llp@gmail.com | Password@1234 |
	When user clicks on login button
	Then user should be logged in and and navigate to Home Page
Examples:
	| Browser | AppURL              |
	| chrome  | "https://gmail.com" |
	| firefox | "https://gmail.com" |
	| edge    | "https://gmail.com" |
