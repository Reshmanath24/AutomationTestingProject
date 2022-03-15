Feature: TMFeature

In this feature, we will create , edit and update the time and material records.
So that we can manage the employee's time and material records successfully.

@tag1
Scenario: I would like to create TM records
	Given I logged in successfully to the turnup portal
	And Navigated to the TM page
	When the Time and material was created
	Then the record has been created successfully

 Scenario Outline: I would like to edit TM records
	Given I logged in successfully to the turnup portal
	And Navigated to the TM page
	When the '<Description>','<Code>','<Price>' field has to be updated in the time and material record
	Then Need to check the '<Description>','<Code>','<Price>' field has been updated successfully

	Examples: 
	| Description     | Code | Price |
	| EditDescription | abc  | 123   |
	| 123edit         | def  | 67    |
	| !"#)*^&(        | 890  | 68767 |







