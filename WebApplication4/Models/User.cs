using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastLogin { get; set; }

        public int FailedLoginAttempts { get; set; }
    }
}
