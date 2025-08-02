using JuanBosch.App.Models.Doctors;
using JuanBosch.App.Models.Patients;
using JuanBosch.App.Models.Consultation;

namespace JuanBosch.App.Models.Dates
{
    public class DateMedic
    {
        public int DateMedicId { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public DoctorMedic Doctor { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateMedicDate { get; set; }
        public string HospitalMedicDate { get; set; }
        public int ConsultationTypeId { get; set; }
        public ConsultationType ConsultationType { get; set; }
        public DateDoctor DateDoctor { get; set; }
        public int DateDoctorId { get; set; }

       
    }
}