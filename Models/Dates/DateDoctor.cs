using JuanBosch.App.Models.MedicEvaluations;

namespace JuanBosch.App.Models.Dates
{
    public class DateDoctor
    {
        public int DateDoctorId { get; set; }
        public string DateDoctorSintoms { get; set; }
        public string DateDoctorIndicatedAnalisis { get; set; }
        public string DateDoctorTreatment { get; set; }
        public string DateDoctorNotes { get; set; }
        public DateTime DateDoctorNextDate { get; set; }
        public ICollection<DateMedic> DateMedics { get; set; } = new List<DateMedic>();
        public MedicEvaluation MedicEvaluation { get; set; }
        public int MedicEvaluationId { get; set; }
    }
}