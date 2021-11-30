Feature: GlobalSQA
	
    Scenario: Sample Page Test
        Given I am on GlobalSQA -> "SamplePageTest" page
        When I fill all required fields with valid data
        And I submit test form
        Then test message is sent and displayed information is correct
	
    Scenario: DropDown Menu Test
        Given I am on GlobalSQA -> "DropDownMenu" page
        When I open country dropdown
        Then I see valid amount of countries