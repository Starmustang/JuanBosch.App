using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuanBosch.App.Models.Address
{
    public class Municipality
    {
        [Key]
        public int MunicipalityId { get; set; }
        public string MunicipalityName { get; set; }
        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public Province? Province { get; set; }
    }
}
