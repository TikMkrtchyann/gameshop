using GameShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _context;

		public HomeController(AppDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var data = _context.Games.ToList();
			return View(data);
		}
	}
}
