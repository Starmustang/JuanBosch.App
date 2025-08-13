using JuanBosch.App.Dtos.Doctors;

namespace JuanBosch.App.Services.Interface.IDoctorService
{
    public interface IDoctorService
    {
        Task<List<DoctorReadDto>> GetAllDoctorsAsync();
        Task<DoctorReadDto> GetDoctorByIdAsync(int id);
        Task<DoctorReadDto> CreateDoctorAsync(DoctorCreateDto dto);
        Task<DoctorReadDto> UpdateDoctorAsync(int id, DoctorUpdateDto dto);
        Task<bool> DeleteDoctorAsync(int id);   
    }
}