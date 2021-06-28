using System.Collections.Generic;
using Core.Entities.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Entities.Concrete;

namespace Entities.Dtos
{
  public  class ArticleListDto:DtoGetBase
    {
        public IList<Article> Articles { get; set; }
    }
}
