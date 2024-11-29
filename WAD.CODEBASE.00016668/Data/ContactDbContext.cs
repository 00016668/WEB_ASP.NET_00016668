using Microsoft.EntityFrameworkCore;
using WAD.CODEBASE._00016668.Models;

namespace WAD.CODEBASE._00016668.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }

        public DbSet<Contacts> Contacts { get; set; } // contacts db set

        public DbSet<Groups> GroupsDbSet { get; set; } // groups db set

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacts>()
                .HasOne(c => c.Groups)
                .WithMany(g => g.Contacts)
                .HasForeignKey(c => c.GroupId)
                .OnDelete(DeleteBehavior.Restrict); 
        }


    }
}
