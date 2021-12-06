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
        
	Scenario: Demo Testing Site verify items count on page
		Given I am on GlobalSQA -> "Main" page
		When I switch to TESTER’S HUB -> "Demo Testing Site" page
		Then I see count of options in each column equal to "6" 
		
	Scenario: Date picker Test
		Given I am on GlobalSQA -> "Main" page
		When I switch to TESTER’S HUB -> "Demo Testing Site" -> "DatePicker" submenu
		And choose current day of the next month from calendar
		Then date displaying in "MM/dd/yyyy" format
		
	Scenario: Progress Bar Test
		Given I am on GlobalSQA -> "Main" page
		When I switch to TESTER’S HUB -> "Demo Testing Site" -> "Progress Bar" submenu
		And start downloading the file
		Then file downloaded successfully
		And downloading status is "Complete!"