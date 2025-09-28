using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace JuanBosch.App.Models.Users
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? EmployeeId { get; set; }

        [MaxLength(100)]
        public string? Department { get; set; }

        [MaxLength(100)]
        public string? Position { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties for hospital-specific relationships
        public virtual ICollection<Models.Dates.DateMedic>? DateMedics { get; set; }
        public virtual ICollection<Models.MedicRecords.MedicRecord>? MedicRecords { get; set; }
        
        // Full name property for convenience
        public string FullName => $"{FirstName} {LastName}";
    }
}
