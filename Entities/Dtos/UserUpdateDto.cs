using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos
{
    public class UserUpdateDto
    {
        [Required]
        public int Id { get; set; }

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

        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(13, ErrorMessage = "{0} {1} karekterden büyük olmamalıdır.")]
        [MinLength(13, ErrorMessage = "{0} {1} karekterden küçük olmamalıdır.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DisplayName("Resim Ekle")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }
        public string Picture { get; set; }
    }
}
