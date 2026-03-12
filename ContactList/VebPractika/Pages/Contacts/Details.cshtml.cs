using ContactList.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContactList.Data;
using ContactList.Model;

namespace ContactList.Pages.Contacts
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public ContactList.Model.Contact Contact { get; set; }

        public IActionResult OnGet(int id)
        {
            Contact = _context.Contacts.FirstOrDefault(s => s.Id == id);

            if (Contact == null)
                return NotFound();

            return Page();
        }
    }
}
