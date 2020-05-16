# journey-ddd
Domain Driven Design 

## Solution Structure
Structuring the solution or creating multiple projects with proper reason and use is very important. One of the main problem I used to face is to decide up on where to put each of the files in my solution. 
Also, while creating each class library or each class in the project, we should have a reason for its existance.
Here, I begin considering few principles and practices from various articles and DDD(Domain Driven Design) practices.

### Journey.API
This is a .net core web api project. This should contain only those files and folders which are used in this project. This project mainy deals with 
* API input validation
* Handling requests and responses - this include all the filters and middlewares
* Dependecy injection, logging, versioning and so on
### Journey.Application
We can divide the operations that we perform in our project as two
* Domain specific operations such as CustomerCreated, BookingPlaced, BookingCanced and so on
* Application related operations such as EmailSent, SMSSent or Logging
### Journey.Domain
Every project is supposed to solve a problem or ease the operation of a particular domain. We should see what is happening in the domain and try to model it in our software. This project tries to create the model which is kind of equivalent to the real domain we are handling.
This project should contains Entities which may exists in real. As per Domain Driven Design practices, we can have all stuff related to the domain in here, such as
* Entities
* ValueObjects
* DomainServices
* DomainValidations
* Exceptions
