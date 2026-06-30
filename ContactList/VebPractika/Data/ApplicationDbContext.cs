using ContactList.Model;
using ContactList.Model.AuthApp;
using Microsoft.EntityFrameworkCore;
using ContactList.Model.AuthApp;

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
        public DbSet<AuthUser> AuthUsers { get; set; }

    }
}

