using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            ViewData["CategoryId"] = new SelectList(_context.Categoryes, "Id", "Name", Contacts.CategoryId);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["CategoryId"] = new SelectList(_context.Categoryes, "Id", "Name", Contacts.CategoryId);
                return Page();
            }

            _context.Contacts.Update(Contacts);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}