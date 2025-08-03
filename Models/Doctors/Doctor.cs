using JuanBosch.App.Models.Address;
using JuanBosch.App.Models.MedicRecords;
using JuanBosch.App.Models.Dates;

namespace JuanBosch.App.Models.Doctors
{
    public class DoctorMedic
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
        public DoctorAddress DoctorAddress { get; set; }
        public  string DoctorExecatur { get; set; }
       public ICollection<DateMedic> DateMedics { get; set; } = new List<DateMedic>();
       public ICollection<MedicRecord> MedicRecords { get; set; } = new List<MedicRecord>();

    }
}