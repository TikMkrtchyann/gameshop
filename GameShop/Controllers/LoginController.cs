using GameShop.Data;
using GameShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;
        public LoginController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult LoginPage()
        {
            return View();
        }

        public IActionResult Logged()
        {
            var data = _context.Games.ToList();
            return View(data);
        }

        public IActionResult Login(string name, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Name == name);

            if (user != null && VerifyPasswordHash(password, user.Password))
            {
                // Reset any previous error messages
                TempData.Remove("ErrorMessage");

                return RedirectToAction("Logged");
            }
            // Display an error message for wrong username or password
            TempData["ErrorMessage"] = "Invalid username or password. Please try again.";

            // Display an error message for wrong username or password
            ModelState.AddModelError("name", "Invalid username or password");
            ModelState.AddModelError("password", "Invalid username or password");

            return RedirectToAction("LoginPage");
        }
        private bool VerifyPasswordHash(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
    }
}
