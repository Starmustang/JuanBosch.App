# Hospital Juan Bosch API

ASP.NET Core 9 Web API for the Hospital Juan Bosch application. Provides endpoints for managing patients, doctors, medical records, appointments, addresses, ARS insurance, and user authentication.

---

## Requirements

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) (or MariaDB compatible with MySQL protocol)
- (Optional) [Docker](https://www.docker.com/) for containerized deployment

---

## Getting Started

### 1. Clone the Repository

```bash
git clone <repository-url>
cd JuanBosch.App
```

### 2. Configure the Database

Create a MySQL database for the application. Update the connection string in `appsettings.Development.json` or use environment variables.

**Default development connection string** (`appsettings.json`):
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=tesis2025;User=root;Password=root;"
}
```

**Environment variables** (production - e.g., Railway, Render, Heroku):
- `MYSQL_URL`, `DATABASE_URL`, `JAWSDB_URL`, `JAWSDB_MARIA_URL`, or `CLEARDB_DATABASE_URL` (URL format)
- Or discrete variables: `MYSQLHOST`/`MYSQL_HOST`, `MYSQLPORT`/`MYSQL_PORT`, `MYSQLUSER`/`MYSQL_USER`, `MYSQLPASSWORD`/`MYSQL_PASSWORD`, `MYSQLDATABASE`/`MYSQL_DATABASE`

### 3. Configure JWT Secret

The API uses JWT Bearer authentication. Provide a signing key via:

- `appsettings.Development.json`:
  ```json
  "Jwt": {
    "Key": "your-very-long-secret-key-here-min-32-chars",
    "Issuer": "https://localhost:7229",
    "Audience": "https://localhost:7229"
  }
  ```
- Or environment variables: `Jwt__Key`, `JWT_KEY`

> **Note:** The key must be at least 32 characters long for HS256 security.

### 4. Run the Application

```bash
dotnet restore
dotnet run
```

The API will start and auto-migrate the database on launch. Default URLs:
- **API:** `http://localhost:5028`
- **Swagger UI (development):** `https://localhost:7229` or `http://localhost:5028`

---

## Project Structure

```
Controllers/      # API controllers (Patients, Doctors, Auth, etc.)
Data/             # Entity Framework DbContext and migrations
Dtos/             # Data Transfer Objects for requests/responses
Mapper/           # AutoMapper or manual mapping profiles
Models/           # Domain/entity models (Users, Persistence, etc.)
Services/         # Business logic and service implementations
Program.cs        # Application entry point, DI configuration, pipeline
```

---

## API Documentation

Once running in development mode, interactive documentation is available via **Swagger UI** at the application root (`/`).

---

## Docker

Build and run with Docker:

```bash
docker build -t juanbosch-api .
docker run -p 8080:8080 -e JWT_KEY=your-secret-key -e DATABASE_URL=mysql://... juanbosch-api
```

The Dockerfile exposes ports `8080` and `8081`.

---

## Main Features

- **Patient Management** - CRUD operations for patient records
- **Doctor Management** - Doctor profiles and addresses
- **Medical Records** - Patient medical history and evaluations
- **Appointments** - Date scheduling for medical consultations
- **Address Management** - Countries, provinces, municipalities, sectors
- **ARS Insurance** - ARS (Health Risk Administrator) and plan management
- **Authentication & Authorization** - JWT-based auth with ASP.NET Identity (roles: Admin, Doctor, User)
- **Database** - MySQL with Entity Framework Core and automatic migrations

---

## Technologies & NuGet Packages

- **.NET 9** ASP.NET Core Web API
- **Entity Framework Core 9** with Pomelo MySQL provider
- **ASP.NET Core Identity** for user/role management
- **JWT Bearer Authentication**
- **Swagger / OpenAPI** (Swashbuckle.AspNetCore)
- **Docker** support (Linux containers)

---

## Environment Variables Reference

| Variable | Description |
|----------|-------------|
| `JWT_KEY` / `Jwt__Key` | Secret key for JWT signing |
| `DATABASE_URL` / `MYSQL_URL` | MySQL connection URL |
| `MYSQLHOST` / `MYSQL_HOST` | Database host (discrete) |
| `MYSQLPORT` / `MYSQL_PORT` | Database port (default: 3306) |
| `MYSQLUSER` / `MYSQL_USER` | Database user |
| `MYSQLPASSWORD` / `MYSQL_PASSWORD` | Database password |
| `MYSQLDATABASE` / `MYSQL_DATABASE` | Database name |
| `FORCE_DB_RESET` | Set to `true` to force recreate the database (use with caution) |

---

## License

MIT License
