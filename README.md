# MSA-Backend-2020
This is my submission for the Microsoft Student Accelerator Phase 1 backend assignment.

# Intro
This is a simple Web API backend written in C# using the ASP.NET Core framework. The API just simply manages students and allows you to associate addresses with students. The CRUD operations on both these entities are exposed via the `/api/Students/` and `/api/Addresses/` endpoints (as shown in the screenshots below). You can view a live version [here](https://msa-studentsims.azurewebsites.net/index.html).

# SQL database structure screenshot:
`Students` and `Addresses` table:

![Tables](/StudentSIMS/Screenshots/tables.JPG?raw=true "Table screenshot")

# SwaggerUI endpoints:

![API endpoints](/StudentSIMS/Screenshots/api_endpoints.JPG?raw=true "API endpoints screenshot")

# Design choices/justification

## Controllers
I decided to go with two separate controllers that handle the CRUD actions for the Students and Addresses. Even though the two entities are quite closely related (since an address is associated with a student), I felt that having the separation of concerns by implementing two different controllers works better and is cleaner, as the `AddressController`'s responsibility is to manage the Addresses and the `StudentController`'s responsibility is to manage the Students.

## Student-Address database relationship
The relationship I chose to implement between the `Student` and `Address` entity was a `One-To-One` relationship. I wanted to keep things simple; one student is associated with one address. To me, having multiple addresses didn't make sense unless each address served a different purpose (e.g physical, mailing, etc...). If I wanted to have multiple address types, I would just create a base `Address` class and several other classes which would inherit from the base class but I would still have a `One-To-One` relationship (e.g one student can only have one physical and mailing address).

## Endpoints
If you look at the Address endpoints in the screenshot above, apart from the GET endpoint (`/api/Addresses`) to retrieve all addresses and the POST endpoint (`/api/Addresses`) to add a new address for an existing student, you can see that for each of the other verbs (`PUT`, `DELETE`, etc..) you have two choices on how you want to interact with these endpoints: through the address ID, or the student ID. I thought that this would be a good idea as it provides flexibility to the person consuming the API. Using the Student ID as a parameter doesn't cause any problems as my relationship between a `Student` entity and `Address` entity is one-to-one.
