using JuanBosch.App.Models.Address;
using JuanBosch.App.Models.DataContext;
using JuanBosch.App.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace JuanBosch.App.Services
{
    public class CountryService : ICountryService
    {
        private readonly DataContext _context;
        public CountryService(DataContext context)
        {
            _context = context;
        }
        
        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }
        
        public async Task<Country> GetCountryByIdAsync(int id)
        {
            return await _context.Countries.FindAsync(id);
        }
        
        public async Task<Country> CreateCountryAsync(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return country;
        }
        
        public async Task<Country> UpdateCountryAsync(int id, Country country)
        {
            var existingCountry = await _context.Countries.FindAsync(id);
            if (existingCountry == null)
            {
                throw new ArgumentNullException(nameof(existingCountry));
            }
            existingCountry.CountryName = country.CountryName;
            existingCountry.CountryLanguage = country.CountryLanguage;
            existingCountry.CountryCurrency = country.CountryCurrency;
            await _context.SaveChangesAsync();
            return country;
        }
        
        public async Task<bool> DeleteCountryAsync(int id)
        {
            var existingCountry = await _context.Countries.FindAsync(id);
            if (existingCountry == null)
            {
                throw new ArgumentNullException(nameof(existingCountry));
            }
            _context.Countries.Remove(existingCountry);
            await _context.SaveChangesAsync();
            return true;
        }
        
    }
}