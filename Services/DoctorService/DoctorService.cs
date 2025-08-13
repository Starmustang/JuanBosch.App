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
        public DoctorService(DataContext _context)
        {
            _context = _context;
        }
        public Task<List<DoctorReadDto>> GetAllDoctorsAsync()
        {
            return _context.Doctors
            .Select(d => DoctorMapper.ToReadDoctor(d))
            .ToListAsync();
        }

        public Task<DoctorReadDto> GetDoctorByIdAsync(int id)
        {
            return _context.Doctors
            .Where(d => d.DoctorId == id)
            .Select(d => DoctorMapper.ToReadDoctor(d))
            .FirstOrDefaultAsync();
        }

        public Task<DoctorReadDto> CreateDoctorAsync(DoctorCreateDto dto)
        {
            var entity = dto.ToCreateDoctor();
            _context.Doctors.Add(entity);
            _context.SaveChangesAsync();
            return GetDoctorByIdAsync(entity.DoctorId)
                   ?? throw new InvalidOperationException("Failed to retrieve created doctor");
        }

        public Task<DoctorReadDto> UpdateDoctorAsync(int id, DoctorUpdateDto dto)
        {
            var entity = _context.Doctors
            .Where(d => d.DoctorId == id)
            .FirstOrDefault();
            if (entity == null)
            {
                throw new InvalidOperationException("Doctor not found");
            }
            DoctorMapper.ApplyUpdate(entity, dto);
            _context.SaveChangesAsync();
            return GetDoctorByIdAsync(entity.DoctorId)
                   ?? throw new InvalidOperationException("Failed to retrieve updated doctor");
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            var entity = _context.Doctors
            .Where(d => d.DoctorId == id)
            .FirstOrDefault();
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