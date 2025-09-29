using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JuanBosch.App.Models.Users
{
    // DTO for returning user details
    public class UserDto
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public IList<string> Roles { get; set; } = new List<string>();
    }

    // DTO for updating a user's profile information
    public class UpdateUserDto
    {
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(100)]
        public string? FirstName { get; set; }

        [StringLength(100)]
        public string? LastName { get; set; }

        // Optional: Allow updating roles
        public List<string>? Roles { get; set; }
    }
}
