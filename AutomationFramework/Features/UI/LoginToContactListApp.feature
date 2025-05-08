Feature: LoginToContactListApp

A short summary of the feature

@UiTests
Scenario Outline: Login to Contact List Application(CLA)
	Given user launches the browser
		| Browsers  |
		| <Browser> |
	And user naivagtes to CLA portal <AppURL>
	And user enters username and password in CLA
		| UserName                   | Password      |
		| wipfli.india.llp@gmail.com | Password@1234 |
	When user logs in to Contact List app
	Then user should be logged in and and navigate to Home Page of CLA
Examples:
	| Browser | AppURL                                                |
	| chrome  | "https://thinking-tester-contact-list.herokuapp.com/" |
	| firefox | "https://thinking-tester-contact-list.herokuapp.com/" |
	| edge    | "https://thinking-tester-contact-list.herokuapp.com/" |