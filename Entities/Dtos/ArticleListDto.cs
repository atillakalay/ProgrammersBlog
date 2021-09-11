using System;
using System.Collections.Generic;
using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.Dtos
{
    public class ArticleListDto : DtoGetBase
    {
        public IList<Article> Articles { get; set; }
        public int? CategoryId { get; set; }

    }
}
