using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContactList.Data;
using ContactList.Model;

namespace ContactList.Pages.Contacts
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactList.Model.Contact? Contact { get; set; }

        public IActionResult OnGet(int id)
        {
            Contact = _context.Contacts
                        .Where(c => c.Id == id)
                        .FirstOrDefault();

            if (Contact == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var contact = _context.Contacts.Find(Contact.Id);

            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}