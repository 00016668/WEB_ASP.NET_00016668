using System.ComponentModel.DataAnnotations;

namespace WAD.CODEBASE._00016668.Models
{
    public class Groups
    {
        public int Id { get; set; }
        public string GroupName { get; set; }

        public ICollection<Contacts> Contacts { get; set; }
    }
}
