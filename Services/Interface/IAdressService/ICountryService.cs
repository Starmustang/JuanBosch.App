using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Dtos.Country;

namespace JuanBosch.App.Services.Interface
{
    public interface ICountryService
    {
        Task<List<CountryReadDto>> GetAllCountriesAsync();
        Task<CountryReadDto?> GetCountryByIdAsync(int id);
        Task<CountryReadDto> CreateCountryAsync(CountryCreateDto country);
        Task<CountryReadDto?> UpdateCountryAsync(int id, CountryUpdateDto country);
        Task<bool> DeleteCountryAsync(int id);
    }
}