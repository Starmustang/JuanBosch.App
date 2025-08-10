namespace JuanBosch.App.Dtos.AddressDtos
{
    public class MunicipalityCreateDto
    {
        public string MunicipalityName { get; set; } = string.Empty;
        public int ProvinceId { get; set; }
    }

    public class MunicipalityReadDto
    {
        public int MunicipalityId { get; set; }
        public string MunicipalityName { get; set; } = string.Empty;
        public int ProvinceId { get; set; }
        public string? ProvinceName {get; set;}
    }

    public class MunicipalityUpdateDto
    {
        public string MunicipalityName { get; set; } = string.Empty;
        public int ProvinceId { get; set; }
    }

    public class MunicipalityListDto
    {
        public int MunicipalityId { get; set; }
        public string MunicipalityName { get; set; } = string.Empty;
        public int ProvinceId { get; set; }
        public string? ProvinceName {get; set;}
    }
}