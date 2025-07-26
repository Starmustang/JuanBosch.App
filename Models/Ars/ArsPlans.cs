using JuanBosch.App.Models.Patients;

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

        public int ArsEnsuranceId { get; set; }
        public  ArsEnsurance ArsEnsurance { get; set; }

        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
               
    }
}