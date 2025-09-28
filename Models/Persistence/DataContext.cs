using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using JuanBosch.App.Models.Address;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JuanBosch.App.Models.Patients;
using JuanBosch.App.Models.MedicEvaluations;
using JuanBosch.App.Models.Dates;
using JuanBosch.App.Models.Bloods;
using JuanBosch.App.Models.MedicRecords;
using JuanBosch.App.Models.Ars;
using JuanBosch.App.Models.Doctors;
using JuanBosch.App.Models.Users;

namespace JuanBosch.App.Models.Persistence
{
    public class DataContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        // Existing entities
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<PatientDirection> PatientDirections { get; set; } = null!;
        public DbSet<Municipality> Municipalities { get; set; } = null!;
        public DbSet<Sector> Sectors { get; set; } = null!;
        public DbSet<DoctorAddress> DoctorAddresses { get; set; } = null!;
        public DbSet<Province> Provinces { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<DateDoctor> DateDoctors { get; set; } = null!;
        public DbSet<MedicEvaluation> MedicEvaluations { get; set; } = null!;
        public DbSet<DateMedic> DateMedics { get; set; } = null!;
        public DbSet<Blood> Bloods { get; set; } = null!;
        public DbSet<MedicRecord> MedicRecords { get; set; } = null!;
        public DbSet<ArsEnsurance> ArsEnsurances { get; set; } = null!;
        public DbSet<ArsPlans> ArsPlans { get; set; } = null!;
        public DbSet<DoctorMedic> Doctors { get; set; } = null!;
        public DbSet<DoctorEnsurance> DoctorEnsurances { get; set; } = null!;

        // Identity and User-related entities
        public DbSet<UserProfile> UserProfiles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Apply all configurations from the current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}