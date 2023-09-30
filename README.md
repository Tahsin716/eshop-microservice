# eshop-microservice
A microservice application inspired by [eshop-on-containers](https://github.com/dotnet-architecture/eShopOnContainers)

## Project Summary
Several microservices have been developed to implement e-commerce functionality, including **Catalog**, **Basket**, **Discount**, and **Ordering**. These microservices utilize a combination of NoSQL databases like MongoDB and Redis, as well as relational databases such as PostgreSQL and SQL Server. They communicate with each other using RabbitMQ for event-driven communication and are orchestrated through the Ocelot API Gateway.

## Architecture Diagram
![Architecture Diagram](https://github.com/Tahsin716/eshop-microservice/blob/main/docs/img/eshop-microservice-system-design.png)

## Requirements

* [.NET 6 or later versions](https://dotnet.microsoft.com/download/dotnet-core/6)
* [Docker Desktop](https://www.docker.com/products/docker-desktop)
