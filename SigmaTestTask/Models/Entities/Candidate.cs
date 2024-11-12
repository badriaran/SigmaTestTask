using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SigmaTestTask.Models.Entities
{
    public class Candidate
    {
    
        public int Id { get; set; }
        [Key]
        [Required]
        [EmailAddress]
        public string Email { get; set; } // Unique Identifier

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Phone]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public string PreferredCallTime { get; set; } // e.g., "9am-11am"

        [Url]
        public string? LinkedInProfile { get; set; }

        [Url]
        public string? GitHubProfile { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comments { get; set; } // Free text comment
    }
}
