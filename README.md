# EfCoreFluentDemo

A simple sample project using **Entity Framework Core** with **Fluent API** on **SQL Server LocalDB**.

This project:
- Defines a `User` entity.
- Uses `AppDbContext` to connect to the database.
- Uses EF Core migrations to create and update the database schema.

---

## Prerequisites

- .NET SDK (8 or higher)
- SQL Server Express or LocalDB  
  This project uses LocalDB with the following connection string:

```csharp
Server=(localdb)\MSSQLLocalDB;Database=EfFluentDemoDb;Trusted_Connection=True;
```

- EF Core CLI tools:

```bash
dotnet tool install --global dotnet-ef
```

---

## Migration Commands

All commands should be run from the project folder (where the `.csproj` file is located).

### 1. Add the first migration

After defining `User` and `AppDbContext`:

```bash
dotnet ef migrations add InitialCreate
```

This will:
- Create a `Migrations` folder
- Generate the migration code to create the tables

### 2. Apply migrations to the database

```bash
dotnet ef database update
```

This will:
- Create the `EfFluentDemoDb` database on `(localdb)\MSSQLLocalDB` (if it does not exist)
- Create the `hive` schema and the `Users` table

---

## Updating the Model

Whenever you change the model or Fluent API configuration (for example, adding a new property/column):

1. Update your entity and/or `OnModelCreating`.
2. Add a new migration:

```bash
dotnet ef migrations add SomeChangeName
```

3. Update the database:

```bash
dotnet ef database update
```

---

## Running the Project

Build and run:

```bash
dotnet build
dotnet run
```

The app will:
- Create an instance of `AppDbContext`
- Connect to the database
- Optionally insert or query `User` records (depending on your `Program.cs` code)

---

## Viewing the Database in SSMS

To inspect the database using SQL Server Management Studio (SSMS):

- **Server name**:
  ```text
  (localdb)\MSSQLLocalDB
  ```
- Connect using **Windows Authentication**
- Right-click on **Databases** → **Refresh**
- Look for the database: `EfFluentDemoDb`
- Example query:

```sql
SELECT * FROM dbo.Users;
```
