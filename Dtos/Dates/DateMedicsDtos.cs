namespace JuanBosch.App.Dtos.Dates
{
    public class DateMedicCreateDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateMedicDate { get; set; }
        public string? HospitalMedicDate { get; set; }
        public int ConsultationTypeId { get; set; }
        public int DateDoctorId { get; set; }
    }
    
    public class DateMedicReadDto
    {
        public int DateMedicId { get; set; }
        public int PatientId { get; set; }
        public required string PatientName { get; set; }
        public int DoctorId { get; set; }
        public required string DoctorName { get; set; }
        public DateTime DateMedicDate { get; set; }
        public string? HospitalMedicDate { get; set; }
        public int ConsultationTypeId { get; set; }
        public int DateDoctorId { get; set; }
    }
    
    public class DateMedicUpdateDto
    {
        public int DateMedicId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateMedicDate { get; set; }
        public string? HospitalMedicDate { get; set; }
        public int ConsultationTypeId { get; set; }
        public int DateDoctorId { get; set; }
    }
}