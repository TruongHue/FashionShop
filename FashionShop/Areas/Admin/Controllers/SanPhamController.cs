using FashionShop.Models;
using FashionShop.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FashionShop.Areas.Admin.Controllers
{
	[Area("Admin")]
		public class SanPhamController : Controller
	{
		
		private readonly DataContext _dataContext;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public SanPhamController(DataContext context, IWebHostEnvironment webHostEnvironment)
		{
			_dataContext = context;
			_webHostEnvironment = webHostEnvironment;
		}
		public async Task<IActionResult> Index() {
		
			//lay san pham
			return View(await _dataContext.SanPhams.OrderByDescending(p=>p.Id).Include(p => p.DanhMuc).Include(p => p.ThuongHieu).ToListAsync());
		}
		[HttpGet]
        public IActionResult Create()
        {

		ViewBag.Danhmucs = new SelectList(_dataContext.Danhmucs,"Id","Name");
        ViewBag.ThuongHieus = new SelectList(_dataContext.ThuongHieus, "Id", "Name");
            return View();
		}


        public async Task<IActionResult> Create(SanPhamModel sanPham)
        {
            ViewBag.Danhmucs = new SelectList(_dataContext.Danhmucs, "Id", "Name", sanPham.DanhMucId);
            ViewBag.ThuongHieus = new SelectList(_dataContext.ThuongHieus, "Id", "Name", sanPham.ThuongHieuId);
            if (ModelState.IsValid)
            {
                //thêm dữ liệu
                sanPham.Slug = sanPham.Name.Replace(" ", "_");
                var slug = await _dataContext.SanPhams.FirstOrDefaultAsync(p => p.Slug == sanPham.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Sản phẩm đã có trong database");
                    return View(sanPham);
                }
 
                    if (sanPham.ImageUpload != null)
                    {
                        string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "Picture/sanPham");
                        string imageName = Guid.NewGuid().ToString() + "_" + sanPham.ImageUpload.FileName;
                        string filePath = Path.Combine(uploadsDir, imageName);

                        using (FileStream fs = new FileStream(filePath, FileMode.Create))
                        {
                            await sanPham.ImageUpload.CopyToAsync(fs);
                        }
                        sanPham.Image = imageName;
                    }
                
                _dataContext.Add(sanPham);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Thêm sản phẩm thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Lỗi dữ liệu nhập vào";
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);
            }
        }

    }
}
