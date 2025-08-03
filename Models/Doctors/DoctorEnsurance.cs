using JuanBosch.App.Models.Ars;

namespace JuanBosch.App.Models.Doctors
{
    public class DoctorEnsurance
    {
        public int DoctorEnsuranceId { get; set; }
        public DoctorMedic DoctorMedic { get; set; }
        public int DoctorId { get; set; }
        public ArsEnsurance ArsEnsurance { get; set; }
        public int ArsEnsuranceId { get; set; }
        public string MedicCode { get; set; }
    }
}