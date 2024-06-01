using FashionShop.Models;
using Microsoft.EntityFrameworkCore;
namespace FashionShop.Repository
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ThuongHieuModel> ThuongHieus { get; set; }

        public DbSet<SanPhamModel> SanPhams { get; set; }
        public DbSet<DanhMucModel> Danhmucs { get; set; }
    }
}
