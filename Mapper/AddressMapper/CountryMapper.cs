using JuanBosch.App.Dtos.Country;
using JuanBosch.App.Models.Address;

namespace JuanBosch.App.Mapper.AddressMapper
{
    public static class CountryMapper
    {
        public static Country ToCreateCountry(this CountryCreateDto countryCreateDto)
        {
            if (countryCreateDto == null)
            {
                throw new ArgumentNullException(nameof(countryCreateDto));
            }
            return new Country
            {
                CountryName = countryCreateDto.CountryName,
                CountryLanguage = countryCreateDto.CountryLanguage,
                CountryCurrency = countryCreateDto.CountryCurrency
            };
        }

        public static CountryReadDto ToReadCountry(this Country country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            return new CountryReadDto
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName,
                CountryLanguage = country.CountryLanguage,
                CountryCurrency = country.CountryCurrency
            };
        }

        public static Country ToUpdateCountry(this CountryUpdateDto countryUpdateDto, int countryId)
        {
            if (countryUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(countryUpdateDto));
            }
            return new Country
            {
                CountryId = countryId,
                CountryName = countryUpdateDto.CountryName,
                CountryLanguage = countryUpdateDto.CountryLanguage,
                CountryCurrency = countryUpdateDto.CountryCurrency
            };
        }

        public static CountryListDto ToListCountry(this Country country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            return new CountryListDto
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName,
                ProvinceCount = country.Provinces?.Count ?? 0
            };
        }
    }
}