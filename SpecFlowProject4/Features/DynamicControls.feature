Feature: DynamicControls
Check https://the-internet.herokuapp.com/ Dynamic Controls functionality

@ui
Scenario: Dynamic Controls
	Given I Click link on the Main page
	When I Click 'Enable' button
	Then Enable/disable input is enabled
	When I Send random text to Enable/disable input
	Then Random text is displayed
