using JuanBosch.App.Models.Doctors;
using JuanBosch.App.Models.Patients;
using JuanBosch.App.Models.Consultation;
using JuanBosch.App.Models.Enums;
using ConsultationType = JuanBosch.App.Models.Enums.ConsultationType;

namespace JuanBosch.App.Models.Dates
{
    public class DateMedic
    {
        public int DateMedicId { get; set; }
        public required Patient Patient { get; set; }
        public int PatientId { get; set; }
        public required DoctorMedic Doctor { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateMedicDate { get; set; }
        public required string HospitalMedicDate { get; set; }
        public ConsultationType ConsultationType { get; set; }
        public required DateDoctor DateDoctor { get; set; }
        public int DateDoctorId { get; set; }

       
    }
}