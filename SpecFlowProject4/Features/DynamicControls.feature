Feature: DynamicControls
Check https://the-internet.herokuapp.com/ Dynamic Controls functionality

@ui
Scenario: Using Dynamic Controls to Enable/Disable Input
	When I Click 'Dynamic Controls' link on the Main page
	When I Click 'Enable' button
	Then Enable/disable input is enabled
	When I Send random text to Enable/disable input
	Then Random text is displayed
