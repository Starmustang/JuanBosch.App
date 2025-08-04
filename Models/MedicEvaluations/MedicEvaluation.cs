using JuanBosch.App.Models.Dates;

namespace JuanBosch.App.Models.MedicEvaluations
{
    public class MedicEvaluation
    {
        public int MedicEvaluationId { get; set; }        
        public int WeightEva { get; set; }
        public int PresurreEva { get; set; }
        public int BreathingEva { get; set; }
        public string HeartRateEva { get; set; }
        public string OtherInfoEva { get; set; }
        public string HeightEva { get; set; }
        public string PreviousSickNessEva { get; set; }
        public int DateDoctorId { get; set; }
        public DateDoctor DateDoctor { get; set; }

    }
}