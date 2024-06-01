using System.ComponentModel.DataAnnotations;

namespace FashionShop.Models
{
	public class ThuongHieuModel
	{
		[Key]
		public int Id { get; set; }
		[Required,MinLength(4,ErrorMessage ="Yêu cầu nhập phân loại")]
		public string Name { get; set; }

		[Required, MinLength(4, ErrorMessage = "Yêu cầu nhập mô tả phân loại")]
		public string Description { get; set; }
		public string Slug { get; set; }
		public string Status { get; set; }

	}
}
