Feature: Account Service

A service for creating Accounts and running account specific calculations


@bdd, @specFlow, @codingNaked
Scenario: Calculating Trip Price - Standard Status
	Given an Account with Standard Status
	And the Trip has 500 points
	And its not a weekend
	When Trip value is calculated
	Then the result should be BasePrice

	Given an Account with Standard Status
	And the Trip has 500 points
	And it IS a weekend
	When Trip value is calculated
	Then the result should be BasePrice-WeekendDiscount


@bdd, @specFlow, @codingNaked
Scenario: Calculating Trip Price - Silver Status
	Given an Account with Silver Status
	And the Trip has 500 points
	And its not a weekend
	When Trip value is calculated
	Then the result should be SilverPriceTimesPoints

	Given an Account with Silver Status
	And the Trip has 500 points
	And it IS a weekend
	When Trip value is calculated
	Then the result should be SilverPriceTimesPoints-WeekendDiscount


@bdd, @specFlow, @codingNaked
Scenario: Calculating Trip Price - Gold Status
	Given an Account with Gold Status
	And the Trip has 500 points
	And its not a weekend
	When Trip value is calculated
	Then the result should be GoldPriceTimesPoints

	Given an Account with Gold Status
	And the Trip has 500 points
	And it IS a weekend
	When Trip value is calculated
	Then the result should be GoldPriceTimesPoints-WeekendDiscount