Feature: Basket
	As a customer I want to add items to the basket to purchase later

@functional
Scenario: Add Item to Basket
	Given that I am on the home page
	When I add an item to the basket
	Then it is displayed in the basket

@functional
Scenario: Remove Item from Basket
	Given that I am on the home page
	When I add an item to the basket
	And I then remove it from the basket
	Then the basket is empty