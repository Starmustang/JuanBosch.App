using JuanBosch.App.Dtos.Ars;
using JuanBosch.App.Mapper.ArsMapaper;
using JuanBosch.App.Models.Persistence;
using JuanBosch.App.Services.Interface.IArsService;
using Microsoft.EntityFrameworkCore;

namespace JuanBosch.App.Services.ArsService
{
    public class ArsPlanService : IArsPlanService
    {
        private readonly DataContext _context;
        public ArsPlanService(DataContext context)
        {
            _context = context;
        }
        
        public async Task<List<ArsPlanReadDto>> GetAllArsPlanAsync()
        {
            return await _context.ArsPlans
            .Include(p => p.ArsEnsurance)
            .Select(p => ArsPlanMapper.ToReadArsPlan(p))
            .ToListAsync();
        }

        public async Task<ArsPlanReadDto> GetArsPlanByIdAsync(int id)
        {
            return await _context.ArsPlans
            .Include(p => p.ArsEnsurance)
            .Where(p => p.ArsPlansId == id)
            .Select(p => ArsPlanMapper.ToReadArsPlan(p))
            .FirstOrDefaultAsync();
        }

        public async Task<ArsPlanReadDto> CreateArsPlanAsync(ArsPlanCreateDto arsPlan)
        {
            var created = await _context.ArsPlans.AddAsync(arsPlan.ToCreateArsPlan());
            await _context.SaveChangesAsync();
            return await GetArsPlanByIdAsync(created.Entity.ArsPlansId)
                   ?? throw new InvalidOperationException("Failed to retrieve created ArsPlan");
        }

        public async Task<ArsPlanReadDto> UpdateArsPlanAsync(int id, ArsPlanUpdateDto arsPlan)
        {
            var updated = await _context.ArsPlans
            .Include(p => p.ArsEnsurance)
            .FirstOrDefaultAsync(p => p.ArsPlansId == id);
            if (updated == null)
            {
                throw new ArgumentNullException(nameof(updated));
            }
            updated.ApplyUpdate(arsPlan);
            await _context.SaveChangesAsync();
            return ArsPlanMapper.ToReadArsPlan(updated);
        }

        public async Task<bool> DeleteArsPlanAsync(int id)
        {
            var deleted = await _context.ArsPlans
            .Include(p => p.ArsEnsurance)
            .FirstOrDefaultAsync(p => p.ArsPlansId == id);
            if (deleted == null)
            {
                throw new ArgumentNullException(nameof(deleted));
            }
            _context.ArsPlans.Remove(deleted);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}