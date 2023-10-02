# eshop-microservice
A microservice application inspired by [eshop-on-containers](https://github.com/dotnet-architecture/eShopOnContainers)

## Project Summary
Several microservices have been developed to implement e-commerce functionality, including **Catalog**, **Basket**, **Discount**, **Ordering**, **Aggregator**, and **ApiGateWay**. These microservices utilize a combination of NoSQL databases like MongoDB and Redis and relational databases such as PostgreSQL and SQL Server. They communicate with each other using RabbitMQ for event-driven communication and are orchestrated through the Ocelot API Gateway.

## Architecture Diagram
![Architecture Diagram](https://github.com/Tahsin716/eshop-microservice/blob/main/docs/img/eshop-microservice-system-design.png)

## Requirements

* [.NET 6 or later versions](https://dotnet.microsoft.com/download/dotnet-core/6.0)
* [Docker Desktop](https://www.docker.com/products/docker-desktop)

## Running the project
* Clone the repository
* Make sure Docker Desktop is running
* Go to the root directory where docker-compose.yml is located and run the command below
```console
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

## Catalog.API
[http://localhost:8000/swagger/index.html](http://localhost:8000/swagger/index.html)

![Catalog.API](https://github.com/Tahsin716/eshop-microservice/blob/main/docs/img/catalog-api.PNG)

* An ASP.NET Core Web API application
* Adheres to REST API principles and performs CRUD operations
* Establishes a connection to MongoDB and utilizes containerization
* Implements the Repository Pattern for data access
* Includes Swagger Open API for documentation

## Basket.API
[http://localhost:8001/swagger/index.html](http://localhost:8001/swagger/index.html)

![Basket.API](https://github.com/Tahsin716/eshop-microservice/blob/main/docs/img/basket-api.PNG)

- An ASP.NET Web API application
- Adheres to REST API principles and handles CRUD operations
- Establishes a connection to Redis and utilizes containerization
- Utilizes the Discount gRPC Service for synchronous inter-service communication to calculate the final product price
- Implements the publication of a BasketCheckout Queue using MassTransit and RabbitMQ

## Discount.API
[http://localhost:8002/swagger/index.html](http://localhost:8002/swagger/index.html)

![Discount.API](https://github.com/Tahsin716/eshop-microservice/blob/main/docs/img/discount-api.PNG)

- An ASP.NET Web API application
- Adheres to REST API principles and handles CRUD operations
- Establishes a connection to Redis and utilizes containerization
- Implemented a micro-ORM using EF-Core, streamlining data access and ensuring exceptional performance
- Established a connection to PostgreSQL and leveraged containerization for database management

## Discount.gRPC
[http://host.internal.docker:8003](http://host.internal.docker:8003)

_Note:_ gRPC Server uses http/2 protocol and can only be communicated internally through the application

- ASP.NET gRPC Server application
- Established highly performant inter-service communication with the Basket Microservice via gRPC
- Exposed gRPC Services, creating Protobuf messages for efficient data transfer
- Implemented a micro-ORM using EF-Core, streamlining data access and ensuring exceptional performance
- Established a connection to PostgreSQL and leveraged containerization for database management

## Order.API

[http://localhost:8004/swagger/index.html](http://localhost:8004/swagger/index.html)

![Order.API](https://github.com/Tahsin716/eshop-microservice/blob/main/docs/img/order-api.PNG)

- Implemented DDD, CQRS, and Clean Architecture, adhering to best practices.
- Developed CQRS utilizing packages like MediatR, FluentValidation, and AutoMapper.
- Consumed the RabbitMQ BasketCheckout event queue, configured with MassTransit-RabbitMQ.
- Established a connection to a SqlServer database, and containerized it.
- Utilized Entity Framework Core ORM and automatically migrated to SqlServer during application startup.

## Shopping.Aggregator

[http://localhost:8005/swagger/index.html](http://localhost:8005/swagger/index.html)

![Shopping.Aggregator](https://github.com/Tahsin716/eshop-microservice/blob/main/docs/img/shopping-aggregator.PNG)

- Implemented an Aggregator Microservice
- Aggregates data from Catalog, Basket, and Order microservice for fetching data faster than individually call microservices for the data.

## API GateWay

[http://localhost:8010](http://localhost:8010)

- Implemented API Gateways using Ocelot.
- Created sample microservices/containers for rerouting through the API Gateways.

A few Endpoints fetched using API Gateway:
 - [http://localhost:8010/Catalog](http://localhost:8010/Catalog)
 - [http://localhost:8010/Basket/John%20Doe](http://localhost:8010/Basket/John%20Doe)
 - [http://localhost:8010/Discount/IPhone%20X](http://localhost:8010/Discount/IPhone%20X)
 - [http://localhost:8010/Order/John%20Doe](http://localhost:8010/Order/John%20Doe)

Check the ocelot.json file to find out how to implement other endpoints using API Gateway.
