using Microsoft.EntityFrameworkCore;
using JuanBosch.App.Models.Address;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JuanBosch.App.Models.Patients;
using JuanBosch.App.Models.MedicEvaluations;
using JuanBosch.App.Models.Dates;

namespace JuanBosch.App.Models.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientDirection> PatientDirections { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<DoctorAddress> DoctorAddresses { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<DateDoctor> DateDoctors { get; set; }
        public DbSet<MedicEvaluation> MedicEvaluations { get; set; }
        public DbSet<DateMedic> DateMedics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Apply all configurations from the current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}