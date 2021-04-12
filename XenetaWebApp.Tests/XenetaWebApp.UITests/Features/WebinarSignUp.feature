Feature: WebinarSignUp
	In order to better understand Xeneta's platform
	As a user of the website
	I want to sign up for the webinar

Scenario: Webinar sign up application submitted successfully
	Given I am on the webinar sign up screen
	And I enter a first name of 'John'
	And I enter a last name of 'Doe'
	And I enter a company name of 'JoEnt'
	And I enter a business email of 'john.doe@joent.com'
	And I enter a job title of 'CEO'
	And I select that the company is a 'Shipper/BCO'
	And I select that the global number of TEUs shipped annually is 'Less than 2000'
	And I select that the annual air freight ton is 'Less than 1,000 Ton'
	And I agree to the privacy policy of Xeneta
	When I submit my webinar signup application
	Then I should be navigated to the webinar signup thank you page

Scenario:  View privacy policy when signing up for webinar
	Given I am on the webinar sign up screen
	When I click the privacy policy link
	Then I should be navigated to the privacy policy page

Scenario: Submit webinar sign up application without accepting privacy policy
	Given I am on the webinar sign up screen
	And I enter a first name of 'John'
	And I enter a last name of 'Doe'
	And I enter a company name of 'JoEnt'
	And I enter a business email of 'john.doe@joent.com'
	And I enter a job title of 'CEO'
	And I select that the company is a 'Shipper/BCO'
	And I select that the global number of TEUs shipped annually is 'Less than 2000'
	And I select that the annual air freight ton is 'Less than 1,000 Ton'
	But I don't agree to the privacy policy of Xeneta
	When I submit my webinar signup application
	Then Application should not be submitted