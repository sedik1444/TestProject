Feature: Etsy


    Scenario: Calculate all goods with discount
        Given I am on Etsy main page
        When I go to "Clothing & Shoes" -> "Women's -> Boots" page
        And found items with discount
        Then items with discount is found
        And expected items with discount equals actual items 
	
    Scenario: Add sale item to cart
        Given I am on Etsy main page
        When I go to "Clothing & Shoes" -> "Women's -> Boots" page
        And I add "0" item on page to cart
        Then item is added to cart successfully
        And I can see single item with correct price in cart