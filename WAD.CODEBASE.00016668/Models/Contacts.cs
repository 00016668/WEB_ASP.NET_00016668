using System.ComponentModel.DataAnnotations;

namespace WAD.CODEBASE._00016668.Models
{
    public class Contacts
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int GroupId { get; set; }
        public Groups Groups { get; set; }
    }
}
