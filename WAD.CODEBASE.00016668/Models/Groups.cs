using System.ComponentModel.DataAnnotations;

namespace WAD.CODEBASE._00016668.Models
{
    public class Groups
    {
        [Key]
        public int GroupId { get; set; } 

        [Required]
        [MaxLength(100)]
        public string GroupName { get; set; }

        
        [Required] 
        public ICollection<Contacts> Contacts { get; set; }
    }
}
