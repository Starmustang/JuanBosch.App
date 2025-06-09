using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JuanBosch.App.Models.Address;

namespace JuanBosch.App.Models
{
    public class PatientDirection
    {
        [Key]
        public int AddressId { get; set; }
        public string HouseNumber { get; set; }
        public string HouseStreet { get; set; }
        public Patient? Patient { get; set; }

        public int SectorId { get; set; }
        [ForeignKey("SectorId")]
        public Sector? Sector { get; set; }
        

    }
}