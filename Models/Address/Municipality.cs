namespace JuanBosch.App.Models.Address
{
    public class Municipality
    {
        public int MunicipalityId { get; set; }
        public string MunicipalityName { get; set; } = string.Empty;
        public int ProvinceId { get; set; }
        public Province? Province { get; set; }
        public ICollection<Sector> Sectors { get; set; } = new List<Sector>();
    }
}
