using JuanBosch.App.Models.Address;

namespace JuanBosch.App.Services.Interface
{
    public interface ICountryService
    {
        Task<List<Country>> GetAllCountriesAsync();
        Task<Country> GetCountryByIdAsync(int id);
        Task<Country> CreateCountryAsync(Country country);
        Task<Country> UpdateCountryAsync(int id, Country country);
        Task<bool> DeleteCountryAsync(int id);
    }
}