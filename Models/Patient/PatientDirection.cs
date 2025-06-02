using System.ComponentModel.DataAnnotations;

namespace JuanBosch.App.Models
{
    public class PatientDirection
    {
        [Key]
        public int AddressId { get; set; }
        public string HouseNumber { get; set; }
        public string HouseStreet { get; set; }
        public Patient? Patient { get; set; }
        

    }
}