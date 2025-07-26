using System.ComponentModel.DataAnnotations;

namespace JuanBosch.App.Models.Ars
{
    public class ArsEnsurance
    {
        public int ArsEnsuranceId { get; set; }
        public string EnsuranceName { get; set; }
        public string EnsuranceDirection { get; set; }
        public string EnsurancePhone { get; set; }
        public string? EnsurancePhone2 { get; set; }
        public string? EnsuranceFax { get; set; }
        [EmailAddress(ErrorMessage = "Correo no valido.")]
        public string? EnsuranceEmail { get; set; }
        public DateTime EnsuranceUpdateDate { get; set; }
        
        public ICollection<ArsPlans> Plans { get; set; } = new List<ArsPlans>();
        public TimeOnly EnsuranceSchedule { get; set; }
    }
}