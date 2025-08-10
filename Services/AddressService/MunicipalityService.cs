using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Mapper.AddressMapper;
using JuanBosch.App.Models.Address;
using JuanBosch.App.Models.DataContext;
using JuanBosch.App.Services.Interface.IAdressService;
using Microsoft.EntityFrameworkCore;

namespace JuanBosch.App.Services.AddressService
{
    public class MunicipalityService : IMunicipalityService
    {
        private readonly DataContext _context;
        
        public MunicipalityService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<MunicipalityReadDto>> GetAllMunicipalitiesAsync()
        {
            return await _context.Municipalities
                .Include(m => m.Province)
                .Select(m => MunicipalityMapper.ToReadMunicipality(m))
                .ToListAsync();
        }

        public async Task<List<MunicipalityListDto>> GetMunicipalityListAsync()
        {
            return await _context.Municipalities
                .Include(m => m.Province)
                .Select(m => MunicipalityMapper.ToListMunicipality(m))
                .ToListAsync();
        }

        public async Task<MunicipalityReadDto?> GetMunicipalityByIdAsync(int id)
        {
            return await _context.Municipalities
                .Include(m => m.Province)
                .Where(m => m.MunicipalityId == id)
                .Select(m => MunicipalityMapper.ToReadMunicipality(m))
                .FirstOrDefaultAsync();
        }

        public async Task<List<MunicipalityReadDto>> GetMunicipalitiesByProvinceIdAsync(int provinceId)
        {
            return await _context.Municipalities
                .Include(m => m.Province)
                .Where(m => m.ProvinceId == provinceId)
                .Select(m => MunicipalityMapper.ToReadMunicipality(m))
                .ToListAsync();
        }

        public async Task<MunicipalityReadDto> CreateMunicipalityAsync(MunicipalityCreateDto municipalityCreateDto)
        {
            var newMunicipality = municipalityCreateDto.ToCreateMunicipality();
            _context.Municipalities.Add(newMunicipality);
            await _context.SaveChangesAsync();

            // Return the created municipality with navigation properties loaded
            return await GetMunicipalityByIdAsync(newMunicipality.MunicipalityId) 
                   ?? throw new InvalidOperationException("Failed to retrieve created municipality");
        }

        public async Task<MunicipalityReadDto?> UpdateMunicipalityAsync(int id, MunicipalityUpdateDto municipalityUpdateDto)
        {
            var existingMunicipality = await _context.Municipalities.FindAsync(id);
            if (existingMunicipality == null)
            {
                return null;
            }

            existingMunicipality.MunicipalityName = municipalityUpdateDto.MunicipalityName;
            existingMunicipality.ProvinceId = municipalityUpdateDto.ProvinceId;

            await _context.SaveChangesAsync();

            // Return the updated municipality with navigation properties loaded
            return await GetMunicipalityByIdAsync(id);
        }

        public async Task<bool> DeleteMunicipalityAsync(int id)
        {
            var existingMunicipality = await _context.Municipalities.FindAsync(id);
            if (existingMunicipality == null)
            {
                return false;
            }

            _context.Municipalities.Remove(existingMunicipality);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}