
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class UserPasswordChangeDto
    {
        [DisplayName("Şu Anki Şifreniz")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(30, ErrorMessage = "{0} {1} karekterden büyük olmamalıdır.")]
        [MinLength(10, ErrorMessage = "{0} {1} karekterden küçük olmamalıdır.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DisplayName("Yeni Şifreniz")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(30, ErrorMessage = "{0} {1} karekterden büyük olmamalıdır.")]
        [MinLength(10, ErrorMessage = "{0} {1} karekterden küçük olmamalıdır.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DisplayName("Yeni Şifrenizin Tekrarı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(30, ErrorMessage = "{0} {1} karekterden büyük olmamalıdır.")]
        [MinLength(10, ErrorMessage = "{0} {1} karekterden küçük olmamalıdır.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Girmiş olduğunuz yeni şifreniz ile yeni şifrenizin tekrarı alanları birbiri ile uyumlu olmalıdır.")]
        public string RepeatPassword { get; set; }
    }
}
