namespace JuanBosch.App.Dtos.AddressDtos
{
    public class ProvinceCreateDto
    {        
        public string ProvinceName { get; set; } = string.Empty;
        public int CountryId { get; set; }
    }

    public class ProvinceReadDto
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public string? CountryName {get; set;}
    }

    public class ProvinceUpdateDto
    {
        public string ProvinceName { get; set; } = string.Empty;
        public int CountryId { get; set; }
    }

    public class ProvinceListDto
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; } = string.Empty;        
    }
}