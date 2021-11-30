Feature: EmailPortal
	
    Scenario: Login with right credentials
        Given I am on MailRu -> "LoginPage"
        When I login with right credentials
        Then I redirected to my personal account
	

    Scenario: Send email with attachment
        Given I logged in personal account
        When I send email with attachment
        Then info message that email is sent displayed
        And I can cancel sending email