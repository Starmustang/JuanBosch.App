using JuanBosch.App.Models.Doctors;
using JuanBosch.App.Models.Patients;

namespace JuanBosch.App.Models.PatientsDoctors
{
    public class PatientsDoctor
    {
        public int PatientDoctorId { get; set; }
        public int PatientId { get; set; }
        public  Patient Patient { get; set; }        
        public int DoctorId { get; set; }
        public DoctorMedic DoctorMedic { get; set; }
    }
}