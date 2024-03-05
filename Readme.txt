Application: This project is responsible for the definition as well as the implementation for the business use cases which includes rules and exception in the procedures logic.
			Contracts: Represents the abstraction for the use cases implementation.
			Features: Applies the CQRS pattern to manage the use cases. Depending on the use case there is a subfolder within containing the proccess to implement.
			Behaviours: This folder is applied during the use case implementation.
		
Infrastructure: This project is related to the communication interfaces to a database server.

Domain: This project is related to the application model and schema.

API: This is the application. It manages all the operations and user requests.
    Middleware: Controls the application errors messages. 
    
Test: A project to test the infrastructure of the application.
