using System.ComponentModel.DataAnnotations;

namespace WAD.CODEBASE._00016668.Models
{
    public class Contacts
    {
        [Key]
        public int ContactId { get; set; } // Primary key, correctly annotated.

        [Required] // Ensures this field is not null in the database.
        [MaxLength(50)] // Optional: You might want to set length constraints.
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [Phone] // Ensures valid phone number formatting.
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress] // Ensures valid email formatting.
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        
        [Required] 
        public int GroupId { get; set; }

        
        public Groups Groups { get; set; }
    }
}
