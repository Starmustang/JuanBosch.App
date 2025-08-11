using JuanBosch.App.Dtos.Bloods;

namespace JuanBosch.App.Services.Interface.IBloodService
{
    public interface IBloodService
    {
        Task<BloodReadDto> GetBloodByIdAsync(int id);
        Task<List<BloodReadDto>> GetAllBloodsAsync();
        Task<BloodReadDto> CreateBloodAsync(BloodCreateDto blood);
        Task<BloodReadDto?> UpdateBloodAsync(int id, BloodUpdateDto blood);
        Task<bool> DeleteBloodAsync(int id);
    }
}