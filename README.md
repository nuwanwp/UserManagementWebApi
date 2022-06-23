Read me
-----------------------------

Items covered 
----------------------
1. Created domain models and database table by using CodeFirst
2. Migration script created with seed data
3. I have used TPT approach for mapping inheritence having comparing both TPH and TPC apporaches
4. Created DTO objects per domain models (domain model are not communicate with Controllers)
5. Created Auto mapper (Just to have handsone experience)
6. CRUD operations for user groups were completed
7. One to many and many to many mapping operation were completed
8. Frontend app created only for the user groups
9. Domain, Data and service layers are seperated by using class library
10. For the angular app I have used material theme and material components

Items not covered 
----------------------
1. Crud operation for other entities
2. Other required UI for frontend application
3. Conntection string not moved to appsetiings.json file
4. I have extend the DbContext class to enable the auditing information for all tables. I just used hardcoded username as "nuwanw" as created and modified user.This need to be handled through the http header. But I couldn't make it available on header and complete it.

HOw to Run
---------------
Run WebApi project for REST application. Postman collection created as follows
https://www.getpostman.com/collections/c3c833c29a7d51012a24

To run application application
locate the ClientApp directory and run following command
npm run start-local

Swagger as follows
------------------
![image](https://user-images.githubusercontent.com/5194602/175422595-82572811-ac17-4c1c-bb21-44aa5da6bd51.png)



   
