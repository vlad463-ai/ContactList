using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContactList.Data;
using ContactList.Model;

namespace ContactList.Pages.Contacts
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactList.Model.Contact Contact { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Contacts.Add(Contact);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
