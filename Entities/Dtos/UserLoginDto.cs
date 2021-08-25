using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class UserLoginDto
    {
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} {1} karekterden büyük olmamalıdır.")]
        [MinLength(10, ErrorMessage = "{0} {1} karekterden küçük olmamalıdır.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(30, ErrorMessage = "{0} {1} karekterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} karekterden küçük olmamalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
