namespace JuanBosch.App.Models.Address
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public string CountryLanguage { get; set; } = string.Empty;
        public string CountryCurrency { get; set; } = string.Empty;
        public ICollection<Province> Provinces { get; set; } = new List<Province>();
    }
}