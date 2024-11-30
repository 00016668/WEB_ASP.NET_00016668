Web Application Portfolio Project

This application was developed for the Web Application Development module as a coursework portfolio project @ WIUT by student ID: 00016668

Overview

This project demonstrates a comprehensive full-stack web application development process using ASP.NET Core for the back end and Angular for the front end. The application showcases key functionalities, including:
 ----> API development with Entity Framework Core
 ----> A responsive Single Page Application (SPA)
 ----> Integration of software design patterns
 ----> CRUD operations between the SPA and API

Repository Link
Here is the repository link publicly available to everyone: https://github.com/00016668/WEB_ASP.NET_00016668.git

Calculation
The calculation is done to determine which project to do: Here is the id => 00016668
I divided 16668/20 and get the remainder. Here the remainder is 16668%20 => 8
So, I chose "Contact Manager" as the project name.

Development Plan

1.MoSCoW Prioritization
The development plan was structured using the MoSCoW method, prioritizing tasks into Must-Have, Should-Have, Could-Have, and Won't-Have categories. The full prioritization and justifications are provided in the report.

2.Timeline
A Gantt chart outlining the timeline and progress for each task is shown in the report.

3.Database Schema
The database schema design includes two tables with a foreign key relationship. A screenshot of the schema is available in the report as well.

System Architecture

This project employs software design patterns to optimize structure and maintainability: 
 ---->   Repository Pattern: Used to abstract the data access logic from the business logic.
 ---->   Dependency Injection: Applied to manage service lifetimes and improve testability.

API (Back End)

The backend part was created using ASP.Net core application. It includes:
    => Data Access Layer 
    => Models
    => Controllers
    => IRepository and its implementation
    => Migrations

SPA (Front End)

The frontend part was developed using Angular, ensuring responsiveness and modern design. It connects to the API for full CRUD functionality:
    => Angular Service
    => Interface
    => CRUD features
    => Design

Libraries to download:
    => Microsoft.EntityFrameworkCore
    => Microsoft.EntityFrameworkCore.SqlServer
    => Microsoft.EntityFrameworkCore.Tools
    => AutoMapper

Prerequisites
To run the application locally, first you need:
    => .NET SDK: Version 6.0 or higher, because it was done on version 6.0
    => Node.js: New version
    => Angular CLI: New version
    => Database: I used MS SQL Server
Setup Instructions:
    1. First clone the repository => git clone https://github.com/00016668/WEB_ASP.NET_00016668.git
    2. Navigate to the API project and align it to your database. change to your sever name, connection string name (if you prefer), then delete the migrations and make migrations again. Here is how to do
        a. add-migration init
        b. update-database
    3. Run the ANP.Net project
    4. Navigate to the Angular project and install dependencies
    5. Run the application. It is available on port http://localhost:4200
Do  not forget, both api(backend) and angular(frontend) must work at the same time

