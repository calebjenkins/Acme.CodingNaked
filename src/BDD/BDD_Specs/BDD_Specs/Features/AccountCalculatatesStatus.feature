Feature: Account can calculate Account Type

A record for handeling Accounts


@bdd, @specFlow, @codingNaked
Scenario: Account calculates Account Status
	Given an Account with trips worth <points> points
	When calculating account Status
	Then account status should be <accountStatus>

	Examples: 
		| points | accountStatus |
		| 0      | Standard    |
		| 10     | Standard    |
		| 499    | Standard    |
		| 500    | Silver      |
		| 550    | Silver      |
		| 999    | Silver      |
		| 1000   | Gold        |
		| 1200   | Gold        |

	
