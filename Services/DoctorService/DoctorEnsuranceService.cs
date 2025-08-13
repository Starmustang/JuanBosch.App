using JuanBosch.App.Dtos.Doctors;
using JuanBosch.App.Mapper.DoctorsMapper;
using JuanBosch.App.Models.DataContext;
using JuanBosch.App.Services.Interface.IDoctorService;
using Microsoft.EntityFrameworkCore;

namespace JuanBosch.App.Services.DoctorService
{
    public class DoctorEnsuranceService : IDoctorEnsuranceService
 {
    private readonly DataContext _context;
    public DoctorEnsuranceService(DataContext context)
    {
        _context = context;
    }

        public Task<DoctorEnsurancesReadDto> CreateDoctorEnsuranceAsync(DoctorEnsurancesCreateDto dto)
        {
            var entity = dto.ToCreateDoctorEnsurance();
            _context.DoctorEnsurances.Add(entity);
            _context.SaveChangesAsync();
            return GetDoctorEnsuranceByIdAsync(entity.DoctorEnsuranceId)
                   ?? throw new InvalidOperationException("Failed to retrieve created doctor ensurance");
        }

        public async Task<bool> DeleteDoctorEnsuranceAsync(int id)
        {
            var entity = _context.DoctorEnsurances
            .Where(d => d.DoctorEnsuranceId == id)
            .FirstOrDefault();
            if (entity == null)
            {
                throw new InvalidOperationException("Doctor ensurance not found");
            }
            _context.DoctorEnsurances.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<DoctorEnsurancesReadDto>> GetAllDoctorEnsuranceAsync()
        {
            return _context.DoctorEnsurances
            .Select(d => DoctorEnsuranceMapper.ToReadDoctorEnsurance(d))
            .ToListAsync(); 
        }

        public async Task<DoctorEnsurancesReadDto> GetDoctorEnsuranceByIdAsync(int id)
        {
            return await _context.DoctorEnsurances
            .Where(d => d.DoctorEnsuranceId == id)
            .Select(d => DoctorEnsuranceMapper.ToReadDoctorEnsurance(d))
            .FirstOrDefaultAsync()
            ?? throw new InvalidOperationException("Doctor ensurance not found");
        }

        public Task<DoctorEnsurancesReadDto> UpdateDoctorEnsuranceAsync(int id, DoctorEnsurancesUpdateDto dto)
        {
            var existingDoctorEnsurance = _context.DoctorEnsurances
            .Where(d => d.DoctorEnsuranceId == id)
            .FirstOrDefault();
            if (existingDoctorEnsurance == null)
            {
                throw new InvalidOperationException("Doctor ensurance not found");
            }
            DoctorEnsuranceMapper.ApplyUpdate(existingDoctorEnsurance, dto);
            existingDoctorEnsurance.ArsEnsuranceId = dto.ArsEnsuranceId;
            existingDoctorEnsurance.DoctorId = dto.DoctorId;
            _context.DoctorEnsurances.Update(existingDoctorEnsurance);
            _context.SaveChangesAsync();
            return GetDoctorEnsuranceByIdAsync(id);
        }
    }
}