using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Mapper.AddressMapper;
using JuanBosch.App.Models.Persistence;
using JuanBosch.App.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace JuanBosch.App.Services.AddressService
{
    public class PatientDirectionService : IPatientDirectionService
    {
        private readonly DataContext _context;

        public PatientDirectionService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<PatientDirectionReadDto>> GetAllPatientDirectionsAsync()
        {
            return await _context.PatientDirections
                .Include(pd => pd.Sector)
                    .ThenInclude(s => s!.Municipality)
                        .ThenInclude(m => m!.Province)
                            .ThenInclude(p => p!.Country)
                .Select(pd => PatientDirectionMapper.ToReadPatientDirection(pd))
                .ToListAsync();
        }

        public async Task<PatientDirectionReadDto?> GetPatientDirectionByIdAsync(int id)
        {
            return await _context.PatientDirections
                .Include(pd => pd.Sector)
                    .ThenInclude(s => s!.Municipality)
                        .ThenInclude(m => m!.Province)
                            .ThenInclude(p => p!.Country)
                .Where(pd => pd.AddressId == id)
                .Select(pd => PatientDirectionMapper.ToReadPatientDirection(pd))
                .FirstOrDefaultAsync();
        }

        public async Task<List<PatientDirectionReadDto>> GetPatientDirectionsBySectorIdAsync(int sectorId)
        {
            return await _context.PatientDirections
                .Include(pd => pd.Sector)
                    .ThenInclude(s => s!.Municipality)
                        .ThenInclude(m => m!.Province)
                            .ThenInclude(p => p!.Country)
                .Where(pd => pd.SectorId == sectorId)
                .Select(pd => PatientDirectionMapper.ToReadPatientDirection(pd))
                .ToListAsync();
        }

        public async Task<PatientDirectionReadDto> CreatePatientDirectionAsync(PatientDirectionCreateDto createDto)
        {
            var entity = createDto.ToCreatePatientDirection();
            _context.PatientDirections.Add(entity);
            await _context.SaveChangesAsync();

            return await GetPatientDirectionByIdAsync(entity.AddressId)
                   ?? throw new InvalidOperationException("Failed to retrieve created patient direction");
        }

        public async Task<PatientDirectionReadDto?> UpdatePatientDirectionAsync(int id, PatientDirectionUpdateDto updateDto)
        {
            var existing = await _context.PatientDirections.FindAsync(id);
            if (existing == null)
            {
                return null;
            }

            existing.HouseNumber = updateDto.HouseNumber;
            existing.HouseStreet = updateDto.HouseStreet;
            existing.SectorId = updateDto.SectorId;

            await _context.SaveChangesAsync();

            return await GetPatientDirectionByIdAsync(id);
        }

        public async Task<bool> DeletePatientDirectionAsync(int id)
        {
            var existing = await _context.PatientDirections.FindAsync(id);
            if (existing == null)
            {
                return false;
            }

            _context.PatientDirections.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
