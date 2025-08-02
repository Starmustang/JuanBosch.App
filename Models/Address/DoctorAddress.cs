using JuanBosch.App.Models.Doctors;

namespace JuanBosch.App.Models.Address
{
    public class DoctorAddress
    {
        public int DoctorAddressId { get; set; }
        public required string DoctorHouseNumber { get; set; }
        public required string DoctorStreet { get; set; }
        public int SectorId { get; set; }
        public required Sector Sector { get; set; }
        public ICollection<DoctorMedic> Doctors { get; set; } = new List<DoctorMedic>();
    }
}