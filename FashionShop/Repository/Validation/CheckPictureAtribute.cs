using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace FashionShop.Repository.Validation
{
    public class CheckPictureAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file && file.Length > 0)
            {
                var extension = Path.GetExtension(file.FileName)?.ToLower(); // Lấy phần mở rộng của tệp
                if (extension != null && (extension == ".jpg" || extension == ".png" || extension == ".jpeg"))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Ảnh không phù hợp với các kiểu jpg, png, jpeg.");
                }
            }
            else
            {
                return new ValidationResult("Vui lòng chọn một tệp ảnh.");
            }
        }
    }
}
