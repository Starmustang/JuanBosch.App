using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Mapper.AddressMapper;
using JuanBosch.App.Models.DataContext;
using JuanBosch.App.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace JuanBosch.App.Services.AddressService
{
    public class DoctorAddressService : IDoctorAddressService
    {
        private readonly DataContext _context;

        public DoctorAddressService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<DoctorAddressReadDto>> GetAllDoctorAddressesAsync()
        {
            return await _context.DoctorAddresses
                .Include(da => da.Sector)
                .Select(da => DoctorAddressMapper.ToReadDoctorAddress(da))
                .ToListAsync();
        }

        public async Task<DoctorAddressReadDto?> GetDoctorAddressByIdAsync(int id)
        {
            return await _context.DoctorAddresses
                .Include(da => da.Sector)
                .Where(da => da.DoctorAddressId == id)
                .Select(da => DoctorAddressMapper.ToReadDoctorAddress(da))
                .FirstOrDefaultAsync();
        }

        public async Task<List<DoctorAddressReadDto>> GetDoctorAddressesBySectorIdAsync(int sectorId)
        {
            return await _context.DoctorAddresses
                .Include(da => da.Sector)
                .Where(da => da.SectorId == sectorId)
                .Select(da => DoctorAddressMapper.ToReadDoctorAddress(da))
                .ToListAsync();
        }

        public async Task<DoctorAddressReadDto> CreateDoctorAddressAsync(DoctorAddressCreateDto createDto)
        {
            var entity = createDto.ToCreateDoctorAddress();
            _context.DoctorAddresses.Add(entity);
            await _context.SaveChangesAsync();

            return await GetDoctorAddressByIdAsync(entity.DoctorAddressId)
                   ?? throw new InvalidOperationException("Failed to retrieve created doctor address");
        }

        public async Task<DoctorAddressReadDto?> UpdateDoctorAddressAsync(int id, DoctorAddressUpdateDto updateDto)
        {
            var existing = await _context.DoctorAddresses.FindAsync(id);
            if (existing == null)
            {
                return null;
            }

            existing.DoctorHouseNumber = updateDto.DoctorHouseNumber;
            existing.DoctorStreet = updateDto.DoctorStreet;
            existing.SectorId = updateDto.SectorId;

            await _context.SaveChangesAsync();

            return await GetDoctorAddressByIdAsync(id);
        }

        public async Task<bool> DeleteDoctorAddressAsync(int id)
        {
            var existing = await _context.DoctorAddresses.FindAsync(id);
            if (existing == null)
            {
                return false;
            }

            _context.DoctorAddresses.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
