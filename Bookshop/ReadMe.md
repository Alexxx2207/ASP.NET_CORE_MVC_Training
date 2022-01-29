# Web application for adding and <br /> listing books from database.

## Application structure

#### &nbsp;Sub projects:
- Bookshop.Models - defines entites for database and DTOs
- Bookshop.Data - defines database with ORM and contains migrations
- Bookshop.Common - defines constants, used across the projects
- Bookshop.Infrastructure - defines custom instruments like model binders & validation attributes
- Bookshop.Services - defines logic. Access database.
- Bookshop.Web - defines MVC project. Contains views, input models, controllers, static files, middlewares definition, DI container definition and configuration files.

## About database connection
#### Set connection string for the database in appsettings.json/appsettings.Development.json in Bookshop.Web subproject

> :warning: The connection string from the appsettings.Development.json in Bookshop.Data is your connection string for the database. It should be the same with the one in appsettings.json/appsettings.Development.json in Bookshop.Web subproject.

## How to start application

### First apply migrations 
- Open solution explorer

![Solution Explorer](https://github.com/Alexxx2207/ASP.NET_CORE_MVC_Training/blob/main/Bookshop/ReadMeImages/SolutionExplorer.jpg)





