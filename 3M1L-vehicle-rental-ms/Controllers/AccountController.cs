using _3M1L_vehicle_rental_ms.Data;
using _3M1L_vehicle_rental_ms.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _3M1L_vehicle_rental_ms.Controllers
{
    public class AccountController : Controller
    {
        private readonly RentalDbContext _context;
        private readonly PasswordHasher<string> _passwordHasher;

        public AccountController(RentalDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<string>();
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                model.PasswordHash = _passwordHasher.HashPassword(null, model.PasswordHash);
                _context.Users.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(model);
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user != null && _passwordHasher.VerifyHashedPassword(null, user.PasswordHash, password) == PasswordVerificationResult.Success)
            {
                // Implement authentication logic (e.g., set cookies or session)
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid username or password.");
            return View();
        }
    }
}
