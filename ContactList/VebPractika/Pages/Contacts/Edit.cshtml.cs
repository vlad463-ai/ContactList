using ContactList.Data;
using ContactList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


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
        public ContactList.Model.Contact? Contacts { get; set; }  // ќбратите внимание: свойство называетс€ Contacts (множественное число)

        public IActionResult OnGet(int id)
        {
            Contacts = _context.Contacts
                        .Where(c => c.Id == id)
                        .Include(c => c.Category)
                        .FirstOrDefault();

            if (Contacts == null)
                return NotFound();

            // «агружаем список категорий дл€ выпадающего списка
            ViewData["CategoryId"] = new SelectList(_context.Categoryes, "Id", "Name", Contacts.CategoryId);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // ѕри ошибке валидации снова загружаем список категорий
                ViewData["CategoryId"] = new SelectList(_context.Categoryes, "Id", "Name", Contacts.CategoryId);
                return Page();
            }

            _context.Contacts.Update(Contacts);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}