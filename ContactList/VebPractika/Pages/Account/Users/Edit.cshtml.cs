using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using ContactList.Data;
using ContactList.Model.AuthApp;

namespace ContactList.Pages.Account.Users
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuthUser User { get; set; }

        [BindProperty]
        public IFormFile? AvatarFile { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _context.AuthUsers.FindAsync(id);

            if (User == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Загружаем существующего пользователя из базы
            var existingUser = await _context.AuthUsers.FindAsync(User.Id);
            if (existingUser == null)
                return NotFound();

            // Обновляем текстовые поля
            existingUser.Email = User.Email;
            existingUser.Password = User.Password;
            existingUser.Role = User.Role;

            // Обновляем аватар если загружен
            if (AvatarFile != null && AvatarFile.Length > 0)
            {
                if (AvatarFile.Length > 2 * 1024 * 1024) // максимум 2MB
                {
                    ModelState.AddModelError("", "Файл слишком большой (максимум 2MB)");
                    return Page();
                }

                using (var ms = new MemoryStream())
                {
                    await AvatarFile.CopyToAsync(ms);
                    existingUser.Avatar = ms.ToArray();
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}