# Task Management API

A RESTful Web API built with **ASP.NET Core** and **SQL Server** for managing tasks, with user authentication and role-based authorization.

## Overview

Task Management API is a backend project developed to practice building secure and maintainable APIs using ASP.NET Core. It provides task management functionality and separates users' data based on their authenticated identities.

## Features

- **User Authentication:** Register and log in using ASP.NET Core Identity.
- **JWT Authentication:** Secure API endpoints using JSON Web Tokens.
- **Role-Based Authorization:** Support for Admin and Customer roles.
- **Task Management:** Create, retrieve, update, and delete tasks.
- **User-Specific Tasks:** Associate tasks with their owners.
- **Database Integration:** Store application data using SQL Server and Entity Framework Core.
- **API Documentation:** Explore and test endpoints using Scalar.

## Technologies Used

- C#
- ASP.NET Core Web API
- ASP.NET Core Identity
- JWT (JSON Web Tokens)
- Entity Framework Core
- Microsoft SQL Server
- Scalar
- RESTful API principles

## Getting Started

### Prerequisites

Make sure you have the following installed:

- .NET SDK compatible with the project
- Microsoft SQL Server
- Visual Studio or Visual Studio Code

### Installation

1. Clone the repository:

   ```bash
   git clone YOUR_REPOSITORY_URL
   ```

2. Navigate to the project directory:

   ```bash
   cd TaskManagement.Api
   ```

3. Configure your database connection string and JWT settings in your local configuration.

4. Apply the Entity Framework Core migrations:

   ```bash
   dotnet ef database update
   ```

5. Run the application:

   ```bash
   dotnet run
   ```

6. Open the Scalar API reference URL displayed by the application to explore and test the endpoints.

## Authentication

1. Register a new account.
2. Log in to obtain a JWT access token.
3. Use the token to access protected endpoints.

Newly registered users are assigned the Customer role by default. Administrative access must be assigned separately.

## Project Purpose

This project is part of my journey in backend development with C#. It helps me strengthen my understanding of RESTful APIs, database operations, authentication, authorization, and secure application design.

## Author

**Saif Jarrar**

GitHub: [saifjarrar916-debug](https://github.com/saifjarrar916-debug)
