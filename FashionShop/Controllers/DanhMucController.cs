using Microsoft.AspNetCore.Mvc;

namespace FashionShop.Controllers
{
	public class DanhMucController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
