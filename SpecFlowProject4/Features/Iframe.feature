Feature: Iframe
A short summary of the feature

@ui
Scenario: Editing Text in an iFrame and Undoing Changes
	When I Click 'Frames' link on the page
	  And I Click 'iFrame' link on the page
	  And I Input random generated text to the text editor
	Then Random text is displayed
	When I Undo changes with Edit menu
	Then "Your content goes here." text is displayed in the editor
