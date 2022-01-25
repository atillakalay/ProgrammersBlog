
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class AboutUsPageInfo
    {
        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(150, ErrorMessage = "{0} alanı {1} karekterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karekterden küçük olmamalıdır.")]
        public string Header { get; set; }

        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(1500, ErrorMessage = "{0} alanı {1} karekterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karekterden küçük olmamalıdır.")]
        public string Content { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karekterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karekterden küçük olmamalıdır.")]
        public string SeoDescription { get; set; }

        [DisplayName("Seo Etiketleri")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karekterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karekterden küçük olmamalıdır.")]
        public string SeoTags { get; set; }

        [DisplayName("Seo Yazar")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(60, ErrorMessage = "{0} alanı {1} karekterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karekterden küçük olmamalıdır.")]
        public string SeoAuthor { get; set; }
    }
}
