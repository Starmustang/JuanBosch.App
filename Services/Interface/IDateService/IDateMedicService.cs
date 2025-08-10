using JuanBosch.App.Dtos.Dates;

namespace JuanBosch.App.Services.Interface.IDateService
{
    public interface IDateMedicService
    {
        Task<DateMedicReadDto> CreateDateMedicAsync(DateMedicCreateDto dto);
        Task<DateMedicReadDto> UpdateDateMedicAsync(int id, DateMedicUpdateDto dto);
        Task<DateMedicReadDto> DeleteDateMedicAsync(int id);
        Task<DateMedicReadDto> GetDateMedicAsync(int id);
        Task<List<DateMedicReadDto>> GetAllDateMedicsAsync();
    }
}