using Microsoft.AspNetCore.Mvc;

namespace FashionShop.Controllers
{
	public class GioHangController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
