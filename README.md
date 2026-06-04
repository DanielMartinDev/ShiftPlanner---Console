# Shift Planner Console

A console-based employee shift management application built in C#.

## Overview

Shift Planner Console is a simple workforce scheduling application that allows managers to create employees, assign shifts, view schedules, and persist data between sessions.

This project was created as part of my journey back into software development and focuses on applying object-oriented programming principles, data persistence, validation, and application architecture in C#.

## Features

### Employee Management

* Add new employees
* View all employees
* Delete employees
* Automatic employee ID generation

### Shift Management

* Create shifts for employees
* Assign shifts to specific days of the week
* View employee schedules
* Delete shifts
* Support for multiple shifts per employee

### Validation

* Prevent assigning shifts to non-existent employees
* Input validation for user selections
* Employee lookup by ID

### Persistence

* Save employees to file
* Save shifts to file
* Load employees on application startup
* Load shifts on application startup
* Maintain employee and shift relationships after loading

## Technologies Used

* C#
* .NET
* Object-Oriented Programming
* LINQ
* File I/O
* Git
* GitHub

## Project Structure

```text
Shift Planner Console
│
├── MainMenu
├── ShiftManager
│
├── Objects
│   ├── Employee
│   └── Shift
│
└── Data Files
    ├── employees.txt
    └── shifts.txt
```

## Skills Demonstrated

* Object-Oriented Design
* Class Relationships
* Collection Management
* File Persistence
* Data Validation
* LINQ Queries
* DateTime and TimeSpan Handling
* Console Application Development
* Source Control with Git

## Future Improvements

The planned next step for this project is a full ASP.NET Core version featuring:

* REST API
* Entity Framework Core
* SQLite / SQL Server database
* Authentication and Authorization
* Web Frontend
* Employee Availability Management
* Holiday Requests
* Shift Clash Detection

## Author

Daniel Martin

GitHub: https://github.com/DanielMartinDev
