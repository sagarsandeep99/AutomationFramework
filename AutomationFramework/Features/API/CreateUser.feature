Feature: CreateUser

A short summary of the feature

@ApiTests
Scenario Outline: Create a new user with valid inputs
	Given user with a name <Username>
	And user with designation as <Job>
	When send request to create user with <BaseURL>
	Then validate user is created
Examples:
	| Username | Job        | BaseURL            |
	| Sagar    | QA         | https://reqres.in/ |
	| Sandeep  | Consultant | https://reqres.in/ |


@ApiTests
Scenario Outline: Create a new user with valid inputs from JSON file
	Given user payload <FileName>
	When send request to create user with <BaseURL>
	Then validate user is created
Examples:
	| FileName            | BaseURL            |
	| CreateTestUser.json | https://reqres.in/ |
	| CreateTestUser.json | https://reqres.in/ |