# Restaurant Reservation System

[![.NET](https://github.com/DotNetBackendTraining/restaurant-reservation-system/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/DotNetBackendTraining/restaurant-reservation-system/actions/workflows/build-and-test.yml)

## Running the application

- Use `docker-compose.migrate.yml` to update the database.
- Then use `docker-compose.yml` to run the application.

## Before you start

- Use .NET Core 5.0+
- Do one task at a time.
- Use **Asynchronous** methods in **LINQ**.
- Follow **GIT** best practices.

You must use Git for version control and host your project on GitHub. Commit and push your changes to GitHub at the end
of each phase, with meaningful commit messages describing what you have implemented in each commit.

Before we dive into the task at hand, let's first explore the Database Schema. By meticulously examining the tables,
deciphering their relationships, and grasping the significance of each, we will lay a strong foundation for addressing
the subsequent question.

![DatabaseSchema](assets/InitialDatabaseSchema.png)

## Requirements

1. Create a DB named **`RestaurantReservationCore`** (using SSMS).
2. Create a console application project named **`RestaurantReservation`**.
3. Create a library project named **`RestaurantReservation.Db`** and reference it from **`RestaurantReservation`**
   project.
4. Create **`RestaurantReservationDbContext`** and add it to **`RestaurantReservation.Db`**.
5. Create the data models for the above tables with all necessary **keys, relationships, constraints, and navigations**.
   These models should exist in **`RestaurantReservation.Db`**
6. Write migrations to create the previous tables. Migrations should exist in **`RestaurantReservation.Db`**.
7. Seed the tables with at least **5 records** in each.
8. In the **`RestaurantReservation`** console application, demonstrate the functionality of all the methods you will
   create by calling them with sample data for testing purposes.
9. Write **`Create/Update/Delete`** methods for each entity.
10. Write methods to:
    1. **`ListManagers()`**: This method retrieves all employees who hold the position of "Manager."
    2. **`GetReservationsByCustomer(CustomerId)`**: This method takes a customer identifier as a parameter and returns a
       list of reservations made by that particular customer.
    3. **`ListOrdersAndMenuItems(ReservationId)`**: This method takes a reservation identifier as a parameter and lists
       the orders placed on that specific reservation along with the associated menu items.
    4. **`ListOrderedMenuItems(ReservationId)`**: This method takes a reservation identifier as a parameter and finds
       the menu items ordered in that specific reservation.
    5. **`CalculateAverageOrderAmount(EmployeeId)`**: This method takes an employee identifier as a parameter and
       calculates the average order amount for that specific employee.
11. Views:
    1. Use EF Core to query a database view that lists all the reservations with their associated customer and
       restaurant information.
    2. Generate a query that retrieves employees with their respective restaurant details from a database view.
12. Database Functions:
    1. Create a database function to **`Calculate the total revenue generated by a specific restaurant`** using Entity
       Framework Core migrations.
    2. Implement the function call in your **`RestaurantReservation.Db`** project, making it accessible from your
       application.
13. Stored Procedures:
    1. Design a stored procedure for
       **`Finding all customers who have made reservations with a party size greater than a certain value`** using
       Entity
       Framework Core migrations.
    2. Develop a method in your RestaurantReservation.Db project to execute the stored procedure.
14. Create a repository class for each entity and call it: **`{EntityName}Repository.cs`**, and move related methods
    from the previous requirements to the right repository. These repositories should exist in **`Repositories`**
    folder **`RestaurantReservation.Db`**
