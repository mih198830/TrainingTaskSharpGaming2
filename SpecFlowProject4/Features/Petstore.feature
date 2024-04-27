Feature: Petstore
Pet create, update, delete operations via API

@mytag
Scenario: Create a pet using get request
	Given A pet was created using get request
	When I Get a pet by ID from precondition
	Then Pet is added with the specified name
	When I Update a pet from previous step and change the name to a new one
	Then Request was successful & the name is updated
	And I Delete a pet from a pet store