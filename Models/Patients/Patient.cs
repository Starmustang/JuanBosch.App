using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JuanBosch.App.Models.Ars;
using JuanBosch.App.Models.Bloods;
using JuanBosch.App.Models.Dates;
using JuanBosch.App.Models.MedicRecords;

namespace JuanBosch.App.Models.Patients
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string PatientLastName { get; set; } = string.Empty;
        public string? PatientIdCard { get; set; }
        public string? PatientPassport { get; set; }
        public DateOnly? PatientBirthDate { get; set; }
        public string? PatientGender { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientPhone { get; set; }
        public int ArsPlansId { get; set; }
        public ArsPlans ArsPlans { get; set; }
        public int? AddressId { get; set; }
        public PatientDirection? PatientDirection { get; set; }
        public string PatientEmergencieContact { get; set; }

        public string PatientFisRecord { get; set; }
        public int BloodId { get; set; }
        public Blood Blood { get; set; }
        public MedicRecord MedicRecord { get; set; }   

        public ICollection<DateMedic> DateMedics { get; set; } = new List<DateMedic>();

    }
}