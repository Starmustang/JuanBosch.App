using JuanBosch.App.Dtos.AddressDtos;
using JuanBosch.App.Models;

namespace JuanBosch.App.Mapper.AddressMapper
{
    public static class PatientDirectionMapper
    {
        public static PatientDirection ToCreatePatientDirection(this PatientDirectionCreateDto patientDirectionCreateDto)
        {
            if (patientDirectionCreateDto == null)
            {
                throw new ArgumentNullException(nameof(patientDirectionCreateDto));
            }
            return new PatientDirection
            {
                HouseNumber = patientDirectionCreateDto.HouseNumber,
                HouseStreet = patientDirectionCreateDto.HouseStreet,
                SectorId = patientDirectionCreateDto.SectorId
            };
        }

        public static PatientDirectionReadDto ToReadPatientDirection(this PatientDirection patientDirection)
        {
            if (patientDirection == null)
            {
                throw new ArgumentNullException(nameof(patientDirection));
            }
            return new PatientDirectionReadDto
            {
                AddressId = patientDirection.AddressId,
                HouseNumber = patientDirection.HouseNumber,
                HouseStreet = patientDirection.HouseStreet,
                SectorId = patientDirection.SectorId,
                SectorName = patientDirection.Sector?.SectorName,
                MunicipalityName = patientDirection.Sector?.Municipality?.MunicipalityName,
                ProvinceName = patientDirection.Sector?.Municipality?.Province?.ProvinceName,
                CountryName = patientDirection.Sector?.Municipality?.Province?.Country?.CountryName
            };
        }

        public static PatientDirection ToUpdatePatientDirection(this PatientDirectionUpdateDto patientDirectionUpdateDto, int addressId)
        {
            if (patientDirectionUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(patientDirectionUpdateDto));
            }
            return new PatientDirection
            {
                AddressId = addressId,
                HouseNumber = patientDirectionUpdateDto.HouseNumber,
                HouseStreet = patientDirectionUpdateDto.HouseStreet,
                SectorId = patientDirectionUpdateDto.SectorId
            };
        }
    }
}