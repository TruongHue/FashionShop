using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FashionShop.Repository.Components
{
    public class DanhMucsViewComponent: ViewComponent
    {
        private readonly DataContext _dataContext;
        public DanhMucsViewComponent(DataContext context)
        {
            _dataContext = context;
        }
		public async Task<IViewComponentResult> InvokeAsync()
		{
			// Code lấy dữ liệu cho View Component
			var danhMucs = await _dataContext.Danhmucs.ToListAsync();

			// Trả về view với dữ liệu
			return View(danhMucs);
		}
	}
}
