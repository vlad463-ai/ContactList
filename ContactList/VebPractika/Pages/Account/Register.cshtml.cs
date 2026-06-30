using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using ContactList.Data;
using ContactList.Model.AuthApp;

namespace ContactList.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public RegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RegisterInputModel Input { get; set; }

        public class RegisterInputModel
        {
            [Required(ErrorMessage = "Email обязателен")]
            [EmailAddress(ErrorMessage = "Введите корректный email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Пароль обязателен")]
            [MinLength(6, ErrorMessage = "Пароль должен быть не менее 6 символов")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Пароли не совпадают")]
            public string ConfirmPassword { get; set; }

            public string Role { get; set; } = "User";
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Проверка, существует ли уже пользователь
            var existingUser = _context.AuthUsers.FirstOrDefault(u => u.Email == Input.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Пользователь с таким email уже существует");
                return Page();
            }

            // Создание нового пользователя
            var user = new AuthUser
            {
                Email = Input.Email,
                Password = Input.Password,
                Role = Input.Role
            };

            _context.AuthUsers.Add(user);
            await _context.SaveChangesAsync();

            // Автоматический вход после регистрации
            await Authenticate(user.Email, user.Role);

            return RedirectToPage("/Index");
        }

        private async Task Authenticate(string userName, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
            };

            var identity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}