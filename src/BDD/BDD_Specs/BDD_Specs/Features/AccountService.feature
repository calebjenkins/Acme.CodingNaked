Feature: Account Service

A service for creating Accounts and running account specific calculations





@bdd, @specFlow, @codingNaked
Scenario: Calculating Trip Price - Standard Status
	Given an Account with Standard Status
	And the Trip has 500 points
	And its not a weekend
	When Trip value is calculated
	Then the result should be 20000

	Given an Account with Standard Status
	And the Trip has 500 points
	And it IS a weekend
	When Trip value is calculated
	Then the result should be 20000
