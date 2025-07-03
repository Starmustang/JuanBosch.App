using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuanBosch.App.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string PatientLastName { get; set; } = string.Empty;
        public string? PatientIdCard { get; set; }
        public string? PatientPassport { get; set; }
        public DateOnly? PatientBirthDate { get; set; }
        public string? PatientGender { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientPhone { get; set; }
        public int? AddressId { get; set; }
        
        // Navigation property
        public PatientDirection? PatientDirection { get; set; }
    }
}