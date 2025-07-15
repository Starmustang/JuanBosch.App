namespace JuanBosch.App.Models.Address
{
    public class Sector
    {
        public int SectorId { get; set; }
        public string SectorName { get; set; } = string.Empty;
        public int MunicipalityId { get; set; }
        public Municipality? Municipality { get; set; }
        public ICollection<PatientDirection> PatientDirections { get; set; } = new List<PatientDirection>();
        public ICollection<DoctorAddress> DoctorAddresses { get; set; } = new List<DoctorAddress>();
    }
}
