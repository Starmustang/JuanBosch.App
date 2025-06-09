using JuanBosch.App.Models;

namespace JuanBosch.App.Dtos.Patient
{
    public class PatientCreateDto
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public string idCard { get; set; }
        public string passport { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        
        public DateOnly dateOfBirth { get; set; }
        public int addressId { get; set; }
        // public PatientDirection? PatientDirection { get; set; }

    }

    public class  PatientReadDto : PatientCreateDto
    {
        public int id { get; set; }
    }
}
