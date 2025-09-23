namespace JuanBosch.App.Dtos.Patient
{
    public class PatientReadDto {
        public int PatientId { get; set; }
        public required string PatientName { get; set; }
        public required string PatientLastName { get; set; }
        public string? PatientIdCard { get; set; }
        public string? PatientPassport { get; set; }
        public DateOnly? PatientBirthDate { get; set; }
        public string? PatientGender { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientPhone { get; set; }
        public int ArsPlansId { get; set; }
        public string ArsPlansName { get; set; }
        public int? AddressId { get; set; }
        public string HouseNumber { get; set; }
        public string HouseStreet { get; set; }
        public string PatientEmergencieContact { get; set; }

        public string? PatientFirstRecord { get; set; }
        public int BloodId { get; set; }
        public string BloodType { get; set; }
        public int MedicRecordId { get; set; }        
        public int PatientDirectionId { get; set; }
        public int PatientDoctorId { get; set; }
        public int DateMedicId { get; set; }
    }

    public class PatientCreateDto {
        public required string PatientName { get; set; }
        public required string PatientLastName { get; set; }
        public string? PatientIdCard { get; set; }
        public string? PatientPassport { get; set; }
        public DateOnly? PatientBirthDate { get; set; }
        public string? PatientGender { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientPhone { get; set; }
        public int ArsPlansId { get; set; }        
        public int? AddressId { get; set; }                
        public string PatientEmergencieContact { get; set; }
        public string? PatientFirstRecord { get; set; }
        public int BloodId { get; set; }
        public int MedicRecordId { get; set; }        
        public int PatientDirectionId { get; set; }
        public int PatientDoctorId { get; set; }
        public int DateMedicId { get; set; }
    }

    public class PatientUpdateDto {
        public int PatientId { get; set; }
        public required string PatientName { get; set; }
        public required string PatientLastName { get; set; }
        public string? PatientIdCard { get; set; }
        public string? PatientPassport { get; set; }
        public DateOnly? PatientBirthDate { get; set; }
        public string? PatientGender { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientPhone { get; set; }
        public int ArsPlansId { get; set; }
        public string ArsPlansName { get; set; }
        public int? AddressId { get; set; }        
        public string PatientEmergencieContact { get; set; }
        public string? PatientFirstRecord { get; set; }
        public int BloodId { get; set; }
        public int MedicRecordId { get; set; }        
        public int PatientDirectionId { get; set; }
        public int PatientDoctorId { get; set; }
        public int DateMedicId { get; set; }
    }
}
