using System.ComponentModel.DataAnnotations;

namespace Entities.ComplexTypes
{
    public enum OrderBy
    {
        [Display(Name = "Tarih")]
        Date = 0,

        [Display(Name = "Okunma Sayısı")]
        ViewCount = 1,

        [Display(Name = "Yorum Sayısı")]
        CommentCount = 2
    }
}
