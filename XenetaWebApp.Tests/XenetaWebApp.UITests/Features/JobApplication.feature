Feature: JobApplication
	In order to land a job
	As a user of the website
	I want to apply for jobs at Xeneta

Scenario: View the details for a selected job
	Given I am on the Careers page
	When I click on the title of a job
	Then Details of the job should be displayed

Scenario: Navigate to the job application page for a selected job
	Given I am on the Careers page
	And I have opened the details of a job
	When I click the link to apply for the job
	Then I should be navigated to the job application page