using JuanBosch.App.Dtos.AddressDtos;

namespace JuanBosch.App.Services.Interface
{
    public interface IDoctorAddressService
    {
        Task<List<DoctorAddressReadDto>> GetAllDoctorAddressesAsync();
        Task<DoctorAddressReadDto?> GetDoctorAddressByIdAsync(int id);
        Task<List<DoctorAddressReadDto>> GetDoctorAddressesBySectorIdAsync(int sectorId);
        Task<DoctorAddressReadDto> CreateDoctorAddressAsync(DoctorAddressCreateDto createDto);
        Task<DoctorAddressReadDto?> UpdateDoctorAddressAsync(int id, DoctorAddressUpdateDto updateDto);
        Task<bool> DeleteDoctorAddressAsync(int id);
    }
}
