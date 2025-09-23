namespace JuanBosch.App.Dtos.AddressDtos
{
    public class PatientDirectionCreateDto
    {
        public string HouseNumber { get; set; } = string.Empty;
        public string HouseStreet { get; set; } = string.Empty;
        public int SectorId { get; set; }
    }
    
    public class PatientDirectionReadDto
    {
        public int AddressId { get; set; }
        public string HouseNumber { get; set; } = string.Empty;
        public string HouseStreet { get; set; } = string.Empty;
        public int SectorId { get; set; }
        public string? SectorName {get; set;}        
        public string? MunicipalityName {get; set;}        
        public string? ProvinceName {get; set;}        
        public string? CountryName {get; set;}        
    }
    
    public class PatientDirectionUpdateDto
    {
        public int AddressId { get; set; }
        public string HouseNumber { get; set; } = string.Empty;
        public string HouseStreet { get; set; } = string.Empty;
        public int SectorId { get; set; }
    }        
    
}