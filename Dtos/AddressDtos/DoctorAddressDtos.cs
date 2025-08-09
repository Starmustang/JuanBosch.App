namespace JuanBosch.App.Dtos.AddressDtos
{
    public class DoctorAddressReadDto
    {
        public int DoctorAddressId { get; set; }
        public required string DoctorHouseNumber { get; set; }
        public required string DoctorStreet { get; set; }
        public int SectorId { get; set; }
        public string SectorName { get; set; }
    }

    public class DoctorAddressUpdateDto
    {
        public int DoctorAddressId { get; set; }
        public required string DoctorHouseNumber { get; set; }
        public required string DoctorStreet { get; set; }
        public int SectorId { get; set; }        
    }

    public class DoctorAddressCreateDto
    {
        public required string DoctorHouseNumber { get; set; }
        public required string DoctorStreet { get; set; }
        public int SectorId { get; set; }        
    }
}