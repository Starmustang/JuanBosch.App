using JuanBosch.App.Models.Patients;

namespace JuanBosch.App.Models.Bloods
{
    public class Blood
    {
        public int BloodId { get; set; }
        public string BloodType { get; set; } = string.Empty;
        public bool ConsentBlood {get; set;} = false;
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
    }
}