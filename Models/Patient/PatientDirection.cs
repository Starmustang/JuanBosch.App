using JuanBosch.App.Models.Address;

namespace JuanBosch.App.Models
{
    public class PatientDirection
    {
        public int AddressId { get; set; }
        public string HouseNumber { get; set; } = string.Empty;
        public string HouseStreet { get; set; } = string.Empty;
        public int SectorId { get; set; }

        public int MunicipalityId { get; set; }
        public int ProvinceId { get; set; }
        public int CountryId { get; set; }
        
        // Navigation properties
        public Sector? Sector { get; set; }
        public Patient? Patient { get; set; }
        public Municipality? Municipality { get; set; }
        public Province? Province { get; set; }
        public Country? Country { get; set; }
    }
}