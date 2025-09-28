using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Dtos.Country;
using JuanBosch.App.Mapper.AddressMapper;
using JuanBosch.App.Models.Address;
using JuanBosch.App.Models.Persistence;
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
        
        public async Task<List<CountryReadDto>> GetAllCountriesAsync()
        {
            return await _context.Countries
                .Select(c => CountryMapper.ToReadCountry(c))
                .ToListAsync();
        }
        
        public async Task<CountryReadDto?> GetCountryByIdAsync(int id)
        {
            return await _context.Countries
                .Where(c => c.CountryId == id)
                .Select(c => CountryMapper.ToReadCountry(c))
                .FirstOrDefaultAsync();
        }
        
        public async Task<CountryReadDto> CreateCountryAsync(CountryCreateDto country)
        {
            var entity = country.ToCreateCountry();
            _context.Countries.Add(entity);
            await _context.SaveChangesAsync();
            return await GetCountryByIdAsync(entity.CountryId)
                   ?? throw new InvalidOperationException("Failed to retrieve created country");
        }
        
        public async Task<CountryReadDto?> UpdateCountryAsync(int id, CountryUpdateDto country)
        {
            var existingCountry = await _context.Countries.FindAsync(id);
            if (existingCountry == null)
            {
                return null;
            }
            existingCountry.CountryName = country.CountryName;
            existingCountry.CountryLanguage = country.CountryLanguage;
            existingCountry.CountryCurrency = country.CountryCurrency;
            await _context.SaveChangesAsync();
            return await GetCountryByIdAsync(id);
        }
        
        public async Task<bool> DeleteCountryAsync(int id)
        {
            var existingCountry = await _context.Countries.FindAsync(id);
            if (existingCountry == null)
            {
                return false;
            }
            _context.Countries.Remove(existingCountry);
            await _context.SaveChangesAsync();
            return true;
        }
        
    }
}