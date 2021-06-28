using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class CategoryAddDto
    {
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(70,ErrorMessage = "{0} {1} karekterden büyük olmamalıdır.")]
       [MinLength(3,ErrorMessage = "{0} {1} karekterden az olmamalıdır.")]
        public string Name { get; set; }

        [DisplayName("Kategori Açıklaması")]
        [MaxLength(500, ErrorMessage = "{0} {1} karekterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karekterden az olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Kategori Özel Not Alanı")]
        [MaxLength(500, ErrorMessage = "{0} {1} karekterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karekterden az olmamalıdır.")]
        public string Note { get; set; }

        [DisplayName("Aktif mi?")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public bool IsActive { get; set; }

    }
}
