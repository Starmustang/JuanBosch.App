using JuanBosch.App.Dtos.Ars;
using JuanBosch.App.Mapper.ArsMapaper;
using JuanBosch.App.Models.DataContext;
using JuanBosch.App.Services.Interface.IArsService;
using Microsoft.EntityFrameworkCore;

namespace JuanBosch.App.Services.ArsService
{
    public class ArsEnsuranceService : IArsEnsuranceService
    {
        private readonly DataContext _context;
        public ArsEnsuranceService(DataContext context)
        {
            _context = context;
        }
        
        public async Task<List<ArsEnsurancesReadDto>> GetAllArsEnsuranceAsync()
        {
            return await _context.ArsEnsurances
            .Select(e => ArsEnsuranceMapper.ToReadArsEnsurance(e))
            .ToListAsync();
        }

        public async Task<ArsEnsurancesReadDto> GetArsEnsuranceByIdAsync(int id)
        {
            return await _context.ArsEnsurances
            .Select(e => ArsEnsuranceMapper.ToReadArsEnsurance(e))
            .FirstOrDefaultAsync(e => e.ArsEnsuranceId == id);
        }

        public async Task<ArsEnsurancesReadDto> CreateArsEnsuranceAsync(ArsEnsurancesCreateDto arsEnsurance)
        {
            var created = await _context.ArsEnsurances.AddAsync(arsEnsurance.ToCreateArsEnsurance());
            await _context.SaveChangesAsync();
            return await GetArsEnsuranceByIdAsync(created.Entity.ArsEnsuranceId)
                   ?? throw new InvalidOperationException("Failed to retrieve created ArsEnsurance");
        }

        public async Task<ArsEnsurancesReadDto> UpdateArsEnsuranceAsync(int id, ArsEnsurancesUpdateDto arsEnsurance)
        {
            var updated = await _context.ArsEnsurances
            .FirstOrDefaultAsync(e => e.ArsEnsuranceId == id);
            if (updated == null)
            {
                throw new ArgumentNullException(nameof(updated));
            }
            updated.ApplyUpdate(arsEnsurance);
            await _context.SaveChangesAsync();
            return ArsEnsuranceMapper.ToReadArsEnsurance(updated);
        }

        public async Task<bool> DeleteArsEnsuranceAsync(int id)
        {
            var deleted = await _context.ArsEnsurances
            .FirstOrDefaultAsync(e => e.ArsEnsuranceId == id);
            if (deleted == null)
            {
                throw new ArgumentNullException(nameof(deleted));
            }
            _context.ArsEnsurances.Remove(deleted);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}