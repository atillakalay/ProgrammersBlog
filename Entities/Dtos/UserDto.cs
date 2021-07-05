using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.Dtos
{
   public class UserDto:DtoGetBase
    {
        public User User { get; set; }
    }
}
