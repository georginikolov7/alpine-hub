# AlpineHub

AlpineHub is an ASP.NET Core 8 solution for managing and browsing ski resort data (slopes, lifts, passes, and related user flows).  
The repository contains:

- `AlpineHub.Web`: MVC web application (UI + Identity)
- `AlpineHub.WebApi`: REST API with Swagger in development
- `AlpineHub.Data`: EF Core data access and migrations
- supporting class libraries in `AlpineHub.Core`, `AlpineHub.Common`, `AlpineHub.Web.Infrastructure`, and view model/data model projects

## Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker](https://www.docker.com/) (recommended for local SQL Server)
- Optional: `dotnet-ef` CLI tool

Install EF CLI tool if needed:

```bash
dotnet tool install --global dotnet-ef
```

## Local Setup

### 1) Clone and open the solution

```bash
git clone <your-repo-url>
cd AlpineHub
```

### 2) Configure SQL Server password for Docker

Copy the sample env file and set a strong SQL SA password:

```bash
cp .env.sample .env
```

Set `MSSQL_SA_PASSWORD` in `.env`.

### 3) Start the database

```bash
docker compose up -d
```

This starts SQL Server on `localhost:1433`.

### 4) Configure app settings

For the MVC app:

```bash
cp AlpineHub.Web/appsettings.example.json AlpineHub.Web/appsettings.Development.json
```

Then update `AlpineHub.Web/appsettings.Development.json`:

- `ConnectionStrings:DefaultConnection` (match your SQL credentials)
- `Identity:Admin` values (admin seed account in Development)

For the API app, update `AlpineHub.WebApi/appsettings.Development.json`:

- `ConnectionStrings:DefaultConnection`
- `ClientOrigins:AlpineHub` (should match MVC app URL, defaults to `https://localhost:7040`)

### 5) Apply database migrations

From the solution root:

```bash
dotnet ef database update --project AlpineHub.Data --startup-project AlpineHub.Web
```

## Run the applications

### MVC web app

```bash
dotnet run --project AlpineHub.Web
```

Default local URL (HTTPS profile): `https://localhost:7040`

### Web API

```bash
dotnet run --project AlpineHub.WebApi
```

Default local URLs (HTTPS profile): `https://localhost:7103` and `http://localhost:5017`  
Swagger UI: `https://localhost:7103/swagger`

## Running tests

```bash
dotnet test AlpineHub.sln
```

## Notes

- In Development, the MVC app seeds an admin user on startup using `Identity:Admin` settings.
- Both apps use the same SQL Server connection by default.
- The API enables CORS in Development and requires `ClientOrigins:AlpineHub` to be set.
