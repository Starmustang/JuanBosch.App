using System.ComponentModel.DataAnnotations;

namespace JuanBosch.App.Models.Address
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryLanguage { get; set; }
        public string CountryCurrency { get; set; }
    }
}