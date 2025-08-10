using JuanBosch.App.Dtos.Dates;
using JuanBosch.App.Mapper.DatesMapper;
using JuanBosch.App.Models.DataContext;
using JuanBosch.App.Services.Interface.IDateService;
using Microsoft.EntityFrameworkCore;

namespace JuanBosch.App.Services.DatesService
{
    public class DateDoctorService : IDateDoctorsService
    {
        private readonly DataContext _context;
        public DateDoctorService(DataContext context)
        {
            _context = context;
        }
        public async Task<DateDoctorReadDto> CreateDateDoctorAsync(DateDoctorCreateDto dto)
        {
            var entity = dto.ToCreateDateDoctor();
            _context.DateDoctors.Add(entity);
            await _context.SaveChangesAsync();
            return await GetDateDoctorAsync(entity.DateDoctorId)
                   ?? throw new InvalidOperationException("Failed to retrieve created date doctor");
        }

        public async Task<DateDoctorReadDto> DeleteDateDoctorAsync(int id)
        {
            var existingDateDoctor = await _context.DateDoctors.FindAsync(id);
            if (existingDateDoctor == null)
            {
                return null;
            }
            _context.DateDoctors.Remove(existingDateDoctor);
            await _context.SaveChangesAsync();
            return await GetDateDoctorAsync(id);
        }

        public async Task<DateDoctorReadDto> GetDateDoctorAsync(int id)
        {
            return await _context.DateDoctors
                .Where(d => d.DateDoctorId == id)
                .Select(d => DateDoctorsMapper.ToReadDateDoctor(d))
                .FirstOrDefaultAsync();
        }

        public async Task<DateDoctorReadDto> UpdateDateDoctorAsync(int id, DateDoctorUpdateDto dto)
        {
            var existingDateDoctor = await _context.DateDoctors.FindAsync(id);
            if (existingDateDoctor == null)
            {
                return null;
            }
            existingDateDoctor.DateDoctorSintoms = dto.DateDoctorSintoms;
            existingDateDoctor.DateDoctorIndicatedAnalisis = dto.DateDoctorIndicatedAnalisis;
            existingDateDoctor.DateDoctorTreatment = dto.DateDoctorTreatment;
            existingDateDoctor.DateDoctorNotes = dto.DateDoctorNotes;
            existingDateDoctor.DateDoctorNextDate = dto.DateDoctorNextDate;
            existingDateDoctor.MedicEvaluationId = dto.MedicEvaluationId;
            await _context.SaveChangesAsync();
            return await GetDateDoctorAsync(id)
                   ?? throw new InvalidOperationException("Failed to retrieve updated date doctor");
        }

        public async Task<List<DateDoctorReadDto>> GetAllDateDoctorsAsync()
        {
            return await _context.DateDoctors
                .Select(d => DateDoctorsMapper.ToReadDateDoctor(d))
                .ToListAsync();
        }
    }
}