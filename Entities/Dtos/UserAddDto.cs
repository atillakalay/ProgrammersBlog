using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos
{
    public class UserAddDto
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karekterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karekterden küçük olmamalıdır.")]

        public string UserName { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} {1} karekterden büyük olmamalıdır.")]
        [MinLength(10, ErrorMessage = "{0} {1} karekterden küçük olmamalıdır.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(30, ErrorMessage = "{0} {1} karekterden büyük olmamalıdır.")]
        [MinLength(10, ErrorMessage = "{0} {1} karekterden küçük olmamalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(13, ErrorMessage = "{0} {1} karekterden büyük olmamalıdır.")]
        [MinLength(13, ErrorMessage = "{0} {1} karekterden küçük olmamalıdır.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DisplayName("Resim")]
        [Required(ErrorMessage = "Lütfen, bir {0} seçiniz.")]
        [DataType(DataType.Upload)]
        public IFormFile Picture { get; set; }
    }
}
