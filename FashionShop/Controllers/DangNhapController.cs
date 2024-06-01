using Microsoft.AspNetCore.Mvc;

namespace FashionShop.Controllers
{
	public class DangNhapController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
