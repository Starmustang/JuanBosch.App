using JuanBosch.App.Dtos.AddressDtos;

namespace JuanBosch.App.Services.Interface
{
    public interface IProvinceService
    {
        Task<List<ProvinceReadDto>> GetAllProvincesAsync();
        Task<List<ProvinceListDto>> GetProvinceListAsync();
        Task<ProvinceReadDto?> GetProvinceByIdAsync(int id);
        Task<List<ProvinceListDto>> GetProvincesByCountryIdAsync(int countryId);
        Task<ProvinceReadDto> CreateProvinceAsync(ProvinceCreateDto provinceCreateDto);
        Task<ProvinceReadDto?> UpdateProvinceAsync(int id, ProvinceUpdateDto provinceUpdateDto);
        Task<bool> DeleteProvinceAsync(int id);
    }
}
