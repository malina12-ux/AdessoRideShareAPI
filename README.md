# Adesso Ride Share API

## Requirement Specification
* Users should be able to add the travel plan to the system with From, To, Date and Description, and Number of Seat information.
* Users should be able to publish and unpublish the travel plan they defined.
* Users should be able to search for active travel plans in the system with From and To information.
* Users should be able to submit a request to join active travel plans until the "Number of Seats" is filled.
 

### Endpoints

The table below describes the endpoint for this API:
 

Name						| Action   | Route                          |  Description
|:------------				| :-------| :-----------                   |:------------
Get travel plans			| GET     | /api/TravelPlan                 | Return all travel plans                        
Get travel plan by ID		| GET     | /api/TravelPlan/{id}           | Get travel plan by Id
Find travel plan			| GET     | ​/api​/TravelPlan​/FindTravelPlan | Search active travel plans after "From", "To".
Find active  travel plans	| GET     | /api/TravelPlan/GetActiveTravelPlan | Return all active plans
Get passengers				| GET     | /api/Passengers				| Return all passengers
Get passengers by Id		| GET     | /api/Passengers/{id}			|  Get passenger by Id    
Post TravelPlan				| POST    | /api/TravelPlan				| Add TravelPlan
Post Passenger				| POST    | /api/Passengers				| Add Passenger  
Update status travel plan	| PUT     | /api/TravelPlan/{id}		|Change status travel plan(active, inactive)
Delete travel plan			| DELETE  | /api/TravelPlan/{id}		|Remove travel plan
Delete passenger			| DELETE  | /api/Passengers/{id}		|Remove passenger




