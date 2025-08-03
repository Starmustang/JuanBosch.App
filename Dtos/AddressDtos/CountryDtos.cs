namespace JuanBosch.App.Dtos.Country
{
    public class CountryCreateDto
    {
        public string CountryName { get; set; } = string.Empty;
        public string CountryLanguage { get; set; } = string.Empty;
        public string CountryCurrency { get; set; } = string.Empty;
    }

    public class CountryReadDto
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public string CountryLanguage { get; set; } = string.Empty;
        public string CountryCurrency { get; set; } = string.Empty;
        
    }

    public class CountryUpdateDto
    {
        public string CountryName { get; set; } = string.Empty;
        public string CountryLanguage { get; set; } = string.Empty;
        public string CountryCurrency { get; set; } = string.Empty;
    }

    public class CountryListDto
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public int ProvinceCount { get; set; }
    }
}