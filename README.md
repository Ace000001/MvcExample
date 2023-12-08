# MvcExample
MVC core with onion architecture and CQRS pattern

Following are some key points about this example:

-This example is using the Onion Architecture with CQRS design patter.

-I tried to separate read and write operations by handling writes in service and reads in query handlers.

-Get performance and extensibility benefits as dictated by CQRS. This structure enables us to even go further and use  dapper in single object response queries and graphQl with elastic search queries for list responses for further performance gains.

-It is only an example and can even add common layer for shared ViewModel and use mappers for mapping to and from domain models.
