namespace JuanBosch.App.Dtos.Patient
{
    public class AddressDto
    {
        public int? AddressId { get; set; }
        public int? SectorId { get; set; }
        public int? MunicipalityId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CountryId { get; set; }
    }

    public class PatientCreateDto
    {
        public string name { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string? idCard { get; set; }
        public string? passport { get; set; }
        public string? phone { get; set; }
        public string? gender { get; set; }
        public string? email { get; set; }
        public DateOnly? dateOfBirth { get; set; }
        
        // Address information
        public AddressDto? Address { get; set; }
    }

    public class PatientReadDto : PatientCreateDto
    {
        public int id { get; set; }
    }

    public class PatientUpdateDto : PatientCreateDto
    {
    }
}
