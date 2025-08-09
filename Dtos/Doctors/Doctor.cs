namespace JuanBosch.App.Dtos.Doctors
{
    public class DoctorReadDto
    {
        public int DoctorId { get; set; }
        public required string DoctorName { get; set; }
        public required string DoctorLastName { get; set; }
        public string DoctorPhone { get; set; } = string.Empty;
        public string DoctorEmail { get; set; } = string.Empty;
        public required string DoctorIdCard { get; set; }
        public required string DoctorPassport { get; set; }
        public string DoctorSpeciality { get; set; } = string.Empty;
        public int DoctorAddressId { get; set; } 
        public string DoctorHouseNumber { get; set; }       
        public string DoctorStreet { get; set; }       
        public string DoctorExecatur { get; set; }
       
    }

    public class DoctorCreateDto {
        public required string DoctorName { get; set; }
        public required string DoctorLastName { get; set; }
        public string DoctorPhone { get; set; } = string.Empty;
        public string DoctorEmail { get; set; } = string.Empty;
        public required string DoctorIdCard { get; set; }
        public required string DoctorPassport { get; set; }
        public string DoctorSpeciality { get; set; } = string.Empty;
        public int DoctorAddressId { get; set; } 
        public string DoctorHouseNumber { get; set; }       
        public string DoctorStreet { get; set; }       
        public string DoctorExecatur { get; set; }
    }

    public class DoctorUpdateDto{
        public int DoctorId { get; set; }
        public required string DoctorName { get; set; }
        public required string DoctorLastName { get; set; }
        public string DoctorPhone { get; set; } = string.Empty;
        public string DoctorEmail { get; set; } = string.Empty;
        public required string DoctorIdCard { get; set; }
        public required string DoctorPassport { get; set; }
        public string DoctorSpeciality { get; set; } = string.Empty;
        public int DoctorAddressId { get; set; } 
        public string DoctorHouseNumber { get; set; }       
        public string DoctorStreet { get; set; }       
        public string DoctorExecatur { get; set; }
    }
}