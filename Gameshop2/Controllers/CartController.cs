using Gameshop2.Data;
using Gameshop2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gameshop2.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddToCart(int gameId)
        {
            // Get the game from the database
            var game = _context.Games.FirstOrDefault(g => g.Id == gameId);

            if (game == null)
            {
                return NotFound(); // Game not found
            }

            // Get the current user's ID
            var existingUserEmail = User.Identity.Name;
            var userId = _context.Users
                .Where(u => u.Email == existingUserEmail)
                .Select(u => u.Id)
                .FirstOrDefault();

            // Check if the game is already in the user's cart
            var existingCartItem = _context.Carts
                .FirstOrDefault(c => c.UserId == userId && c.GameId == gameId);

            if (existingCartItem != null)
            {
                // If the game is already in the cart, increment the count
                existingCartItem.Count++;
            }
            else
            {
                // If the game is not in the cart, add it with a count of 1
                var cartItem = new Cart
                {
                    UserId = userId,
                    GameId = gameId,
                    Count = 1
                };

                _context.Carts.Add(cartItem);
            }

            // Save changes to the database
            _context.SaveChanges();

            return RedirectToAction("Index", "Cart"); // Redirect to the Cart page
        }

        public IActionResult Index()
        {
            var userId = _context.Users
               .Where(u => u.Email == User.Identity.Name)
               .Select(u => u.Id)
               .FirstOrDefault();

            var data = _context.Carts.Where(u => u.UserId == userId).ToList();
            return View(data);
        }
    }

}
