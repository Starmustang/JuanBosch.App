using JuanBosch.App.Models.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JuanBosch.App.Services;
using JuanBosch.App.Services.AddressService;
using JuanBosch.App.Services.ArsService;
using JuanBosch.App.Services.BloodService;
using JuanBosch.App.Services.DatesService;
using JuanBosch.App.Services.DoctorService;
using JuanBosch.App.Services.Interface;
using JuanBosch.App.Services.Interface.IAdressService;
using JuanBosch.App.Services.Interface.IArsService;
using JuanBosch.App.Services.Interface.IBloodService;
using JuanBosch.App.Services.Interface.IDateService;
using JuanBosch.App.Services.Interface.IDoctorService;
using JuanBosch.App.Services.Interface.IMedicEvaluationService;
using JuanBosch.App.Services.Interface.IMedicRecordService;
using JuanBosch.App.Services.MedicEvaluationService;
using JuanBosch.App.Services.MedicRecordService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql;
using System;
using JuanBosch.App.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Configure JWT using configuration or environment variables (Production safe)
var jwtKey = builder.Configuration["Jwt:Key"]
             ?? Environment.GetEnvironmentVariable("Jwt__Key")
             ?? Environment.GetEnvironmentVariable("JWT_KEY");

if (string.IsNullOrEmpty(jwtKey))
{
    // Warn but continue to avoid startup failure; requests that create tokens will fail if key is missing
    Console.WriteLine("WARNING: JWT signing key is not configured. Set 'Jwt:Key' or environment variable 'Jwt__Key'/'JWT_KEY'.");
    jwtKey = "__MISSING_JWT_KEY__"; // placeholder to avoid null exceptions
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// Configure Identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    // Password settings (customize as needed)
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;

    // User settings
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<DataContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IMedicEvaluationService, MedicEvaluationService>();
builder.Services.AddScoped<IMunicipalityService, MunicipalityService>();
builder.Services.AddScoped<ISectorService, SectorService>();
builder.Services.AddScoped<IPatientDirectionService, PatientDirectionService>();
builder.Services.AddScoped<IDoctorAddressService, DoctorAddressService>();
builder.Services.AddScoped<IProvinceService, ProvinceService>();
builder.Services.AddScoped<IBloodService, BloodService>();
builder.Services.AddScoped<IDateMedicService, DateMedicService>();
builder.Services.AddScoped<IMedicRecordsService, MedicRecordsService>();
builder.Services.AddScoped<IArsEnsuranceService, ArsEnsuranceService>();
builder.Services.AddScoped<IArsPlanService, ArsPlanService>();
builder.Services.AddScoped<IDoctorEnsuranceService, DoctorEnsuranceService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IRoleService, RoleService>();

string? connectionString = null;

if (builder.Environment.IsProduction())
{
    // Try URL-style env vars first (common on Railway/Render/Heroku)
    var dbUrl = Environment.GetEnvironmentVariable("MYSQL_URL")
                ?? Environment.GetEnvironmentVariable("DATABASE_URL")
                ?? Environment.GetEnvironmentVariable("JAWSDB_URL")
                ?? Environment.GetEnvironmentVariable("JAWSDB_MARIA_URL")
                ?? Environment.GetEnvironmentVariable("CLEARDB_DATABASE_URL");

    if (!string.IsNullOrEmpty(dbUrl))
    {
        try
        {
            var uri = new Uri(dbUrl);
            var dbHost = uri.Host;
            var dbPort = uri.Port <= 0 ? 3306 : uri.Port;
            var userInfo = uri.UserInfo.Split(':', 2);
            var dbUser = Uri.UnescapeDataString(userInfo[0]);
            var dbPassword = userInfo.Length > 1 ? Uri.UnescapeDataString(userInfo[1]) : string.Empty;
            var dbName = uri.AbsolutePath.Trim('/');

            connectionString = $"Server={dbHost};Port={dbPort};Database={dbName};User={dbUser};Password={dbPassword};SslMode=Preferred;";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to parse DB URL: {ex.Message}");
        }
    }

    // Fallback to discrete Railway-style vars
    if (string.IsNullOrEmpty(connectionString))
    {
        var dbHost = Environment.GetEnvironmentVariable("MYSQLHOST") ?? Environment.GetEnvironmentVariable("MYSQL_HOST");
        var dbPort = Environment.GetEnvironmentVariable("MYSQLPORT") ?? Environment.GetEnvironmentVariable("MYSQL_PORT") ?? "3306";
        var dbUser = Environment.GetEnvironmentVariable("MYSQLUSER") ?? Environment.GetEnvironmentVariable("MYSQL_USER");
        var dbPassword = Environment.GetEnvironmentVariable("MYSQLPASSWORD") ?? Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
        var dbName = Environment.GetEnvironmentVariable("MYSQLDATABASE") ?? Environment.GetEnvironmentVariable("MYSQL_DATABASE");

        if (!string.IsNullOrEmpty(dbHost) && !string.IsNullOrEmpty(dbUser) && !string.IsNullOrEmpty(dbName))
        {
            connectionString = $"Server={dbHost};Port={dbPort};Database={dbName};User={dbUser};Password={dbPassword};SslMode=Preferred;";
        }
    }
}

if (string.IsNullOrEmpty(connectionString))
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}

builder.Services.AddDbContext<DataContext>(options =>
{
    if (!string.IsNullOrEmpty(connectionString))
    {
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
});
   
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Hospital Juan Bosch API",
        Version = "v1",
        Description = "API for Hospital Juan Bosch application",
        Contact = new OpenApiContact
        {
            Name = "Hospital Juan Bosch",
            Email = "contact@hospitaljuanbosch.com"
        }
    });
});

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Environment: {Env}. DB configured: {DbConfigured}", app.Environment.EnvironmentName, !string.IsNullOrEmpty(connectionString));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hospital Juan Bosch API v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    
    // Handle migrations - force clean migration for fresh database
    var environment = app.Environment;
    bool migrationSuccessful = false;
    
    Console.WriteLine("Starting database migration process...");
    
    // TEMPORARY: Set to true to force database reset (remove after first deployment)
    bool forceReset = Environment.GetEnvironmentVariable("FORCE_DB_RESET") == "true";
    
    if (forceReset)
    {
        Console.WriteLine("FORCE_DB_RESET is enabled. Recreating database...");
        try
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database deleted successfully.");
        }
        catch (Exception deleteEx)
        {
            Console.WriteLine($"Warning: Could not delete database: {deleteEx.Message}");
        }
    }
    
    try
    {
        // Check if database exists and is empty (fresh reset scenario)
        var canConnect = db.Database.CanConnect();
        Console.WriteLine($"Database connection status: {canConnect}");
        
        if (canConnect)
        {
            var pendingMigrations = db.Database.GetPendingMigrations().ToList();
            var appliedMigrations = db.Database.GetAppliedMigrations().ToList();
            
            Console.WriteLine($"Applied migrations: {appliedMigrations.Count}");
            Console.WriteLine($"Pending migrations: {pendingMigrations.Count}");
            
            if (pendingMigrations.Any())
            {
                Console.WriteLine("Applying pending migrations...");
                foreach (var migration in pendingMigrations)
                {
                    Console.WriteLine($"- {migration}");
                }
                
                try
                {
                    db.Database.Migrate();
                    Console.WriteLine("All migrations applied successfully.");
                }
                catch (MySqlConnector.MySqlException ex) when (ex.Message.Contains("already exists"))
                {
                    Console.WriteLine($"Migration conflict detected: {ex.Message}");
                    Console.WriteLine("Attempting to mark migration as applied without executing...");
                    
                    // Mark the migration as applied manually
                    foreach (var pendingMigration in pendingMigrations)
                    {
                        try
                        {
                            var insertSql = $"INSERT IGNORE INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES ('{pendingMigration}', '9.0.0')";
                            db.Database.ExecuteSqlRaw(insertSql);
                            Console.WriteLine($"Marked migration '{pendingMigration}' as applied.");
                        }
                        catch (Exception markEx)
                        {
                            Console.WriteLine($"Failed to mark migration '{pendingMigration}' as applied: {markEx.Message}");
                        }
                    }
                    
                    Console.WriteLine("Migration history synchronized. Database should now be consistent.");
                    migrationSuccessful = true;
                }
            }
            else if (!appliedMigrations.Any())
            {
                Console.WriteLine("No migration history found. Creating database schema...");
                db.Database.Migrate();
                Console.WriteLine("Database schema created successfully.");
            }
            else
            {
                Console.WriteLine("Database is up to date.");
            }
            
            migrationSuccessful = true;
        }
        else
        {
            Console.WriteLine("Cannot connect to database. Creating database...");
            db.Database.Migrate();
            migrationSuccessful = true;
            Console.WriteLine("Database created and migrated successfully.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Migration error: {ex.Message}");
        Console.WriteLine($"Stack trace: {ex.StackTrace}");
        
        // In case of error, try to log more details
        try
        {
            var dbConnectionString = db.Database.GetConnectionString();
            Console.WriteLine($"Connection string (masked): {dbConnectionString?.Substring(0, Math.Min(50, dbConnectionString.Length))}...");
        }
        catch
        {
            Console.WriteLine("Could not retrieve connection string details.");
        }
    }
    
    // Only proceed with seeding if database is ready
    if (migrationSuccessful)
    {
        try
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            await Seed.SeedUsers(userManager, roleManager);
            await Seed.SeedData(db);
            Console.WriteLine("Database seeding completed successfully.");
        }
        catch (Exception seedEx)
        {
            Console.WriteLine($"Seeding failed: {seedEx.Message}");
        }
    }
    else
    {
        Console.WriteLine("Skipping database seeding due to migration issues.");
    }
}

// Respect X-Forwarded-* headers (Railway proxy) before HTTPS redirection
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
