using Gameshop2.Data;
using Gameshop2.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult AdminPage()
        {
            var data = _context.Games.ToList();
            return View(data);
        }
        public IActionResult AddGamePage()
        {
            return View();
        }
        public IActionResult AddGame(Game game)
        {
            _context.Games.Add(new Game
            {
                Name = game.Name,
                Developer = game.Developer,
                Price = game.Price,
                Genre = game.Genre,
                RealeseDate = game.RealeseDate,
                ImageUrl = game.ImageUrl
            });

            _context.SaveChanges();
            return RedirectToAction("AdminPage");
        }

    }
}
