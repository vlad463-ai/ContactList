using ContactList.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContactList.Data;
using ContactList.Model;

namespace ContactList.Pages.Contacts
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactList.Model.Contact Contacts { get; set; }

        public IActionResult OnGet(int id)
        {
            Contacts = _context.Contacts.Find(id);

            if (Contacts == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Contacts.Update(Contacts);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
