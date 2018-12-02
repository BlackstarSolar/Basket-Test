Feature: Basket with vouchers
	In order to pay less for goods
	As a customer
	I want to be able to apply vouchers to my basket

Scenario: Basket 1
	Given I have added the following items to my basket:
	| Name   | Price | Quantity |
	| Hat    | 10.50 | 1        |
	| Jumper | 54.65 | 1        |
	When I apply a £5.00 Gift Voucher XXX-XXX
	Then my basket total will be £60.15

Scenario: Basket 2
	Given I have added the following items to my basket:
	| Name   | Price | Quantity |
	| Hat    | 25.00 | 1        |
	| Jumper | 26    | 1        |
	When I apply a £5.00 off Head Gear in baskets over £50.00 Offer Voucher YYY-YYY
	Then my basket total will be £51.00
	And I will receive a message "There are no products in your basket applicable to voucher Voucher YYY-YYY ."

Scenario: Basket 3
	Given I have added the following items to my basket:
	| Name       | Price | Category  | Quantity |
	| Hat        | 25.00 |           | 1        |
	| Jumper     | 26    |           | 1        |
	| Head Light | 3.50  | Head Gear | 1        |
	When I apply a £5.00 off Head Gear in baskets over £50.00 Offer Voucher YYY-YYY
	Then my basket total will be £51.00	

Scenario: Basket 4
	Given I have added the following items to my basket:
	| Name   | Price | Quantity |
	| Hat    | 25.00 | 1        |
	| Jumper | 26    | 1        |
	When I apply a £5.00 Gift Voucher XXX-XXX
	When I apply a £5.00 off baskets over £50.00 Offer Voucher YYY-YYY
	Then my basket total will be £41.00

Scenario: Basket 5
	Given I have added the following items to my basket:
	| Name         | Price | Quantity |
	| Hat          | 25.00 | 1        |
	| Gift Voucher | 30.00 | 1        |
	When I apply a £5.00 off baskets over £50.00 Offer Voucher YYY-YYY
	Then my basket total will be £55.00
	And I will receive a message "You have not reached the spend threshold for voucher YYY-YYY. Spend another £25.01 to receive £5.00 discount from your basket total."