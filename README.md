# Video Rental Application

This repository contains the source code for the **Video Rental Application**, an ASP.NET Core MVC project for simulating movie rentals. The application allows users to log in, view available movies, rent movies, and view rental history. It also includes administrative functionalities for managing movies and users.

## Table of Contents
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Database Setup](#database-setup)
- [Backup and Restore](#backup-and-restore)

## Features
- **User authentication and session management**
- **Movie catalog** with details and availability
- **Movie rental functionality**
- **Rental history tracking**
- **Cast management** for movies (under development)
- **Administrative features** for managing movies and users (under development)

## Technologies Used
- **ASP.NET Core MVC**
- **Entity Framework Core**
- **SQL Server**
- **Bootstrap**
- **HTML/CSS**

## Installation
1. **Clone the repository:**
    ```sh
    git clone https://github.com/Kristijannm/VideoRental-Store.git
    cd VideoRental-Store
    ```

2. **Install dependencies:**
    ```sh
    dotnet restore
    ```

3. **Update the connection string:**
    - Open `appsettings.json`.
    - Update the connection string under `ConnectionStrings` with your SQL Server instance details.

4. **Run database migrations:**
    ```sh
    dotnet ef database update
    ```

## Database Setup
The application uses SQL Server for database management. Follow these steps to set up the database:

1. **Create a new database:**
    - Open SQL Server Management Studio (SSMS).
    - Right-click on **Databases** and select **New Database...**.
    - Enter the database name (e.g., `VideoRentalDb`) and click **OK**.

2. **Update the connection string in `appsettings.json`:**
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=YourServerName;Database=VideoRentalDb;Trusted_Connection=True;"
      }
    }
    ```

3. **Run database migrations:**
    ```sh
    dotnet ef database update
    ```

## Backup and Restore
To restore the database from a backup in SSMS:

1. Open SSMS and connect to your SQL Server instance.
2. Right-click on **Databases** and select **Restore Database...**.
3. Select **Device** and browse to the backup file (e.g., `C:\Backups\VideoRental.bak`).
4. Ensure the **Destination database** is correctly named.
5. Click **OK** to start the restore.

