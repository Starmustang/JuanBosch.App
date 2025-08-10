using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Models.Address;

namespace JuanBosch.App.Mapper.AddressMapper
{
    public static class SectorMapper
    {
        public static Sector ToCreateSector(this SectorCreateDto sectorCreateDto)
        {
            if (sectorCreateDto == null)
            {
                throw new ArgumentNullException(nameof(sectorCreateDto));
            }
            return new Sector
            {
                SectorName = sectorCreateDto.SectorName,
                MunicipalityId = sectorCreateDto.MunicipalityId
            };
        }

        public static SectorReadDto ToReadSector(this Sector sector)
        {
            if (sector == null)
            {
                throw new ArgumentNullException(nameof(sector));
            }
            return new SectorReadDto
            {
                SectorId = sector.SectorId,
                SectorName = sector.SectorName,
                MunicipalityId = sector.MunicipalityId,
                MunicipalityName = sector.Municipality?.MunicipalityName
            };
        }

        public static Sector ToUpdateSector(this SectorUpdateDto sectorUpdateDto, int sectorId)
        {
            if (sectorUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(sectorUpdateDto));
            }
            return new Sector
            {
                SectorId = sectorId,
                SectorName = sectorUpdateDto.SectorName,
                MunicipalityId = sectorUpdateDto.MunicipalityId
            };
        }

        public static SectorListDto ToListSector(this Sector sector)
        {
            if (sector == null)
            {
                throw new ArgumentNullException(nameof(sector));
            }
            return new SectorListDto
            {
                SectorId = sector.SectorId,
                SectorName = sector.SectorName,
                MunicipalityId = sector.MunicipalityId,
                MunicipalityName = sector.Municipality?.MunicipalityName
            };
        }
    }
}