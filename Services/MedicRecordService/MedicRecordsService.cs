using JuanBosch.App.Dtos.MedicRecordDtos;
using JuanBosch.App.Mapper.MedicRecordMapper;
using JuanBosch.App.Models.Persistence;
using JuanBosch.App.Services.Interface.IMedicRecordService;
using Microsoft.EntityFrameworkCore;

namespace JuanBosch.App.Services.MedicRecordService
{
    public class MedicRecordsService : IMedicRecordsService
    {
        private readonly DataContext _context;
        public MedicRecordsService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<MedicRecordReadDto>> GetAllMedicRecordsAsync()
        {
            return await _context.MedicRecords
            .Include(p => p.Patient)
            .Select(p => MedicRecordsMapper.ToReadMedicRecord(p))
            .ToListAsync();
        }

        public async Task<MedicRecordReadDto> GetMedicRecordByIdAsync(int id)
        {
            return await _context.MedicRecords
            .AsNoTracking()
            .Where(p => p.RecordId == id)
            .Include(p => p.Patient)
            .Select(p => MedicRecordsMapper.ToReadMedicRecord(p))
            .FirstOrDefaultAsync();
        }

        public async Task<MedicRecordCreateDto> CreateMedicRecordAsync(MedicRecordCreateDto medicRecord)
        {
            var newMedicRecord = medicRecord.ToCreateMedicRecord();
            _context.MedicRecords.Add(newMedicRecord);
            await _context.SaveChangesAsync();
            return medicRecord;
        }

        public async Task<MedicRecordReadDto> UpdateMedicRecordAsync(int id, MedicRecordUpdateDto medicRecord)
        {
            var existingMedicRecord = await _context.MedicRecords.FindAsync(id);
            if (existingMedicRecord == null)
            {
                throw new ArgumentNullException(nameof(existingMedicRecord));
            }
            existingMedicRecord.PatientId = medicRecord.PatientId;
            existingMedicRecord.DoctorId = medicRecord.DoctorId;
            existingMedicRecord.FollowUpMedicRecord = medicRecord.FollowUpMedicRecord;
            existingMedicRecord.SignsMedicRecord = medicRecord.SignsMedicRecord;
            await _context.SaveChangesAsync();
            return MedicRecordsMapper.ToReadMedicRecord(existingMedicRecord);
        }

        public async Task<bool> DeleteMedicRecordAsync(int id)
        {
            var existingMedicRecord = await _context.MedicRecords.FindAsync(id);
            if (existingMedicRecord == null)
            {
                throw new ArgumentNullException(nameof(existingMedicRecord));
            }
            _context.MedicRecords.Remove(existingMedicRecord);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}