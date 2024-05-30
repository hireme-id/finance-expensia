# Finance.Expensia
.NET 8 Web API & MVC Project for Finance Expensia

## Installation of .NET 8 SDK RUNTIMES
1. Download .NET 8 SDK and runtimes from the following link:
   ```
   https://dotnet.microsoft.com/en-us/download/dotnet/8.0
   ```

## Documentation To Learn
1. Read anything about Entity Framework Core at https://www.learnentityframeworkcore.com/
2. Read anything about AutoMapper at https://automapper.org/
3. Read anything about FluentValidation at https://fluentvalidation.net/

## Configuration
1. Open the "Finance.Expensia.Web/appsettings.json" file and update the connection string.

## Data Seeding
1. Open Visual Studio
2. Go to Extensions > Manage Extensions
3. Search "Insert Guid" that created by Mads Kristensen
4. To use this extension use this shortcut
   ```
   Ctrl + K, Ctrl + Space
   ```
5. That will insert a GUID exactly in the point you are in the code

## Migration Database
1. Open Visual Studio
2. Set the "Finance.Expensia.Web" as the startup project.
3. Open the Package Manager Console.
4. Run the following command to add new migration:
   ```
   Add-Migration -s Finance.Expensia.Web -p Finance.Expensia.DataAccess -c ApplicationDbContext
   ```
5. Start "Finance.Expensia.Web" project to create the database.

## Running the Project (For Web API Please Make Sure Container "golfdb" in Docker already Running)
1. Open the "Finance.Expensia.sln" solution file in Visual Studio 2022 or newer.
2. To run the this solution, select "Finance.Expensia.Web" and choose to run with or without debugging.