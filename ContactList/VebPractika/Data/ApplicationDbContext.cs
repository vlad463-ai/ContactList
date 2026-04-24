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
        public DbSet<ContactList.Model.Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}

