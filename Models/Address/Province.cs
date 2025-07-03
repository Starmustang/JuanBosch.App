namespace JuanBosch.App.Models.Address
{
    public class Province
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public ICollection<Municipality> Municipalities { get; set; } = new List<Municipality>();
    }
}
