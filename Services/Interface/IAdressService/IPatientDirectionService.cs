using JuanBosch.App.Dtos.AddressDtos;

namespace JuanBosch.App.Services.Interface
{
    public interface IPatientDirectionService
    {
        Task<List<PatientDirectionReadDto>> GetAllPatientDirectionsAsync();
        Task<PatientDirectionReadDto?> GetPatientDirectionByIdAsync(int id);
        Task<List<PatientDirectionReadDto>> GetPatientDirectionsBySectorIdAsync(int sectorId);
        Task<PatientDirectionReadDto> CreatePatientDirectionAsync(PatientDirectionCreateDto createDto);
        Task<PatientDirectionReadDto?> UpdatePatientDirectionAsync(int id, PatientDirectionUpdateDto updateDto);
        Task<bool> DeletePatientDirectionAsync(int id);
    }
}
