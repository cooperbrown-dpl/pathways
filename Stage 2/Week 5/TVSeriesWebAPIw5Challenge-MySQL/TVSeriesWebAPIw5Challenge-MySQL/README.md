# Switching from InMemory Database to MySQL (Entity Framework Core)

This project originally used the Entity Framework Core **InMemory database** for development and testing.  
To persist data and use a real database, it was switched to **MySQL**.

Below are the steps required to make that change.

------------------------------------------------------------
1. Install the MySQL EF Core Provider
------------------------------------------------------------

Install the Pomelo MySQL provider (the most commonly used provider for EF Core + MySQL):

    dotnet add package Pomelo.EntityFrameworkCore.MySql


------------------------------------------------------------
2. Replace the InMemory Database Configuration
------------------------------------------------------------

Originally the project used an in-memory database:

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("TestDb"));

This was replaced with the MySQL provider:

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseMySql(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
        ));


------------------------------------------------------------
3. Add a Connection String
------------------------------------------------------------

Add the MySQL connection string to appsettings.json:

    {
      "ConnectionStrings": {
        "DefaultConnection": "server=localhost;database=mydb;user=root;password=yourpassword"
      }
    }

Update the values as needed for your MySQL installation.


------------------------------------------------------------
4. Create and Apply Migrations
------------------------------------------------------------

Unlike the InMemory database, MySQL requires a database schema.

Create a migration:

    dotnet ef migrations add InitialCreate

Apply the migration to the database:

    dotnet ef database update

This creates the necessary tables in MySQL.


------------------------------------------------------------
5. Verify the Database Connection
------------------------------------------------------------

Start the application and ensure:

• MySQL server is running  
• The database exists  
• The connection string credentials are correct  

You can confirm tables were created using MySQL Workbench or the MySQL CLI.


------------------------------------------------------------
Summary
------------------------------------------------------------

Steps required to switch from InMemory to MySQL:

1. Install Pomelo.EntityFrameworkCore.MySql
2. Replace UseInMemoryDatabase() with UseMySql()
3. Add a MySQL connection string to appsettings.json
4. Run EF Core migrations to create the schema

No other changes to the application logic were required.