using JuanBosch.App.Dtos.Dates;
using JuanBosch.App.Mapper.DatesMapper;
using JuanBosch.App.Models.DataContext;
using JuanBosch.App.Services.Interface.IDateService;
using Microsoft.EntityFrameworkCore;

namespace JuanBosch.App.Services.DatesService
{
    public class DateMedicService : IDateMedicService
    {
        private readonly DataContext _context;
        public DateMedicService(DataContext context)
        {
            _context = context;
        }
        public async Task<DateMedicReadDto> GetDateMedicAsync(int id)
        {
            return await _context.DateMedics
                .Where(d => d.DateMedicId == id)
                .Select(d => DateMedicMapper.ToReadDateMedic(d))
                .FirstOrDefaultAsync();
        }

        public async Task<List<DateMedicReadDto>> GetAllDateMedicsAsync()
        {
            return await _context.DateMedics
                .Select(d => DateMedicMapper.ToReadDateMedic(d))
                .ToListAsync();
        }
        public async Task<DateMedicReadDto> CreateDateMedicAsync(DateMedicCreateDto dto)
        {
            var entity = dto.ToCreateDateMedic();
            _context.DateMedics.Add(entity);
            await _context.SaveChangesAsync();
            return await GetDateMedicAsync(entity.DateMedicId)
                   ?? throw new InvalidOperationException("Failed to retrieve created date medic");
        }

        public async Task<DateMedicReadDto> UpdateDateMedicAsync(int id, DateMedicUpdateDto dto)
        {
            var existingDateMedic = await _context.DateMedics.FindAsync(id);
            if (existingDateMedic == null)
            {
                return null;
            }
            existingDateMedic.DateMedicDate = dto.DateMedicDate;
            existingDateMedic.HospitalMedicDate = dto.HospitalMedicDate;
            existingDateMedic.ConsultationType = (Models.Enums.ConsultationType)dto.ConsultationTypeId;
            existingDateMedic.DateDoctorId = dto.DateDoctorId;
            await _context.SaveChangesAsync();
            return await GetDateMedicAsync(id)
                   ?? throw new InvalidOperationException("Failed to retrieve updated date medic");
        }

        public async Task<DateMedicReadDto> DeleteDateMedicAsync(int id)
        {
            var existingDateMedic = await _context.DateMedics.FindAsync(id);
            if (existingDateMedic == null)
            {
                return null;
            }
            _context.DateMedics.Remove(existingDateMedic);
            await _context.SaveChangesAsync();
            return await GetDateMedicAsync(id)
                   ?? throw new InvalidOperationException("Failed to retrieve deleted date medic");
        }        
    }
}