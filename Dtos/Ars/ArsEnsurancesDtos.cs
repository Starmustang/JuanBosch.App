namespace JuanBosch.App.Dtos.Ars
{
    public class ArsEnsurancesReadDto
    {
        public int ArsEnsuranceId { get; set; }
        public string EnsuranceName { get; set; }
        public string EnsuranceDirection { get; set; }
        public string EnsurancePhone { get; set; }
        public string? EnsurancePhone2 { get; set; }
        public string? EnsuranceFax { get; set; }
        public string? EnsuranceEmail { get; set; }
        public DateTime EnsuranceUpdateDate { get; set; }
        public TimeOnly EnsuranceSchedule { get; set; }
    }

    public class ArsEnsurancesUpdateDto
    {
        public int ArsEnsuranceId { get; set; }
        public required string EnsuranceName { get; set; }
        public required string EnsuranceDirection { get; set; }
        public required string EnsurancePhone { get; set; }
        public string? EnsurancePhone2 { get; set; }
        public string? EnsuranceFax { get; set; }
        public string? EnsuranceEmail { get; set; }
        public DateTime EnsuranceUpdateDate { get; set; }
        public TimeOnly EnsuranceSchedule { get; set; }
    }

    public class ArsEnsurancesCreateDto
    {
        public required string EnsuranceName { get; set; }
        public required string EnsuranceDirection { get; set; }
        public required string EnsurancePhone { get; set; }
        public string? EnsurancePhone2 { get; set; }
        public string? EnsuranceFax { get; set; }
        public string? EnsuranceEmail { get; set; }
        public DateTime EnsuranceUpdateDate { get; set; }
        public TimeOnly EnsuranceSchedule { get; set; }
    }
}