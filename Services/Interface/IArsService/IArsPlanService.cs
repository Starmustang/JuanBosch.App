using JuanBosch.App.Dtos.Ars;

namespace JuanBosch.App.Services.Interface.IArsService
{
    public interface IArsPlanService
    {
        Task<List<ArsPlanReadDto>> GetAllArsPlanAsync();
        Task<ArsPlanReadDto> GetArsPlanByIdAsync(int id);
        Task<ArsPlanReadDto> CreateArsPlanAsync(ArsPlanCreateDto arsPlan);
        Task<ArsPlanReadDto> UpdateArsPlanAsync(int id, ArsPlanUpdateDto arsPlan);
        Task<bool> DeleteArsPlanAsync(int id);
    }
}