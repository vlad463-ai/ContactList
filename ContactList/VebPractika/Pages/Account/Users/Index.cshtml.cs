using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContactList.Data;
using ContactList.Model.AuthApp;

namespace ContactList.Pages.Account.Users
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AuthUser> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _context.AuthUsers.ToListAsync();
        }
    }
}