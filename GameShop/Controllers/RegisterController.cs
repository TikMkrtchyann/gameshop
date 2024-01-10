using GameShop.Data;
using GameShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace GameShop.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AppDbContext _context;
        public RegisterController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult RegisterPage()
        {
            return View();
        }

        public IActionResult RegisterUser(User user)
        {
            if (ModelState.IsValid)
            {
                // Hash the password before storing it in the database
                string hashedPassword = HashPassword(user.Password);

                // Generate a unique Id (e.g., using GUID)
                user.Id = Guid.NewGuid().ToString();

                _context.Users.Add(new User
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Password = hashedPassword
                });

                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                                       .Where(y => y.Count > 0)
                                       .ToList();
            }

            // If the model state is not valid, redisplay the registration form with validation errors
            return RedirectToAction("RegisterPage");
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
