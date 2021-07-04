using System.Collections.Generic;
using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.Dtos
{
   public class UserListDto:DtoGetBase
    {
        public IList<User> Users { get; set; }
    }
}
