namespace JuanBosch.App.Dtos.Dates
{
    public class DateDoctorCreateDto
    {
        public string DateDoctorSintoms { get; set; } 
        public string DateDoctorIndicatedAnalisis { get; set; }
        public string DateDoctorTreatment { get; set; }
        public string DateDoctorNotes { get; set; }
        public DateTime DateDoctorNextDate { get; set; }
        public int MedicEvaluationId { get; set; }
    }
    
    public class DateDoctorReadDto
    {
        public int DateDoctorId { get; set; }
        public string DateDoctorSintoms { get; set; }
        public string DateDoctorIndicatedAnalisis { get; set; }
        public string DateDoctorTreatment { get; set; }
        public string DateDoctorNotes { get; set; }
        public DateTime DateDoctorNextDate { get; set; }
        public int MedicEvaluationId { get; set; }
    }
    
    public class DateDoctorUpdateDto
    {
        public int DateDoctorId { get; set; }
        public string DateDoctorSintoms { get; set; }
        public string DateDoctorIndicatedAnalisis { get; set; }
        public string DateDoctorTreatment { get; set; }
        public string DateDoctorNotes { get; set; }
        public DateTime DateDoctorNextDate { get; set; }
        public int MedicEvaluationId { get; set; }
    }
}