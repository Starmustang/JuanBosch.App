using JuanBosch.App.Dtos.Doctors;

namespace JuanBosch.App.Services.Interface.IDoctorService
{
    public interface IDoctorEnsuranceService
    {
          public Task<List<DoctorEnsurancesReadDto>> GetAllDoctorEnsuranceAsync();
          public Task<DoctorEnsurancesReadDto> GetDoctorEnsuranceByIdAsync(int id);
          public Task<DoctorEnsurancesReadDto> CreateDoctorEnsuranceAsync(DoctorEnsurancesCreateDto dto);
          public Task<DoctorEnsurancesReadDto> UpdateDoctorEnsuranceAsync(int id, DoctorEnsurancesUpdateDto dto);
          public Task<bool> DeleteDoctorEnsuranceAsync(int id);
    }
}