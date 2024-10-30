# Sports Club Management System

Welcome to the **Sports Club Management System** - an MVC-based application that efficiently manages player and sports details in a master-detail format. This system enables seamless CRUD operations on Players and their associated Sports activities, making it ideal for sports clubs seeking a robust and user-friendly management solution.

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Architecture](#architecture)
- [Setup & Installation](#setup--installation)
- [Usage](#usage)
- [Contributions](#contributions)

## Overview
The Sports Club Management System is a master-detail MVC project where **Players** serve as the main entity (master) and **Sports** as the related details. Built with ASP.NET MVC, this application ensures smooth CRUD operations with a structured backend and intuitive user interface. 

## Features
- **Player & Sports Management**: Perform CRUD operations for both Players and Sports Lists.
- **Master-Detail Structure**: Link each player with their respective sports.
- **Paging, Searching, and Sorting**: Efficiently manage and browse through large datasets with built-in paging, search filters, and sorting.
- **Model Binding & View Design**: Model binding and custom views provide an organized display and functionality.
- **Entity Framework**: Uses EF for database interactions.
- **Ease of Setup**: Configure and set up with minimal effort.

## Architecture
The application is structured as follows:
1. **Controllers**:
   - `HomeController` - Manages home views and navigation.
   - `PlayerController` - Handles CRUD operations for players.
   - `SportsController` - Manages CRUD operations for sports entries.
  
2. **Models**:
   - **ViewModels**: Contains `SportsViewModel.cs`, used for custom display and binding of sports data.
   - **Main Models**:
     - `Player.cs` - Represents player details.
     - `Sports.cs` - Represents sports details.
     - `SportEntry.cs` - Links players with their respective sports entries.
   - **AppDbContext.cs**: Database context for managing entity classes with Entity Framework.

3. **Views**: Contains the Views for each controller to facilitate the UI and data binding.
  
4. **Configuration**:
   - **Database Connection**: Set in `web.config` with `connectionString`.
   - **EF Migrations**: Run `update-database` to initialize and update the database.


## Setup & Installation

### Prerequisites
- **Visual Studio** (with ASP.NET and web development workloads)
- **SQL Server** or **LocalDB**
  
### Steps
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/MonirInCode/Sports-CLUB_MVC_Project.git

2. **Open in Visual Studio**:

Open the solution in Visual Studio.
Configure Database:
Ensure your database configuration is correct in web.config.
Navigate to the Package Manager Console and run: **update-database**

**Build and Run**:
Run the project to start the Controller
--------------------------------------------
### Screenshots
![P-1](https://github.com/user-attachments/assets/d7e52960-6085-45f0-89f9-4e201f7b041b)
![P-2](https://github.com/user-attachments/assets/6cf15bc0-0fb4-4562-8259-76a307f1bdda)
![P-3](https://github.com/user-attachments/assets/9e610186-109d-49d7-a4b8-a467ea7eaba2)
![P-4](https://github.com/user-attachments/assets/3e4c2293-0194-4f62-bd9d-93152e090a7b)
![p-5](https://github.com/user-attachments/assets/6ad70097-9497-427a-8568-a71892a6e9b1)
![p-6](https://github.com/user-attachments/assets/fa6dde1e-1776-4ac4-9f9c-f7549ec47b6f)


## Usage
Navigate to the Player section to add, edit, or delete player entries.
Access the Sports section to manage sports lists linked to players.
Use Paging, Searching, and Sorting features to quickly find and manage data.
View the Home page for an overview and quick navigation.

## Contributions
Contributions are welcome! To contribute:

Fork this repository.
Create a new branch (feature/my-feature).
Commit your changes.
Push to your branch and submit a Pull Request.

## Contact
For questions or feedback, please reach out to monirgsc@gmail.com
