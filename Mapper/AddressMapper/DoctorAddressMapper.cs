using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Models.Address;

namespace JuanBosch.App.Mapper.AddressMapper
{
    public static class DoctorAddressMapper
    {
        public static DoctorAddress ToCreateDoctorAddress(this DoctorAddressCreateDto doctorAddressCreateDto)
        {
            if (doctorAddressCreateDto == null)
            {
                throw new ArgumentNullException(nameof(doctorAddressCreateDto));
            }
            return new DoctorAddress
            {
                DoctorHouseNumber = doctorAddressCreateDto.DoctorHouseNumber,
                DoctorStreet = doctorAddressCreateDto.DoctorStreet,
                SectorId = doctorAddressCreateDto.SectorId,
                Sector = null! // Will be set by EF Core when loading from database
            };
        }

        public static DoctorAddressReadDto ToReadDoctorAddress(this DoctorAddress doctorAddress)
        {
            if (doctorAddress == null)
            {
                throw new ArgumentNullException(nameof(doctorAddress));
            }
            return new DoctorAddressReadDto
            {
                DoctorAddressId = doctorAddress.DoctorAddressId,
                DoctorHouseNumber = doctorAddress.DoctorHouseNumber,
                DoctorStreet = doctorAddress.DoctorStreet,
                SectorId = doctorAddress.SectorId,
                SectorName = doctorAddress.Sector?.SectorName ?? string.Empty
            };
        }

        public static DoctorAddress ToUpdateDoctorAddress(this DoctorAddressUpdateDto doctorAddressUpdateDto)
        {
            if (doctorAddressUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(doctorAddressUpdateDto));
            }
            return new DoctorAddress
            {
                DoctorAddressId = doctorAddressUpdateDto.DoctorAddressId,
                DoctorHouseNumber = doctorAddressUpdateDto.DoctorHouseNumber,
                DoctorStreet = doctorAddressUpdateDto.DoctorStreet,
                SectorId = doctorAddressUpdateDto.SectorId,
                Sector = null! // Will be set by EF Core when loading from database
            };
        }
    }
}