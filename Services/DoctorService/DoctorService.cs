using JuanBosch.App.Dtos.Doctors;
using JuanBosch.App.Mapper.DoctorsMapper;
using JuanBosch.App.Models.DataContext;
using JuanBosch.App.Services.Interface.IDoctorService;
using Microsoft.EntityFrameworkCore;

namespace JuanBosch.App.Services.DoctorService
{
    public class DoctorService : IDoctorService
    {
        private readonly DataContext _context;
        public DoctorService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<DoctorReadDto>> GetAllDoctorsAsync()
        {
            return await _context.Doctors
            .Select(d => DoctorMapper.ToReadDoctor(d))
            .ToListAsync();
        }

        public async Task<DoctorReadDto> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors
            .Where(d => d.DoctorId == id)
            .Select(d => DoctorMapper.ToReadDoctor(d))
            .FirstOrDefaultAsync();
        }

        public async Task<DoctorReadDto> CreateDoctorAsync(DoctorCreateDto dto)
        {
            var entity = dto.ToCreateDoctor();
            _context.Doctors.Add(entity);
            await _context.SaveChangesAsync();
            return await GetDoctorByIdAsync(entity.DoctorId)
                   ?? throw new InvalidOperationException("Failed to retrieve created doctor");
        }

        public async Task<DoctorReadDto> UpdateDoctorAsync(int id, DoctorUpdateDto dto)
        {
            var entity = await _context.Doctors
            .Where(d => d.DoctorId == id)
            .FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new InvalidOperationException("Doctor not found");
            }
            DoctorMapper.ApplyUpdate(entity, dto);
            await _context.SaveChangesAsync();
            return await GetDoctorByIdAsync(entity.DoctorId)
                   ?? throw new InvalidOperationException("Failed to retrieve updated doctor");
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            var entity = await _context.Doctors
            .Where(d => d.DoctorId == id)
            .FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new InvalidOperationException("Doctor not found");
            }
            _context.Doctors.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}