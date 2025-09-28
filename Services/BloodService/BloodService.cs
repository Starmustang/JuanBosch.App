using JuanBosch.App.Dtos.Bloods;
using JuanBosch.App.Mapper.Bloods;
using JuanBosch.App.Models.Persistence;
using JuanBosch.App.Services.Interface.IBloodService;
using Microsoft.EntityFrameworkCore;

namespace JuanBosch.App.Services.BloodService
{
    public class BloodService : IBloodService
    {
        private readonly DataContext _context;
        public BloodService(DataContext context)
        {
            _context = context;
        }

        public async Task<BloodReadDto> GetBloodByIdAsync(int id)
        {
            return await _context.Bloods
                .Where(b => b.BloodId == id)
                .Select(b => BloodsMapper.ToReadBlood(b))
                .FirstOrDefaultAsync();
        }

        public async Task<List<BloodReadDto>> GetAllBloodsAsync()
        {
            return await _context.Bloods
                .Select(b => BloodsMapper.ToReadBlood(b))
                .ToListAsync();
        }

        public async Task<BloodReadDto> CreateBloodAsync(BloodCreateDto blood)
        {
            var entity = blood.ToCreateBlood();
            _context.Bloods.Add(entity);
            await _context.SaveChangesAsync();
            return await GetBloodByIdAsync(entity.BloodId)
                   ?? throw new InvalidOperationException("Failed to retrieve created blood");
        }

        public async Task<BloodReadDto?> UpdateBloodAsync(int id, BloodUpdateDto blood)
        {
            var existingBlood = await _context.Bloods.FindAsync(id);
            if (existingBlood == null)
            {
                return null;
            }
            existingBlood.BloodType = blood.BloodType;
            existingBlood.ConsentBlood = blood.ConsentBlood;
            await _context.SaveChangesAsync();
            return await GetBloodByIdAsync(id);
        }

        public async Task<bool> DeleteBloodAsync(int id)
        {
            var existingBlood = await _context.Bloods.FindAsync(id);
            if (existingBlood == null)
            {
                return false;
            }
            _context.Bloods.Remove(existingBlood);
            await _context.SaveChangesAsync();
            return true;
        }
        
    }
}