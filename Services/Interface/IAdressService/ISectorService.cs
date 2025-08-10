using JuanBosch.App.Dtos.AddressDtos;

namespace JuanBosch.App.Services.Interface
{
    public interface ISectorService
    {
        Task<List<SectorReadDto>> GetAllSectorsAsync();
        Task<List<SectorListDto>> GetSectorListAsync();
        Task<SectorReadDto?> GetSectorByIdAsync(int id);
        Task<List<SectorListDto>> GetSectorsByMunicipalityIdAsync(int municipalityId);
        Task<SectorReadDto> CreateSectorAsync(SectorCreateDto sectorCreateDto);
        Task<SectorReadDto?> UpdateSectorAsync(int id, SectorUpdateDto sectorUpdateDto);
        Task<bool> DeleteSectorAsync(int id);
    }
}
