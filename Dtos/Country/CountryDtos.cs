namespace JuanBosch.App.Dtos.Country
{
    public class CountryCreateDto
    {
        public string name { get; set; }
        public string language { get; set; }
        public string currency { get; set; }
    }

    public class CountryReadDto : CountryCreateDto
    {
        public int id { get; set; }
    }
}