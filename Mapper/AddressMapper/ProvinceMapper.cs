using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Models.Address;

namespace JuanBosch.App.Mapper.AddressMapper
{
    public static class ProvinceMapper
    {
        public static Province ToCreateProvince(this ProvinceCreateDto provinceCreateDto)
        {
            if (provinceCreateDto == null)
            {
                throw new ArgumentNullException(nameof(provinceCreateDto));
            }
            return new Province
            {
                ProvinceName = provinceCreateDto.ProvinceName,
                CountryId = provinceCreateDto.CountryId
            };
        }

        public static ProvinceReadDto ToReadProvince(this Province province)
        {
            if (province == null)
            {
                throw new ArgumentNullException(nameof(province));
            }
            return new ProvinceReadDto
            {
                ProvinceId = province.ProvinceId,
                ProvinceName = province.ProvinceName,
                CountryId = province.CountryId,
                CountryName = province.Country?.CountryName
            };
        }

        public static Province ToUpdateProvince(this ProvinceUpdateDto provinceUpdateDto, int provinceId)
        {
            if (provinceUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(provinceUpdateDto));
            }
            return new Province
            {
                ProvinceId = provinceId,
                ProvinceName = provinceUpdateDto.ProvinceName,
                CountryId = provinceUpdateDto.CountryId
            };
        }

        public static ProvinceListDto ToListProvince(this Province province)
        {
            if (province == null)
            {
                throw new ArgumentNullException(nameof(province));
            }
            return new ProvinceListDto
            {
                ProvinceId = province.ProvinceId,
                ProvinceName = province.ProvinceName,
                CountryId = province.CountryId,
                CountryName = province.Country?.CountryName
            };
        }
    }
}