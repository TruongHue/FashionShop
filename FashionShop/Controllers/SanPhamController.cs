using Microsoft.AspNetCore.Mvc;

namespace FashionShop.Controllers
{
	public class SanPhamController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Detail()
		{
			return View();
		}
	}
}
