using JuanBosch.App.Models.Doctors;
using JuanBosch.App.Models.Patients;

namespace JuanBosch.App.Models.MedicRecords
{
    public class MedicRecord
    {
        public int RecordId { get; set; }
        public required Patient Patient { get; set; }
        public int PatientId { get; set; }
        public DoctorMedic? DoctorsMedics { get; set; }
        public int DoctorId { get; set; }
        public string? FollowUpMedicRecord { get; set; }
        public string? SignsMedicRecord { get; set; }
    }
}