using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Entities.Concrete;

namespace Entities.Dtos
{
   public class ArticleDto:DtoGetBase
    {
        public Article Article { get; set; }
    }
}
