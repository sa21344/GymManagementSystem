# Gym Management and Fitness Class Booking System

## Overview

Gym Management and Fitness Class Booking System is a web-based application developed using ASP.NET Core Web API and Service-Oriented Architecture principles.

The system allows gym members to browse available fitness classes and create bookings, while administrators can manage fitness classes, schedules, and reservations.

This project was developed as a Final Project for the Service Oriented Architecture course at South East European University.

---

## Features

### Authentication & Authorization

* User Registration
* User Login
* JWT Authentication
* Role-Based Authorization (Admin and Member)

### Fitness Classes

* Create Fitness Classes
* View Fitness Classes
* Update Fitness Classes
* Delete Fitness Classes

### Bookings

* Create Bookings
* View Bookings
* Capacity Validation
* Duplicate Booking Prevention

### Architecture

* Repository Pattern
* Service Layer
* DTO Pattern
* Dependency Injection
* AutoMapper

### Testing

* Unit Testing with xUnit
* Mocking with Moq

---

## Technologies Used

| Category          | Technology                     |
| ----------------- | ------------------------------ |
| Backend           | ASP.NET Core Web API (.NET 10) |
| Database          | SQL Server                     |
| ORM               | Entity Framework Core          |
| Authentication    | JWT Bearer Tokens              |
| API Documentation | Swagger                        |
| Testing           | xUnit and Moq                  |
| Version Control   | Git and GitHub                 |
| IDE               | Visual Studio 2022             |

---

## Project Structure

GymManagementSystem

* GymManagementAPI

  * Controllers
  * Services
  * Repositories
  * Models
  * DTOs
  * Profiles
  * Data

* GymManagementTests

  * AuthServiceTests
  * FitnessClassServiceTests

---

## API Endpoints

### Authentication

* POST /api/Auth/register
* POST /api/Auth/login

### Fitness Classes

* GET /api/FitnessClasses
* GET /api/FitnessClasses/{id}
* POST /api/FitnessClasses
* PUT /api/FitnessClasses/{id}
* DELETE /api/FitnessClasses/{id}

### Bookings

* GET /api/Bookings
* POST /api/Bookings

---

## Unit Testing

Implemented unit tests for:

* AuthService
* FitnessClassService

Current Results:

* Passed: 8
* Failed: 0

---

## Author

Sadri Aliu 

ID: 121344

South East European University

Faculty of Contemporary Sciences and Technologies

Service Oriented Architecture – Final Project
