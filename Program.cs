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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
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
    var dbUrl = Environment.GetEnvironmentVariable("MYSQL_URL");
    if (!string.IsNullOrEmpty(dbUrl))
    {
        var uri = new Uri(dbUrl);
        var dbHost = uri.Host;
        var dbPort = uri.Port;
        var userInfo = uri.UserInfo.Split(':');
        var dbUser = userInfo[0];
        var dbPassword = userInfo[1];
        var dbName = uri.AbsolutePath.Trim('/');

        connectionString = $"Server={dbHost};Port={dbPort};Database={dbName};User={dbUser};Password={dbPassword};";
    }
}
else
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

// Log the connection string for debugging.
// WARNING: This may log sensitive information. Remove this in a production environment once the issue is resolved.
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Using connection string: {ConnectionString}", connectionString);

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
    
    // Handle migrations based on environment
    var environment = app.Environment;
    
    if (environment.IsDevelopment())
    {
        // In development, always try to migrate
        db.Database.Migrate();
    }
    else
    {
        // In production, be more careful with migrations
        var pendingMigrations = db.Database.GetPendingMigrations();
        if (pendingMigrations.Any())
        {
            Console.WriteLine($"Found {pendingMigrations.Count()} pending migrations.");
            try
            {
                db.Database.Migrate();
                Console.WriteLine("Migrations applied successfully.");
            }
            catch (MySqlConnector.MySqlException ex) when (ex.Message.Contains("already exists"))
            {
                Console.WriteLine($"Warning: {ex.Message}");
                Console.WriteLine("Database tables already exist. This might indicate the migration history is out of sync.");
                Console.WriteLine("Consider manually updating the __EFMigrationsHistory table.");
            }
        }
        else
        {
            Console.WriteLine("Database is up to date.");
        }
    }

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
    await Seed.SeedUsers(userManager, roleManager);
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
