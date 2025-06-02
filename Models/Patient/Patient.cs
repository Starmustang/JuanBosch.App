using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuanBosch.App.Models
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientLastName { get; set; }

        public string? PatientIdCard { get; set; }
        public string? PatientPassport { get; set; }
        public DateOnly? PatientBirthDate { get; set; }
        public string? PatientGender { get; set; }
        [EmailAddress]
        public string? PatientEmail { get; set; }
        public string? PatientPhone { get; set; }
        public int? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public PatientDirection? PatientDirection {get; set;}
        
    }
}