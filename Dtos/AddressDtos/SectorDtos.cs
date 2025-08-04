namespace JuanBosch.App.Dtos.AddressDtos
{
    public class SectorCreateDto
    {
        public string SectorName { get; set; } = string.Empty;
        public int MunicipalityId { get; set; }
    }

    public class SectorReadDto
    {
        public int SectorId { get; set; }
        public string SectorName { get; set; } = string.Empty;
        public int MunicipalityId { get; set; }
        public string? MunicipalityName {get; set;}
    }

    public class SectorUpdateDto
    {
        public string SectorName { get; set; } = string.Empty;
        public int MunicipalityId { get; set; }
    }

    public class SectorListDto
    {
        public int SectorId { get; set; }
        public string SectorName { get; set; } = string.Empty;
        public int MunicipalityId { get; set; }
        public string? MunicipalityName {get; set;}
    }
}