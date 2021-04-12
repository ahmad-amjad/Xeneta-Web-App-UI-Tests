Feature: ScheduleDemo
	In order to better understand Xeneta's platform
	As a user of the website
	I want to schedule a demo

Scenario: Schedule demo application submitted successfully
	Given I am on the demo booking screen
	And I enter a first name of 'John'
	And I enter a last name of 'Doe'
	And I enter a company name of 'JoEnt'
	And I enter a business email of 'john.doe@joent.com'
	And I enter a phone number '+1-541-754-3010'
	And I set a meeting date for 'today'
	And I enter a meeting time of '14:30'
	And I enter a job title of 'CEO'
	And I select that the company is a 'Shipper/BCO'
	And I select that the global number of TEUs shipped annually is 'Less than 2000'
	And I select that the annual air freight ton is 'Less than 1,000 Ton'
	And I agree to the privacy policy of Xeneta
	When I submit my demo schedule application
	Then I should see a thank you message confirming my booking for a demo

Scenario:  View privacy policy when scheduling a demo
	Given I am on the demo booking screen
	When I click the privacy policy link
	Then I should be navigated to the privacy policy page

Scenario: Submit schedule demo application without accepting privacy policy
	Given I am on the demo booking screen
	And I enter a first name of 'John'
	And I enter a last name of 'Doe'
	And I enter a company name of 'JoEent'
	And I enter a business email of 'john.doe@joent.com'
	And I enter a phone number '+1-541-754-3010'
	And I set a meeting date for 'today'
	And I enter a meeting time of '14:30'
	And I enter a job title of 'CEO'
	And I select that the company is a 'Shipper/BCO'
	And I select that the global number of TEUs shipped annually is 'Less than 2000'
	And I select that the annual air freight ton is 'Less than 1,000 Ton'
	But I don't agree to the privacy policy of Xeneta
	When I submit my demo schedule application
	Then Application should not be submitted