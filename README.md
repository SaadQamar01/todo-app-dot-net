#Overview
This application is a Payment Details CRUD (Create, Read, Update, Delete) system designed to handle and manage payment card information. Users can enter their card details, view saved information, update existing records, and delete entries as needed.

##Features
Add Payment Details: Users can enter and submit new payment card details.
View Payment Details: Retrieve and view a list of all saved payment details.
Update Payment Details: Edit and update existing payment records.
Delete Payment Details: Remove payment details from the system.

###Technologies Used
Backend: .NET 7
Frontend: ASP.NET Core
Database: SQL Server (running in Docker)
Development Environment: Azure Data Studio on macOS

####Prerequisites
Docker installed on your macOS.
Azure Data Studio installed on your macOS.
.NET 7 SDK installed.

#####Pull and Run SQL Server Container

docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourNewPassword123!' -p 1433:1433 --name sql -d mcr.microsoft.com/mssql/server
CHECK DOCKER IS RUNNING
---> docker ps

##Run the Application

Build and run the .NET application:
dotnet build
dotnet run

####Open Swagger UI
Go to debug on top of visual studio
click run without debugging
Navigate to https://localhost:7027/swagger to interact with the API endpoints and test the CRUD operations.
