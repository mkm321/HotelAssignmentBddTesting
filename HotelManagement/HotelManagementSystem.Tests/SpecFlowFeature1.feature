Feature: Add hotel
	In order to simulate hotel management system
	As api consumer
	I want to be able to add hotel,get hotel details and book hotel

@AddHotel
Scenario Outline: User adds hotel in database by providing valid inputs
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And Use has added required details for hotel
	When User calls AddHotel api
	Then Hotel with name '<name>' should be present in the response
Examples: 
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |

@GetHotelById
Scenario Outline: User gets the details of hotel by providing an id
	Given User provided valid Id '<id>'  and '<name>'for hotel
	And Use has added required details for hotel
	And User calls AddHotel api
	And User has provided a valid '<id>' to check existence
	When User calss GetHotelByID api
	Then User should get the details of hotel id '<id>' if present
Examples: 
| id | name   |
| 4  | hotel4 |

@GetAllHotels
Scenario: User gets details of all the hotels
	Given User provided valid Id '5'  and 'hotel5' for hotel
	And Use has added required details for hotel
	And User calls AddHotel api
	And User provided valid Id '6'  and 'hotel6' for hotel
	And Use has added required details for hotel
	And User calls AddHotel api
	And User provided valid Id '7'  and 'hotel7' for hotel
	And Use has added required details for hotel
	And User calls AddHotel api
	When User calls GetHotels api
	Then User should get the details of hotel with id 5,6,7
