# Web application for adding to and listing from <br /> database books and authors.

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

## How to start the application

### First apply migrations 
- Open solution explorer --> (right click)Bookshop.Data --> Open in Terminal
![Solution Explorer](https://github.com/Alexxx2207/ASP.NET_CORE_MVC_Training/blob/main/Bookshop/ReadMeImages/SolutionExplorer.png "Solution Explorer")

- Write the command in the red rectangle --> expect the result in green
- ![PowerShell](https://github.com/Alexxx2207/ASP.NET_CORE_MVC_Training/blob/main/Bookshop/ReadMeImages/PowerShell.png "PowerShell")

> :warning: If the result in the PowerShell is not the same, check your connection string. Is it available? Read the red error you will receive in the PowerShell.

## :warning: Important notes :warning:
- The model binding provider will invoke custom model binder on Pages propertyokInputModel. The explicit input of the ModelBinder Attribute isn't necessary.
- Also the custom model binder will add 2 to the pages inserted in adding book form.





