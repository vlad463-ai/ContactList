using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContactList.Data;
using ContactList.Model;

namespace ContactList.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Contact> Contacts { get; set; } = new List<Contact>();

        public async Task OnGetAsync()
        {
            // ВАЖНО! Include(c => c.Category) подгружает категорию
            Contacts = await _context.Contacts
                .Include(c => c.Category)
                .ToListAsync();
        }
    }
}