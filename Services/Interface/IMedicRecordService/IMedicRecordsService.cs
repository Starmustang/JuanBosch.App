using JuanBosch.App.Dtos.MedicRecordDtos;

namespace JuanBosch.App.Services.Interface.IMedicRecordService
{
    public interface IMedicRecordsService
    {
        Task<List<MedicRecordReadDto>> GetAllMedicRecordsAsync();
        Task<MedicRecordReadDto> GetMedicRecordByIdAsync(int id);
        Task<MedicRecordCreateDto> CreateMedicRecordAsync(MedicRecordCreateDto medicRecord);
        Task<MedicRecordReadDto> UpdateMedicRecordAsync(int id, MedicRecordUpdateDto medicRecord);
        Task<bool> DeleteMedicRecordAsync(int id);
    }
}