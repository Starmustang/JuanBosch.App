using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuanBosch.App.Models.Address
{
    public class Sector
    {
        [Key]
        public int SectorId { get; set; }
        public string SectorName { get; set; }
        public int MunicipalityId { get; set; }
        [ForeignKey("MunicipalityId")]
        public Municipality? Municipality { get; set; }
    }
}
