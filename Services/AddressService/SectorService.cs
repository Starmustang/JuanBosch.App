using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Mapper.AddressMapper;
using JuanBosch.App.Models.DataContext;
using JuanBosch.App.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace JuanBosch.App.Services.AddressService
{
    public class SectorService : ISectorService
    {
        private readonly DataContext _context;

        public SectorService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SectorReadDto>> GetAllSectorsAsync()
        {
            return await _context.Sectors
                .Include(s => s.Municipality)
                .Select(s => SectorMapper.ToReadSector(s))
                .ToListAsync();
        }

        public async Task<List<SectorListDto>> GetSectorListAsync()
        {
            return await _context.Sectors
                .Include(s => s.Municipality)
                .Select(s => SectorMapper.ToListSector(s))
                .ToListAsync();
        }

        public async Task<SectorReadDto?> GetSectorByIdAsync(int id)
        {
            return await _context.Sectors
                .Include(s => s.Municipality)
                .Where(s => s.SectorId == id)
                .Select(s => SectorMapper.ToReadSector(s))
                .FirstOrDefaultAsync();
        }

        public async Task<List<SectorListDto>> GetSectorsByMunicipalityIdAsync(int municipalityId)
        {
            return await _context.Sectors
                .Include(s => s.Municipality)
                .Where(s => s.MunicipalityId == municipalityId)
                .Select(s => SectorMapper.ToListSector(s))
                .ToListAsync();
        }

        public async Task<SectorReadDto> CreateSectorAsync(SectorCreateDto sectorCreateDto)
        {
            var newSector = sectorCreateDto.ToCreateSector();
            _context.Sectors.Add(newSector);
            await _context.SaveChangesAsync();

            return await GetSectorByIdAsync(newSector.SectorId)
                   ?? throw new InvalidOperationException("Failed to retrieve created sector");
        }

        public async Task<SectorReadDto?> UpdateSectorAsync(int id, SectorUpdateDto sectorUpdateDto)
        {
            var existing = await _context.Sectors.FindAsync(id);
            if (existing == null)
            {
                return null;
            }

            existing.SectorName = sectorUpdateDto.SectorName;
            existing.MunicipalityId = sectorUpdateDto.MunicipalityId;

            await _context.SaveChangesAsync();

            return await GetSectorByIdAsync(id);
        }

        public async Task<bool> DeleteSectorAsync(int id)
        {
            var existing = await _context.Sectors.FindAsync(id);
            if (existing == null)
            {
                return false;
            }

            _context.Sectors.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
