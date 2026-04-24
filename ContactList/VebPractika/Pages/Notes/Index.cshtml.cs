using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContactList.Data;
using ContactList.Model;

namespace ContactList.Pages.Notes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Note> Notes { get; set; } = new List<Note>();

        public async Task OnGetAsync()
        {
            Notes = await _context.Notes
                .Include(n => n.Contact)
                .ToListAsync();
        }
    }
}