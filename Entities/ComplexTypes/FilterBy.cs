

using System.ComponentModel.DataAnnotations;

namespace Entities.ComplexTypes
{
    public enum FilterBy
    {
        [Display(Name = "Kategori")]
        Category = 0, //GetAllByUserIdOnDate(FilterBy=FilterBy.Category,int categoryId)

        [Display(Name = "Tarih")]
        Date = 1,

        [Display(Name = "Okunma Sayısı")]
        ViewCount = 2,

        [Display(Name = "Yorum Sayısı")]
        CommentCount = 3
    }
}
