
# EmployeeManagement CRUD Web App

This is fully functional CRUD web application.This web application is built on Dotnet Core 6 MVC using Entity Framework Core to make connection with 
MySQL Server for its CRUD functionality.

## Software Required
- 1)Visual Studio Code
- 2)Dotnet SDK 6
- 3)Entity Framework Core

```bash
    dotnet tool install --global dotnet-ef
```

## Tech Stack

**Database:** MySQL Server and Entity Framwork Core

**BackEnd and FrontEnd:** Dotnet Core MVC(Model,View and Controller)



## Run Locally

Clone the project

```bash
  git clone https://github.com/abhi790/EmpManagement.git
```

Go to the project directory

```bash
  cd EmpManagement
```

Create appsettings.json

```bash
  touch appsettings.json
```
Add code inside appsettings.json, modify username and password with your MySql credentials in connection string

```json
    {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "mySqlConn":"server=localhost; port=3306; database=EmployeeDB; user=<username>; password=<yourPass>; Persist Security Info=False; Connect Timeout=300"
    
  },
  "AllowedHosts": "*"
}
```

Now run 

```bash
  dotnet restore
  dotnet build
```

Now Add Migration command 

```bash
  dotnet ef migrations add Initial_migration  //to add migrations
  dotnet ef database update  		   // to update the database
```

Finally run and open metion port number to see app working. Enjoy.

```bash
  dotnet run
```
# Screenshot Of Web Application

## List All Employees

![List Employees](https://user-images.githubusercontent.com/64580344/212389674-46e0634b-8ebd-42a3-b548-6a2c28f00f3b.png)



## Create An Employee

![Create Employee](https://user-images.githubusercontent.com/64580344/212390064-e3aabf48-6e11-4921-9f1c-385fb097949a.png)


## Edit An Employee

![Edit](https://user-images.githubusercontent.com/64580344/212390865-8a7132e0-36fa-4bf3-b2b9-d5c4df5388a1.jpeg)





