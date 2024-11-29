namespace WAD.CODEBASE._00016668.DTOs
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        // foreign key to groups
        public int GroupId { get; set; }
        
    }
}
