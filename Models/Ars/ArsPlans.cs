namespace JuanBosch.App.Models.Ars
{
    public class ArsPlans
    {
        public int ArsPlansId { get; set; }
        public required string AfiliationNumberArs { get; set; }
        public string ArsPlansName { get; set; } = string.Empty;
        public required string CoveragePlanArs { get; set; }
        public bool InternationalCoverage { get; set; }
        public bool IsPlanActive { get; set; }
        public required string MaxLimitArs { get; set; }
        
        // Foreign key for ArsEnsurance
        public int ArsEnsuranceId { get; set; }
        
        // Navigation property
        public required ArsEnsurance ArsEnsurance { get; set; }
    }
}