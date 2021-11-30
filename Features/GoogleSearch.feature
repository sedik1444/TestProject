Feature: GoogleSearch
	
    Scenario: Redirect to Selenium site with google search
        Given I am on google search page
        When I search for "Selenium" site
        And I click on Selenium link
        Then i redirect to Selenium page
        And redirected url is "https://www.selenium.dev/"