# Coding Challenge Tasks API App

Simple ASP.NET Core Web API that manages tasks using Dapper and SQL Server.

## What it does
- Provides CRUD endpoints for a `Tasks` table in a SQL Server database.
- Uses Dapper for lightweight data access via `DataContextDapper`.
- Includes endpoints in `TaskController` for testing connection and managing tasks.

## Endpoints
- `GET /Task/TestConnection` - returns database server time.
- `GET /Task/GetTasks` - returns all tasks.
- `GET /Task/GetSingleTask/{taskId}` - returns a single task.
- `PUT /Task/EditTask` - updates a task status (expects JSON `EditStatusTaskDto`).
- `POST /Task/AddTask` - adds a new task (expects JSON `TaskToAddDto`).
- `DELETE /Task/DeleteTask/{taskId}` - deletes a task.

Swagger UI is available when running (Swashbuckle is included), typically at `/swagger`.

## Prerequisites
- .NET SDK 10.0 (match the `TargetFramework` net10.0 in the project).
- SQL Server instance and a database with a `dbo.Tasks` table matching the model used in `HMCTSTask`.

## Configuration
1. Update the connection string named `DefaultConnection` in `appsettings.json` (or `appsettings.Development.json`) to point to your SQL Server instance. Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=MyTasksDb;User Id=sa;Password=your_password;TrustServerCertificate=True;"
}
```

## Run
From the project root (where `CodeChallenge.csproj` lives):

```bash
dotnet run
```

The app will start and print the listening URL(s). Use those to call the endpoints or open `/swagger`.

## Testing endpoints (examples)
- Test DB connection:

```bash
curl http://localhost:5000/Task/TestConnection
```

- Get tasks:

```bash
curl http://localhost:5000/Task/GetTasks
```

## Dependencies
- Dapper
- Microsoft.Data.SqlClient
- Swashbuckle.AspNetCore (Swagger)
