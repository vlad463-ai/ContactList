using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactList.Data;
using ContactList.Model;

namespace ContactList.Pages.Notes
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Note Note { get; set; } = new Note();

        public async Task OnGetAsync()
        {
            ViewData["ContactId"] = new SelectList(await _context.Contacts.ToListAsync(), "Id", "FIO");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ContactId"] = new SelectList(await _context.Contacts.ToListAsync(), "Id", "FIO");
                return Page();
            }

            _context.Notes.Add(Note);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}