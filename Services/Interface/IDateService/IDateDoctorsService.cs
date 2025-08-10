using JuanBosch.App.Dtos.Dates;

namespace JuanBosch.App.Services.Interface.IDateService
{
    public interface IDateDoctorsService
    {
        Task<DateDoctorReadDto> CreateDateDoctorAsync(DateDoctorCreateDto dto);
        Task<DateDoctorReadDto> UpdateDateDoctorAsync(int id, DateDoctorUpdateDto dto);
        Task<DateDoctorReadDto> DeleteDateDoctorAsync(int id);
        Task<DateDoctorReadDto> GetDateDoctorAsync(int id);
        Task<List<DateDoctorReadDto>> GetAllDateDoctorsAsync();
    }
}