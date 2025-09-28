using JuanBosch.App.Dtos.Doctors;
using JuanBosch.App.Mapper.DoctorsMapper;
using JuanBosch.App.Models.Persistence;
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

        public async Task<DoctorEnsurancesReadDto> CreateDoctorEnsuranceAsync(DoctorEnsurancesCreateDto dto)
        {
            var entity = dto.ToCreateDoctorEnsurance();
            _context.DoctorEnsurances.Add(entity);
            await _context.SaveChangesAsync();
            return await GetDoctorEnsuranceByIdAsync(entity.DoctorEnsuranceId)
                   ?? throw new InvalidOperationException("Failed to retrieve created doctor ensurance");
        }

        public async Task<bool> DeleteDoctorEnsuranceAsync(int id)
        {
            var entity = await _context.DoctorEnsurances
            .Where(d => d.DoctorEnsuranceId == id)
            .FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new InvalidOperationException("Doctor ensurance not found");
            }
            _context.DoctorEnsurances.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<DoctorEnsurancesReadDto>> GetAllDoctorEnsuranceAsync()
        {
            return await _context.DoctorEnsurances
                .Include(d => d.DoctorMedic)
                .Include(d => d.ArsEnsurance)
                .Select(d => DoctorEnsuranceMapper.ToReadDoctorEnsurance(d))
                .ToListAsync();
        }

        public async Task<DoctorEnsurancesReadDto> GetDoctorEnsuranceByIdAsync(int id)
        {
            var doctorEnsurance = await _context.DoctorEnsurances
                .Include(d => d.DoctorMedic)
                .Include(d => d.ArsEnsurance)
                .FirstOrDefaultAsync(d => d.DoctorEnsuranceId == id);

            if (doctorEnsurance == null)
            {
                throw new InvalidOperationException("Doctor ensurance not found");
            }

            return DoctorEnsuranceMapper.ToReadDoctorEnsurance(doctorEnsurance);
        }

        public async Task<DoctorEnsurancesReadDto> UpdateDoctorEnsuranceAsync(int id, DoctorEnsurancesUpdateDto dto)
        {
            var existingDoctorEnsurance = await _context.DoctorEnsurances
            .Where(d => d.DoctorEnsuranceId == id)
            .FirstOrDefaultAsync();
            if (existingDoctorEnsurance == null)
            {
                throw new InvalidOperationException("Doctor ensurance not found");
            }
            DoctorEnsuranceMapper.ApplyUpdate(existingDoctorEnsurance, dto);
            existingDoctorEnsurance.ArsEnsuranceId = dto.ArsEnsuranceId;
            existingDoctorEnsurance.DoctorId = dto.DoctorId;
            _context.DoctorEnsurances.Update(existingDoctorEnsurance);
            await _context.SaveChangesAsync();
            return await GetDoctorEnsuranceByIdAsync(id);
        }
    }
}