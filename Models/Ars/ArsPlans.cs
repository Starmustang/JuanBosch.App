namespace JuanBosch.App.Models.Ars
{
    public class ArsPlans
    {
        public int ArsPlansEnsuranceId { get; set; }
        public string AfiliationNumberArs {get; set;}
        public string ArsPlansName { get; set; } = string.Empty;
        public string CoveragePlanArs {get; set;}
        public Boolean InternationalCoverage {get; set;}
        public Boolean IsPlanActive {get; set;}
        public string MaxLimitArs {get; set;}
    }
}