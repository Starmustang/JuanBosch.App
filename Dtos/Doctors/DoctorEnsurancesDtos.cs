namespace JuanBosch.App.Dtos.Doctors
{
    public class DoctorEnsurancesReadDto
    {
        public int DoctorEnsuranceId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int ArsEnsuranceId { get; set; }
        public string EnsuranceName { get; set; }
        public string MedicCode { get; set; }
    }

    public class DoctorEnsurancesUpdateDto
    {
        public int DoctorEnsuranceId { get; set; }
        public int DoctorId { get; set; }        
        public int ArsEnsuranceId { get; set; }        
        public string MedicCode { get; set; }
    }

    public class DoctorEnsurancesCreateDto
    {
        public int DoctorId { get; set; }
        public int ArsEnsuranceId { get; set; }
        public string MedicCode { get; set; }
    }
}