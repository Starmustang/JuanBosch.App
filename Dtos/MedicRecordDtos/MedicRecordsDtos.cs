namespace JuanBosch.App.Dtos.MedicRecordDtos
{
    public class MedicRecordReadDto
    {
        public int RecordId { get; set; }
        public string? PatientName { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string? FollowUpMedicRecord { get; set; }
        public string? SignsMedicRecord { get; set; }
    }

    public class MedicRecordUpdateDto
    {
        public int RecordId { get; set; }
        public string? PatientName { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string? FollowUpMedicRecord { get; set; }
        public string? SignsMedicRecord { get; set; }
    }

    public class MedicRecordCreateDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string? FollowUpMedicRecord { get; set; }
        public string? SignsMedicRecord { get; set; }
    }
}