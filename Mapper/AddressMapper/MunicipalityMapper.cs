using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Models.Address;

namespace JuanBosch.App.Mapper.AddressMapper
{
    public static class MunicipalityMapper
    {
        public static Municipality ToCreateMunicipality(this MunicipalityCreateDto municipalityCreateDto)
        {
            if (municipalityCreateDto == null)
            {
                throw new ArgumentNullException(nameof(municipalityCreateDto));
            }
            return new Municipality
            {
                MunicipalityName = municipalityCreateDto.MunicipalityName,
                ProvinceId = municipalityCreateDto.ProvinceId
            };
        }

        public static MunicipalityReadDto ToReadMunicipality(this Municipality municipality)
        {
            if (municipality == null)
            {
                throw new ArgumentNullException(nameof(municipality));
            }
            return new MunicipalityReadDto
            {
                MunicipalityId = municipality.MunicipalityId,
                MunicipalityName = municipality.MunicipalityName,
                ProvinceId = municipality.ProvinceId,
                ProvinceName = municipality.Province?.ProvinceName
            };
        }

        public static Municipality ToUpdateMunicipality(this MunicipalityUpdateDto municipalityUpdateDto, int municipalityId)
        {
            if (municipalityUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(municipalityUpdateDto));
            }
            return new Municipality
            {
                MunicipalityId = municipalityId,
                MunicipalityName = municipalityUpdateDto.MunicipalityName,
                ProvinceId = municipalityUpdateDto.ProvinceId
            };
        }

        public static MunicipalityListDto ToListMunicipality(this Municipality municipality)
        {
            if (municipality == null)
            {
                throw new ArgumentNullException(nameof(municipality));
            }
            return new MunicipalityListDto
            {
                MunicipalityId = municipality.MunicipalityId,
                MunicipalityName = municipality.MunicipalityName,
                ProvinceId = municipality.ProvinceId,
                ProvinceName = municipality.Province?.ProvinceName
            };
        }
    }
}