using ContactList.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public List<ContactList.Model.Contact> Contacts { get; set; }

        public void OnGet()
        {
            Contacts = _context.Contacts.ToList();
        }
    }
}
