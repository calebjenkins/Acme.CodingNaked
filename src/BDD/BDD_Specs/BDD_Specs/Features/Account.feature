Feature: Account can calculate Account Type

A record for handeling Accounts


@bdd, @specFlow, @codingNaked
Scenario: Account calculates Account Type
	Given an Account with No Trips
	When calculating account type
	Then result should be AccountType.Standard
