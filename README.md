# DelpinSecondEdition
A project to illustrate the use of domain driven design, microservices and blazor.

Before you run it:

1) Customer.Microservice uses RavenDB. Therefor you have to create a database in RavenDb and call it "Delpin". This microservice will now work.

2) Resource.Microservice uses docker (has to be Linux container). Therefor you have to Download Docker on your device. Open docker desktop, and use the command "Docker-Compose up" inside Command prompt while standing in the same path as the yml file in Resource.Microservice. EventStore is available at http://localhost:2113/ or http://localhost:1113/. Username:admin and Password:changeit

3) The project uses RabbitMQ, so you need to have this running. 

4) To run it you need to choose startup-project. You have to start: Delpin.WebClient, Gateway.API, Customer.Microservice, Lease.Microservie and Resource.Microservice. 

