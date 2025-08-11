using JuanBosch.App.Dtos.Ars;

namespace JuanBosch.App.Services.Interface.IArsService
{
    public interface IArsEnsuranceService
    {
        Task<List<ArsEnsurancesReadDto>> GetAllArsEnsuranceAsync();
        Task<ArsEnsurancesReadDto> GetArsEnsuranceByIdAsync(int id);
        Task<ArsEnsurancesReadDto> CreateArsEnsuranceAsync(ArsEnsurancesCreateDto arsEnsurance);
        Task<ArsEnsurancesReadDto> UpdateArsEnsuranceAsync(int id, ArsEnsurancesUpdateDto arsEnsurance);
        Task<bool> DeleteArsEnsuranceAsync(int id);
    }
}