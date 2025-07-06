namespace JuanBosch.App.Models.MedicEvaluation
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

    }
}