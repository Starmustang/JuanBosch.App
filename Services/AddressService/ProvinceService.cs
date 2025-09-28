using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Mapper.AddressMapper;
using JuanBosch.App.Models.Address;
using JuanBosch.App.Models.Persistence;
using JuanBosch.App.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace JuanBosch.App.Services.AddressService
{
    public class ProvinceService : IProvinceService
    {
        private readonly DataContext _context;

        public ProvinceService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ProvinceReadDto>> GetAllProvincesAsync()
        {
            return await _context.Provinces
                .Include(p => p.Country)
                .Select(p => ProvinceMapper.ToReadProvince(p))
                .ToListAsync();
        }

        public async Task<List<ProvinceListDto>> GetProvinceListAsync()
        {
            return await _context.Provinces
                .Include(p => p.Country)
                .Select(p => ProvinceMapper.ToListProvince(p))
                .ToListAsync();
        }

        public async Task<ProvinceReadDto?> GetProvinceByIdAsync(int id)
        {
            return await _context.Provinces
                .Include(p => p.Country)
                .Where(p => p.ProvinceId == id)
                .Select(p => ProvinceMapper.ToReadProvince(p))
                .FirstOrDefaultAsync();
        }

        public async Task<List<ProvinceListDto>> GetProvincesByCountryIdAsync(int countryId)
        {
            return await _context.Provinces
                .Include(p => p.Country)
                .Where(p => p.CountryId == countryId)
                .Select(p => ProvinceMapper.ToListProvince(p))
                .ToListAsync();
        }

        public async Task<ProvinceReadDto> CreateProvinceAsync(ProvinceCreateDto provinceCreateDto)
        {
            var newProvince = provinceCreateDto.ToCreateProvince();
            _context.Provinces.Add(newProvince);
            await _context.SaveChangesAsync();

            return await GetProvinceByIdAsync(newProvince.ProvinceId)
                   ?? throw new InvalidOperationException("Failed to retrieve created province");
        }

        public async Task<ProvinceReadDto?> UpdateProvinceAsync(int id, ProvinceUpdateDto provinceUpdateDto)
        {
            var existingProvince = await _context.Provinces.FindAsync(id);
            if (existingProvince == null)
            {
                return null;
            }

            existingProvince.ProvinceName = provinceUpdateDto.ProvinceName;
            existingProvince.CountryId = provinceUpdateDto.CountryId;

            await _context.SaveChangesAsync();

            return await GetProvinceByIdAsync(id);
        }

        public async Task<bool> DeleteProvinceAsync(int id)
        {
            var existingProvince = await _context.Provinces.FindAsync(id);
            if (existingProvince == null)
            {
                return false;
            }

            _context.Provinces.Remove(existingProvince);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
