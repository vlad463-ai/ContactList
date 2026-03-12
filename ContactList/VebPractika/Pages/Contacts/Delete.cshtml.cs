using ContactList.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public ContactList.Model.Contact Contact { get; set; }

        public IActionResult OnGet(int id)
        {
            Contact = _context.Contacts.Find(id);

            if (Contact == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var student = _context.Contacts.Find(Contact.Id);

            if (student != null)
            {
                _context.Contacts.Remove(student);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
