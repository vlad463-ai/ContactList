using ContactList.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            //Database.Migrate();
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categoryes { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}

