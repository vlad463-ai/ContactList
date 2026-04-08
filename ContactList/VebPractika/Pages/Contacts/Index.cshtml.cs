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

        public List<ContactList.Model.Contact> Contacts { get; set; } = new List<ContactList.Model.Contact>();

        public async Task OnGetAsync()
        {
            Contacts = await _context.Contacts
                .Include(c => c.Category)
                .ToListAsync();
        }
    }
}