namespace JuanBosch.App.Dtos.Ars
{
    public class ArsPlanReadDto
    {
        public int ArsPlansId { get; set; }
        public required string AfiliationNumberArs { get; set; }
        public string ArsPlansName { get; set; } = string.Empty;
        public required string CoveragePlanArs { get; set; }
        public bool InternationalCoverage { get; set; }
        public bool IsPlanActive { get; set; }
        public required string MaxLimitArs { get; set; }
        public int ArsEnsuranceId { get; set; }
        public string EnsuranceName { get; set; }
    }

    public class ArsPlanUpdateDto
    {
        public int ArsPlansId { get; set; }
        public required string AfiliationNumberArs { get; set; }
        public string ArsPlansName { get; set; } = string.Empty;
        public required string CoveragePlanArs { get; set; }
        public bool InternationalCoverage { get; set; }
        public bool IsPlanActive { get; set; }
        public required string MaxLimitArs { get; set; }
        public int ArsEnsuranceId { get; set; }
    }

    public class ArsPlanCreateDto
    {
        public required string AfiliationNumberArs { get; set; }
        public string ArsPlansName { get; set; } = string.Empty;
        public required string CoveragePlanArs { get; set; }
        public bool InternationalCoverage { get; set; }
        public bool IsPlanActive { get; set; }
        public required string MaxLimitArs { get; set; }
        public int ArsEnsuranceId { get; set; }
    }
}