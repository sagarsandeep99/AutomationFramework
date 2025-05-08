Feature: LoginToContactListAppFromExternalData

Read data from external source documents

@UiTests
Scenario Outline: Login to Contact List Application(CLA) by reading data from excel file
	Given user1 launches the browser
		| Browsers  |
		| <Browser> |
	And user1 naivagtes to CLA portal <AppURL>
	And user1 enters username and password in CLA from <FileType> file
	When user1 logs in to Contact List app
	Then user1 should be logged in and and navigate to Home Page of CLA
Examples:
	| Browser | AppURL                                                | FileType |
	| Chrome  | "https://thinking-tester-contact-list.herokuapp.com/" | Excel    |
	| Firefox | "https://thinking-tester-contact-list.herokuapp.com/" | Excel    |
	| Edge    | "https://thinking-tester-contact-list.herokuapp.com/" | Excel    |


@UiTests
Scenario Outline: Login to Contact List Application(CLA) by reading data from csv file
	Given user1 launches the browser
		| Browsers  |
		| <Browser> |
	And user1 naivagtes to CLA portal <AppURL>
	And user1 enters username and password in CLA from <FileType> file
	When user1 logs in to Contact List app
	Then user1 should be logged in and and navigate to Home Page of CLA
Examples:
	| Browser | AppURL                                                | FileType |
	| Chrome  | "https://thinking-tester-contact-list.herokuapp.com/" | CSV      |
	| Firefox | "https://thinking-tester-contact-list.herokuapp.com/" | CSV      |
	| Edge    | "https://thinking-tester-contact-list.herokuapp.com/" | CSV      |


@UiTests
Scenario Outline: Login to Contact List Application(CLA) by reading data from xml file
	Given user1 launches the browser
		| Browsers  |
		| <Browser> |
	And user1 naivagtes to CLA portal <AppURL>
	And user1 enters username and password in CLA from <FileType> file
	When user1 logs in to Contact List app
	Then user1 should be logged in and and navigate to Home Page of CLA
Examples:
	| Browser | AppURL                                                | FileType |
	| Chrome  | "https://thinking-tester-contact-list.herokuapp.com/" | XML      |
	| Firefox | "https://thinking-tester-contact-list.herokuapp.com/" | XML      |
	| Edge    | "https://thinking-tester-contact-list.herokuapp.com/" | XML      |