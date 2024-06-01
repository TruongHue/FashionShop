using FashionShop.Models;
using FashionShop.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FashionShop.Controllers
{
	public class HomeController : Controller
	{
		private readonly DataContext _dataContext;
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger,DataContext context)
		{
			_logger = logger;
			_dataContext = context;
		}

		public IActionResult Index()
		{
			var sanPhams = _dataContext.SanPhams.ToList();

			return View(sanPhams);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
