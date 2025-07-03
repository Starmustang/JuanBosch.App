using JuanBosch.App.Models.Address;

namespace JuanBosch.App.Models
{
    public class PatientDirection
    {
        public int AddressId { get; set; }
        public string HouseNumber { get; set; } = string.Empty;
        public string HouseStreet { get; set; } = string.Empty;
        public int SectorId { get; set; }
        
        // Navigation properties
        public Sector? Sector { get; set; }
        public Patient? Patient { get; set; }
    }
}