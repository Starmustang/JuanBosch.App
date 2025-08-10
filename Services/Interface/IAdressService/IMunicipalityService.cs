using JuanBosch.App.Dtos.AddressDtos;

namespace JuanBosch.App.Services.Interface.IAdressService
{
    public interface IMunicipalityService
    {
        Task<List<MunicipalityReadDto>> GetAllMunicipalitiesAsync();
        Task<MunicipalityReadDto?> GetMunicipalityByIdAsync(int id);
        Task<List<MunicipalityReadDto>> GetMunicipalitiesByProvinceIdAsync(int provinceId);
        Task<MunicipalityReadDto> CreateMunicipalityAsync(MunicipalityCreateDto municipalityCreateDto);
        Task<MunicipalityReadDto?> UpdateMunicipalityAsync(int id, MunicipalityUpdateDto municipalityUpdateDto);
        Task<bool> DeleteMunicipalityAsync(int id);
    }
}