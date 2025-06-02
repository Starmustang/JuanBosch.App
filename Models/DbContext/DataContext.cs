using Microsoft.EntityFrameworkCore;
using JuanBosch.App.Models.Address;

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
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}